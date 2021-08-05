using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleCard : Card
{
    private Character character;

    private Color sprite;
    public override void UseCard()
    {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        character.isInvisible = true;
        Invoke("Visible", 3f);
        sprite = character.gameObject.GetComponent<SpriteRenderer>().color;
        sprite.a = 130f / 255f;
        character.GetComponent<SpriteRenderer>().color = sprite;
        FindObjectOfType<SoundManager>().PlaySound("InvisibilityCape_Sound");
    }

    private void Visible()
    {
        character.isInvisible = false;
        sprite.a = 255 / 255;
        character.GetComponent<SpriteRenderer>().color = sprite;
    }
}
