using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public int level;

    public bool isAvailable;

    [SerializeField] public bool canUse;

    public abstract void UseCard();

    [SerializeField]protected float cooldown;
    protected SpriteRenderer color;

    [Header("Card ColorBF")]
    protected float rBF = 90;
    protected float gBF =90;
    protected float bBF= 90;

    [Header("Card ColorAF")]
    protected float rAF = 255;
    protected float gAF = 255;
    protected float bAF= 255;

    public void Start()
    {
        color = gameObject.GetComponent<SpriteRenderer>();
        canUse = false;
        color.color = new Color(rBF / 255, rBF / 255, rBF / 255);
    }

    public void Update()
    {
        if(!canUse)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                color.color = new Color(rAF / 255F, gAF / 255, bAF / 255);
                canUse = true;
            }
        }



    }


    protected void ShootFire(GameObject proj)
    {
        Transform spawn = GameObject.Find("MagicSpawn").transform;
        GameObject obj = (GameObject)Instantiate(proj, spawn) as GameObject;
        obj.transform.SetParent(null);
    }

}
