using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float doubleJumpForce;

    public bool canDoubleJump;

    public int health;
    public int maxHealth;

    public bool shieldActive;
    public bool isInvisible;

    private DialogueTrigger dialogueTrigger;
    private Manager gm;

    private Animator anim;
    private bool blink;

    private bool isBeingPushed;
    public bool canJump;

    public bool dialogueActive;

    public bool Isgrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, LayerMask.GetMask("Ground"));
        return hit.collider != null;
    }

    private void Awake()
    {
        
    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        gm = GameObject.Find("Manager").GetComponent<Manager>();
        anim = GetComponent<Animator>();
        health = maxHealth;
        
    }

    
    void Update()
    {
        Movement();

    }

    public bool inDialogue()
    {
        if (dialogueTrigger != null)
            return dialogueTrigger.DialogueActive();
        
        else
            return false;
    }

    private void Movement()
    {
        if(!inDialogue() )
        {
            
            float horizontal = Input.GetAxisRaw("Horizontal");
            anim.SetFloat("Speed", Mathf.Abs(horizontal * speed));
            switch (horizontal)
            {
                
                case 1:
                    
                    transform.rotation = Quaternion.identity;
                    rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
                    
                    break;
                case -1:
                    
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    rb.velocity = new Vector2(horizontal * speed, rb.velocity.y) ;
                   
                    
                    break;
                case 0:
                                     
                    if(isBeingPushed)
                    {
                        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
                    }
                    else
                    {
                        rb.velocity = new Vector2(0, rb.velocity.y);
                    }
                    
                    break;
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                if(Isgrounded())
                {
                    anim.SetBool("Jumping", true);
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }
                else
                if(canDoubleJump)
                {
                    anim.Play("CharacterDoubleJump");
                    rb.AddForce(Vector2.up * doubleJumpForce, ForceMode2D.Impulse);
                    canDoubleJump = false;

                }
               
                

                

            }
            if (rb.velocity.y == 0)
            {
                anim.SetBool("Falling", false);
            }

            if (rb.velocity.y < 0)
            {
                anim.SetBool("Jumping", false);
                anim.SetBool("Falling", true);
            }

        }
        else 
        {
            rb.velocity = new Vector2(0, 0);
            anim.SetFloat("Speed", 0f);
        }

        if(Isgrounded())
        {
            canDoubleJump = true;
        }

    }


    public void TakeDamage()
    {
        if(!shieldActive)
        {
            health -= 1;
            if (health <= 0)
            {
                blink = true;
                anim.Play("Death");
            }
            CharacterLife healthImage = GetComponent<CharacterLife>();
            healthImage.PlayAnimation();
            BlinkPlayer();

        }
        else
        {
            return;
        }

    }

    public void Heal(int heal)
    {
        if(health < maxHealth)
        {
            health += heal;

            CharacterLife healthImage = GetComponent<CharacterLife>();
            healthImage.PlayAnimationReversed();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.CompareTag("Dialogue"))
        {
            dialogueTrigger = collision.gameObject.GetComponent<DialogueTrigger>();
            dialogueActive = true;
            dialogueTrigger.ActivateDialogue();
            
        }
    }

    public void Death()
    {
        
        SaveManager.Instance.activeSave.deaths += 1;
        SaveManager.Instance.Save();
        gm.DeathEvent();
        
        
    }

    private void BlinkPlayer()
    {
        if (!blink)
        {
            StartCoroutine(DoBlinks(6, 0.1f));
        }
        else
        {
            return;
        }
        
    }

    IEnumerator DoBlinks(int numblinks, float seconds)
    {
        for (int i=0; i < numblinks * 2; i++)
        {
            GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;

            yield return new WaitForSeconds(seconds);
        }
        GetComponent<Renderer>().enabled = true;
    }

    public void Disable()
    {
        GetComponent<Character>().enabled = false;
    }


}
