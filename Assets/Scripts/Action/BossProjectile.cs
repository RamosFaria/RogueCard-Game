using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    private Transform dir;

    private Rigidbody2D rb;
    
    void Start()
    {
        dir = GameObject.Find("RangedAttack").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Character>().TakeDamage();
        }
        //Debug.Log(collision.gameObject.name);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * 200f * Time.deltaTime);
    }

}
