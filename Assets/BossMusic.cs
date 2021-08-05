using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<SoundManager>().StopSound("Music");
            FindObjectOfType<SoundManager>().PlaySound("BossMusic");
        }
        Destroy(gameObject);
    }
}
