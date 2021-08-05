using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlataformController : MonoBehaviour
{
    private GameObject platFallColl;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S) && GetComponent<Character>().Isgrounded())
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, LayerMask.GetMask("Ground"));
            if(hit.collider.gameObject.CompareTag("PassThrough"))
            {
                platFallColl = hit.collider.gameObject;
                StartCoroutine(Fall());
            }

        }
    }

    IEnumerator Fall()
    {
        platFallColl.GetComponent<TilemapCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.8f);
        platFallColl.GetComponent<TilemapCollider2D>().enabled = true;
    }


}
