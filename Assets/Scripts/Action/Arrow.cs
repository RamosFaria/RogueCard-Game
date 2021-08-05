using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float damage;

    private Transform dir;

    private Rigidbody2D rb;

    private void Start()
    {
        
        dir = GameObject.Find("MagicSpawn").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(dir.right * 6.5f, ForceMode2D.Impulse);
        FindObjectOfType<SoundManager>().PlaySound("Arrow_Att");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") )
        {
            
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);

        }
        Destroy(gameObject);
    }




}
