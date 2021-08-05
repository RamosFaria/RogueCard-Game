using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLife : MonoBehaviour
{
    [SerializeField]private Image[] healthImage;
    private int charLife;

    //[SerializeField]private Sprite[] healthSprite;

    private void Start()
    {
        
    }


    private void Update()
    {
        charLife = GetComponent<Character>().health;
        
    }

    public void PlayAnimation()
    {
        Animator anim = healthImage[charLife - 1].GetComponent<Animator>();
        anim.SetBool("Lose", true);
        anim.SetBool("Gain", false);
    }

    public void PlayAnimationReversed()
    {
        Animator anim = healthImage[charLife].GetComponent<Animator>();
        anim.SetBool("Lose", false);
        anim.SetBool("Gain", true);

    }


}
