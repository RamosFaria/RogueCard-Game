using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField]
    private GameObject dropCards = null;

    private Transform bossPos;
    private void Start()
    {
        bossPos = GameObject.FindObjectOfType<Boss>().transform;
    }
    public void Drop()
    {
        GameObject drop = Instantiate(dropCards,bossPos.position,Quaternion.identity);
        drop.transform.SetParent(null);
        
    }
    

}
