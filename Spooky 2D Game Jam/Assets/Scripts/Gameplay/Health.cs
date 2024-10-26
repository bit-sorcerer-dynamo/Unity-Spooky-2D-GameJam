﻿using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;

    public float CurrentHealth { get; private set; }

    void Start()
    {
        CurrentHealth = maxHealth;    
    }

    public void Heal(float healVal)
    {
        if (CurrentHealth + healVal <= maxHealth) CurrentHealth += healVal;
        else CurrentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (CurrentHealth - damage > 0) CurrentHealth -= damage;
        else
        {
            CurrentHealth = 0;
            Invoke("SelfDestruct", 2);
        }
    }

    void SelfDestruct()
    {
        Destroy(this.gameObject);
    }
}
