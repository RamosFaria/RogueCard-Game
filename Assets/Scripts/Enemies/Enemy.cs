using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public Transform player;

    public float life;

    public abstract void Movement();

    public virtual void TakeDamage(float damage)
    {
        life -= damage;
    }
}
