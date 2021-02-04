using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovementAttack : MonoBehaviour, TargetMovement
{
    [Header("Options")]
    [SerializeField] Vector2 knockbackMultiplier;
    [SerializeField] Vector2 fallingVelocity;

    [SerializeField] float acceleration;

    public void OnStateChange()
    {

    }

    public TargetMovement Run(Movement iMovement, TargetMovementController iController)
    {
        EventManager.current.gameObject.GetComponent<HealthManager>().RecieveDamage(1);
        EventManager.current.ObjectDeath(gameObject);

        iMovement.SetAcceleration(acceleration);
        iMovement.SetKnockbackVelocity(new Vector3(Random.Range(-1f, 1f) * knockbackMultiplier.x, Random.Range(0, 1f) * knockbackMultiplier.y, 0));
        iMovement.SetDisiredVelocity(fallingVelocity);

        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        if (iController.targetMovementDied != null)
        {
            return iController.targetMovementDied;
        }
        else if (iController.targetMovementIdle != null)
        {
            return iController.targetMovementIdle;
        }
        else
        {
            return this;
        }
    }
}
