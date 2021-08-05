using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float damage;

    private Transform dir;

    private Rigidbody2D rb;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        dir = GameObject.Find("MagicSpawn").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(dir.right * 6.5f, ForceMode2D.Impulse);
        FindObjectOfType<SoundManager>().PlaySound("FireBall_Att");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.Play("Hit");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
        
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.Play("Hit");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            
        }
        
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }


}
