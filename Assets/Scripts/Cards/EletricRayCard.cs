using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EletricRayCard : Card
{
    private Transform closestEnemy;

    [SerializeField]
    private GameObject rayProj = null;

    public override void UseCard()
    {
        switch(level)
        {
            case 1:
                               
                Transform player = GameObject.FindGameObjectWithTag("Player").transform;
                Collider2D[] cols = Physics2D.OverlapCircleAll(player.position, 10f,  LayerMask.GetMask("Enemy"));
                float minDist = Mathf.Infinity;
                 foreach(Collider2D col in cols )
                 {
                    float dist = Vector3.Distance(player.position, col.gameObject.transform.position);
                    if(dist < minDist)
                    {
                        closestEnemy = col.gameObject.transform;
                        minDist = dist;
                    }
                 }
                 if(closestEnemy != null)
                {
                    FindObjectOfType<SoundManager>().PlaySound("RaySound");
                    Instantiate(rayProj, closestEnemy.position + new Vector3(0, 3, 0), Quaternion.identity);
                }
                else
                {
                    return;
                }

                break;

            case 2:



                break;

            case 3:



                break;
        }
    }
}
