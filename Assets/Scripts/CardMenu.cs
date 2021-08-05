using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMenu : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnMouseOver()
    {
        anim.SetBool("IsMouseOver", true);
    }

    private void OnMouseExit()
    {
        anim.SetBool("IsMouseOver", false);
    }

    public void CardSound()
    {
        FindObjectOfType<SoundManager>().PlaySound("CardTurnSound");
    }

}
