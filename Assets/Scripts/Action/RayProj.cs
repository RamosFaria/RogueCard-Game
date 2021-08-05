using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayProj : MonoBehaviour
{

    [SerializeField]
    private Transform damagePos;
    void Start()
    {
        
    }

    public void Damage()
    {
        Collider2D colInfo = Physics2D.OverlapCircle(damagePos.position, 3f, LayerMask.GetMask("Enemy"));
        if (colInfo != null)
        { 
            colInfo.GetComponent<Enemy>().TakeDamage(7.5f);
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

}
