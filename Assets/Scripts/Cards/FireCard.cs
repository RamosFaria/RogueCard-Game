using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCard : Card
{

    private GameObject spawn;

    [SerializeField]
    private GameObject fireObj;

    private GameObject fireObjRef;

    public override void UseCard()
    {
        switch(level)
        {
            case 1:
                SpawnFire();
                break;

            case 2:
                SpawnFire();
                break;

            case 3:
               
                break;

        }
    }

    private void SpawnFire()
    {
        spawn = GameObject.Find("DamageArea");
        GameObject obj = Instantiate(fireObj, spawn.transform.position, Quaternion.identity);
        obj.transform.SetParent(null);
        fireObjRef = obj;
        Invoke("Disable", 3.5f);
    }

    private void Disable()
    {
        FindObjectOfType<SoundManager>().StopSound("Fire_Sound");
        Destroy(fireObjRef);
        
    }

}
