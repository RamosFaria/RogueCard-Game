using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCard : Card
{
    [SerializeField]
    private GameObject projectile;

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
                    ShootFire(projectile);

                    break;
                case 2:
                    ShootFire(projectile);

                    break;
                case 3:
                    ShootFire(projectile);

                    break;
            }
        }
        
    }





}
