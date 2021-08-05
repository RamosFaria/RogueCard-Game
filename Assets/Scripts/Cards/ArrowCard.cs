using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCard : Card
{
    [Header("GameObject for skills")]
    [SerializeField]
    private GameObject arrowObj;



    //[SerializeField]
    //private GameObject turret;

    private void Awake()
    {
        isAvailable = true;
    }

 
    public override void UseCard()
    {
        //setar o dano para cada nivel

        if(canUse)
        {
            switch (level)
            {
                case 1:
                    ShootFire(arrowObj);

                    break;
                case 2:
                    
                    break;
                case 3:
                    
                    break;
            }
        }

    }


}

