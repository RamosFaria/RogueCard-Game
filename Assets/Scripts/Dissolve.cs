using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    private Material material;

    public bool isDissolving;

    private float fade = 1f;

    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDissolving)
        {
            fade -= Time.deltaTime;
            if(fade<= 0f)
            {
                //Destroy(gameObject);
                gameObject.SetActive(false);
                fade = 0f;
                isDissolving = false;
            }
            material.SetFloat("_Fade", fade);
        }
    }
}
