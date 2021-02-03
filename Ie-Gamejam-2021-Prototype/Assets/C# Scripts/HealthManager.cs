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

    private void Die()
    {
        EventManager.current.ObjectDestroyed(gameObject);
    }
}
