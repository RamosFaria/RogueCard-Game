using UnityEngine;

public class Coffin : Enemy
{
    [SerializeField]
    private Transform groundCheck;

    private Rigidbody2D rb2D;

    public Transform originPoint;

    public float speed;

    public Vector2 dir = new Vector2(1, 0);

    private float time;

    public float force;

    private Animator anim;

    public bool isFlipped = false;

    public Vector3 currentScale = new Vector3(1,1,1);
    public enum state
    {
        PATROL,
        ATTACK,
        DEATH
    }

    public state State;

    public override void Movement()
    {
        
        rb2D.AddForce(dir * 2,ForceMode2D.Impulse);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2D = GetComponent<Rigidbody2D>();
        State = state.PATROL;
        anim = GetComponent<Animator>();
        anim.SetFloat("Life", life);
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.GetComponent<Character>().dialogueActive)
        {
            switch (State)
            {
                case state.PATROL:

                    

                    anim.SetBool("Attacking", false);

                    time += Time.deltaTime;
                    if (time >= 1.3f)
                    {

                        rb2D.bodyType = RigidbodyType2D.Dynamic;

                        RaycastHit2D hit = Physics2D.Raycast(originPoint.position, dir, 2f);
                        if (hit)
                        {
                            if (hit.collider.CompareTag("Wall"))
                            {

                                Flip();
                                dir *= -1;
                            }
                        }
                        RaycastHit2D hitPlayer = Physics2D.Raycast(originPoint.position, dir, 6f, LayerMask.GetMask("Player"));
                        if (hitPlayer.collider != null && player.GetComponent<Character>().isInvisible == false)
                        {
                            currentScale = transform.localScale;
                            State = state.ATTACK;
                        }
                        time = 0f;
                    }

                    break;

                case state.ATTACK:
                    float dist = player.position.x - transform.position.x;
                    anim.SetBool("Attacking", true);
                    Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
                    playerRb.position = Vector2.MoveTowards(player.position, new Vector2(transform.position.x, player.position.y), 6f * Time.fixedDeltaTime);
                    rb2D.bodyType = RigidbodyType2D.Static;

                    if (dist < 1.5)
                    {
                        time += Time.deltaTime;

                        if (time >= 2f)
                        {
                            //player.GetComponent<Character>().isBeingPushed = true;     
                            player.GetComponent<Character>().TakeDamage();
                            playerRb.AddForce(dir * 20, ForceMode2D.Impulse);
                            playerRb.AddForce(Vector2.up * 1.5f, ForceMode2D.Impulse);
                            time = 0f;

                        }

                    }

                    if (Vector2.Distance(transform.position, player.position) >= 7f)
                    {

                        transform.localScale = currentScale;
                        State = state.PATROL;
                    }

                    break;

                case state.DEATH:
                    rb2D.bodyType = RigidbodyType2D.Static;
                    anim.SetBool("Attacking", false);
                    anim.Play("Death_Coffin");
                    time += Time.deltaTime;
                    if (time >= 3f)
                    {
                        Destroy(gameObject);
                    }
                    break;
            }
        }
        else
        {
            anim.SetBool("Attacking", true);
        }
        CheckGround();

        

        if (life <= 0)
        {
            State = state.DEATH;
        }
        



    }
    private void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.x *= -1;
        if (transform.position.x < player.position.x && isFlipped )
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x > player.position.x && !isFlipped )
        {
            transform.localScale = flipped;
            transform.Rotate(0f, -180f, 0f);
            isFlipped = true;
        }
    }
    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        
        transform.localScale = scale;
    }

    private void CheckGround()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, 2f);
        if(groundInfo.collider == false)
        {
            Flip();
            dir *= -1;
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }

}
