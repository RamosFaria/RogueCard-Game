using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public state State;
    public enum state
    {
        MELEEATTACK,
        RANGEDATTACK,
        WALKTOPLAYER,
        DECIDEATTACK,
        DEATH,
    }

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private Transform spawnProj;

    [SerializeField]
    private Transform meleeAttackPos;

    private Animator anim;
    private Rigidbody2D rb;

    private bool sawPlayer;

    private bool isFlipped = false;

    private float time;


    private void Start()
    {
        life = 0f;
        player = GameObject.FindObjectOfType<Character>().transform;
        anim = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //FindObjectOfType<SoundManager>().StopSound("Music");
        //FindObjectOfType<SoundManager>().PlaySound("BossMusic");

    }

    public override void Movement()
    {
        
    }
    

    private void Update()
    {
        
        if (sawPlayer)
        {
            switch (State)
            {
                case state.DECIDEATTACK:
                    anim.SetBool("RangeAt", false);
                    anim.SetBool("Walking", false);
                    anim.SetBool("MeleeAt", false);

                    if (Vector2.Distance(player.position, transform.position) < 11f)
                    {
                        State = state.WALKTOPLAYER;
                    }
                    else
                    {
                        State = state.RANGEDATTACK;
                    }

                    break;


                case state.WALKTOPLAYER:
                    anim.SetBool("RangeAt", false);
                    anim.SetBool("Walking", true);
                    LookAtPlayer();
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), 3f * Time.deltaTime);
                    if (Vector3.Distance(transform.position, player.position) < 2.5f)
                    {
                        State = state.MELEEATTACK;
                    }
                    else if(Vector3.Distance(transform.position, player.position) > 11)
                    {
                        State = state.RANGEDATTACK;
                    }
                    break;

                case state.MELEEATTACK:
                    anim.SetBool("Walking", false);
                    anim.SetBool("MeleeAt", true);
                    break;
                case state.RANGEDATTACK:
                    anim.SetBool("Walking", false);
                    time += Time.deltaTime;
                    if(time>=1.5f)
                    {
                        anim.SetBool("RangeAt", true);
                        time = 0f;
                    }
                    

                    break;
                case state.DEATH:
                    anim.Play("Death");
                    break;
            }

        }
        if(life<=0)
        {
            State = state.DEATH;
        }

        if(gameObject.GetComponent<Renderer>().isVisible)
        {
            sawPlayer = true;

        }


    }
    private void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.x *= -1;
        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            //transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            //transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
    public void Shoot()
    {
        for(int i=0; i<3; i++)
        {
            GameObject obj = Instantiate(projectile, spawnProj.position,Quaternion.identity) as GameObject;
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(spawnProj.right.x * -10, -3 + (3 * i)), ForceMode2D.Impulse);
            obj.transform.SetParent(null);
        }
    }

    public void MeleeAtackDamage()
    {
        Collider2D colInfo = Physics2D.OverlapCircle(meleeAttackPos.position, 1f, LayerMask.GetMask("Player"));
        if (colInfo != null)
        {
            colInfo.GetComponent<Rigidbody2D>().AddForce(new Vector2(5,0),ForceMode2D.Impulse);
            colInfo.GetComponent<Character>().TakeDamage();
        }
    }

    public void ChangeState(state newstate)
    {
        State = newstate;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

}
