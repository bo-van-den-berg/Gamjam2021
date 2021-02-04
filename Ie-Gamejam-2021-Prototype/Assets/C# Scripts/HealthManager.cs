using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] private int maxHealth;

    public void RecieveDamage(int iDamage)
    {
        EventManager.current.ScreenShake(.05f, 1/16f);

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
        EventManager.current.ObjectDeath(gameObject);
    }
}
