using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCard : Card
{
    private Character character;

    public override void UseCard()
    {
        switch(level)
        {
            case 1:

                FindObjectOfType<SoundManager>().PlaySound("HealSound");
                character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
                character.Heal(1);
                break;
            case 2:

                FindObjectOfType<SoundManager>().PlaySound("HealSound");
                character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
                character.Heal(2);
                break;
            case 3:

                FindObjectOfType<SoundManager>().PlaySound("HealSound");
                character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
                character.Heal(2);
                break;

        }
    }

}
