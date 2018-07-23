using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Interactable, IEnemy {

    // To add later, our base stat system.

    public float currentHealth, maxHealth, power, toughness;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void PerformAttack()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int amount)
    {

        currentHealth -= amount;

        if (currentHealth <= 0f)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
