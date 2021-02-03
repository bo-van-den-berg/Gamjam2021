using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;

    public void RecieveDamage(int iDamage)
    {
        health -= iDamage;

        if (health <= 0)
        {
            Die();

            health = maxHealth;
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
