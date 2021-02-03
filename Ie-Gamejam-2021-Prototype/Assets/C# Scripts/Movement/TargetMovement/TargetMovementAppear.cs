using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovementAppear : MonoBehaviour, TargetMovement
{
    [Header("Options")]
    [SerializeField] float disiredDistance = 1;

    public TargetMovement Run(Movement iMovement, TargetMovementController iController)
    {
        iMovement.SetVelocity(Vector3.zero);
        iMovement.SetAndApplyKnockbackVelocity(new Vector3(0, disiredDistance, 0));
        iMovement.SetDisiredVelocity(Vector3.zero);

        if (iController.targetMovementIdle != null)
        {
            return iController.targetMovementIdle;
        }
        else
        {
            return iController.targetMovementDisappear;
        }
    }
}
