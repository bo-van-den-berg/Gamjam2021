using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovementAppear : MonoBehaviour, TargetMovement
{
    [Header("Options")]
    [SerializeField] private float disiredDistance = 1;

    [SerializeField] private float acceleration;

    public void OnStateChange()
    {

    }

    public TargetMovement Run(Movement iMovement, TargetMovementController iController)
    {
        iMovement.SetAcceleration(acceleration);
        iMovement.SetAndApplyKnockbackVelocity(new Vector3(0, disiredDistance, 0));
        iMovement.SetDisiredVelocity(Vector3.zero);

        if (iController.targetMovementWalk != null)
        {
            return iController.targetMovementWalk;
        }
        else if (iController.targetMovementIdle != null)
        {
            return iController.targetMovementIdle;
        }
        else
        {
            return iController.targetMovementDisappear;
        }
    }
}
