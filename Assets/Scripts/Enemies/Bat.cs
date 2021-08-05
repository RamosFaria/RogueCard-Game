using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bat : Enemy
{

    public state State;

    private float waitTime;
    private float deathTime;

    private Character character;

    private NavMeshAgent agent;

    private Animator anim;

    private Vector2 startPos;

    private Rigidbody2D rb;

    private bool isFlipped = false;

    public enum state
    {
        IDLE,
        ATTACK,
        FLYAWAY,
        FOLLOW,
        BACKTOIDLE,
        DEATH,
    }

    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Character").transform;
        anim = GetComponent<Animator>();
        startPos = transform.position;
        //rb = GetComponent<Rigidbody2D>();

        character = player.GetComponent<Character>();
        State = state.IDLE;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        
    }

    

    public override void Movement()
    {
        //agent.SetDestination(player.position);    
        player.GetComponent<Character>().TakeDamage();
        
        State = state.FLYAWAY;        
            
        if(Vector2.Distance(transform.position,player.position) >= 7)
        {
            
            agent.isStopped = false;
            State = state.IDLE;
        }

    }

    
    public void Update()
    {
        if(!player.GetComponent<Character>().inDialogue())
        {
            switch (State)
            {

                case state.IDLE:

                    agent.isStopped = true;
                    if (Vector2.Distance(player.position, transform.position) <= 10f && !player.GetComponent<Character>().isInvisible)
                    {
                        State = state.FOLLOW;
                    }
                    break;
                case state.ATTACK:

                    if (!character.isInvisible)
                    {
                        agent.isStopped = true;

                        Movement();
                    }

                    break;
                case state.FLYAWAY:
                    LookAway();
                    anim.SetBool("PlayerNearby", false);
                    agent.isStopped = false;
                    waitTime += Time.deltaTime;
                    //ajeitar essa movimentação
                    Vector2 moveTo = ((player.position * -1));
                    agent.SetDestination(moveTo);
                    if (waitTime >= 2f && agent.remainingDistance <= 1.5f)
                    {

                        State = state.FOLLOW;
                        waitTime = 0f;
                    }
                    break;

                case state.FOLLOW:
                    LookAtPlayer();
                    anim.SetBool("PlayerNearby", true);
                    anim.SetBool("Moving", true);
                    agent.isStopped = false;
                    agent.SetDestination(player.position);
                    if (agent.pathPending)
                    {
                        return;
                    }

                    if (agent.remainingDistance <= 1.8f)
                    {
                        agent.isStopped = true;
                        State = state.ATTACK;

                    }
                    else if (Vector2.Distance(transform.position, player.position) >= 11f)
                    {
                        Debug.Log("BackToIdle");
                        agent.isStopped = false;
                        State = state.BACKTOIDLE;
                    }
                    break;

                case state.BACKTOIDLE:
                    anim.SetBool("PlayerNearby", false);
                    anim.SetBool("Moving", true);
                    agent.SetDestination(startPos);
                    if (agent.remainingDistance <= 0.5)
                    {
                        State = state.IDLE;
                    }
                    else if (Vector2.Distance(player.position, transform.position) <= 10f)
                    {
                        Debug.Log("Follow");
                        State = state.FOLLOW;
                    }
                    break;


                case state.DEATH:
                    anim.Play("Death");
                    break;
            }
        }
        

        if(life <= 0)
        {
            State = state.DEATH;
            //ajeitar colisão com o chão
            if (Isgrounded())
            {
                deathTime += Time.deltaTime;
                if (deathTime >= 1f)
                {

                    gameObject.SetActive(false);
                }

            }

        }


    }

    private void LookAtPlayer()
    {
        
        Vector3 flipped = transform.localScale;
        flipped.x *= -1;
        
        if(transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            
            //transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if(transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            //transform.Rotate(0f, 180f, 0f);
            
            isFlipped = true;
        }
    }

    private void LookAway()
    {
        Vector3 flipped = transform.localScale;
        flipped.x *= -1;
        if (transform.position.x < player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            //transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x > player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            //transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    private bool Isgrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, LayerMask.GetMask("Ground"));
        return hit.collider != null;
    }
    public void Death()
    {
        Destroy(agent);
        gameObject.AddComponent<Rigidbody2D>();
    }
}
