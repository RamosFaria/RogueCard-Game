using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCard : Card
{
    private Transform shield;

    [SerializeField]
    private GameObject shieldPrefab = null;

    private GameObject instantiatedObj;

    private Character character;
    public override void UseCard()
    {
        character = GameObject.FindObjectOfType<Character>();
        shield = GameObject.Find("Shield").GetComponent<Transform>();
        instantiatedObj = Instantiate(shieldPrefab, shield) as GameObject;
        character.shieldActive = true;
        Invoke("DestroyShield", 3f);
        
    }

    private void DestroyShield ()
    {
        FindObjectOfType<SoundManager>().StopSound("ShieldSound");
        character.shieldActive = false;
        Destroy(instantiatedObj);
    }

}
