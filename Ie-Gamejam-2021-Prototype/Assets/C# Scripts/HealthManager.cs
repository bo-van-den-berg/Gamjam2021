using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;

    public void RecieveDamage(int iDamage)
    {
        if (health - iDamage <= 0)
        {
            Die();

            health = maxHealth;
        }
        else
        {
            health -= iDamage;
        }
    }

    public void InstaKill()
    {
        health = 0;
        health = maxHealth;

        Die();
    }

    private void Die()
    {
        EventManager.current.ObjectDestroyed(gameObject);
    }
}
