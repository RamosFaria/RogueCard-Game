using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireObj : MonoBehaviour
{
    private float time;

    private Animator anim;

    private float damageTime;
    private void Update()
    {
        
        if(!Isgrounded())
        {
            transform.position -= ( new Vector3(0,Mathf.Abs (1), 0));
        }
        if(Isgrounded())
        {
            time += Time.deltaTime;
            if (time >= 2f)
            {
                anim.Play("FireEnd");
                time = 0f;
            }
        }

    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        FindObjectOfType<SoundManager>().PlaySound("Fire_Sound");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            collision.gameObject.GetComponent<Enemy>().TakeDamage(5);

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            damageTime += Time.deltaTime;
            if(damageTime >1f)
            {
                collision.gameObject.GetComponent<Enemy>().TakeDamage(5);
            }
            

        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public bool Isgrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, LayerMask.GetMask("Ground"));
        return hit.collider != null;
    }
}
