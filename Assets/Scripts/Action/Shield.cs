using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("Shield");
        FindObjectOfType<SoundManager>().PlaySound("ShieldSound");
    }
}
