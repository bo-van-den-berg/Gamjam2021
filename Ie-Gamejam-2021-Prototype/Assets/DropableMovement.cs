using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropableMovement : MonoBehaviour
{
    [SerializeField] private Vector2 disiredVelocity;

    [SerializeField] private Vector2 knockbackDirection;
    [SerializeField] private float knockbackMultiplier;

    [SerializeField] private Movement movement;

    [SerializeField] private float min;

    private void Start()
    {
        movement.SetDisiredVelocity(disiredVelocity);
        movement.SetAndApplyKnockbackVelocity(new Vector2(Random.Range(-1f, 1f), Random.Range(.5f, 1f)) * knockbackDirection * knockbackMultiplier);
    }

    void Update()
    {
        if(transform.position.y <= min)
        {
            Destroy(gameObject);
        }
    }
}
