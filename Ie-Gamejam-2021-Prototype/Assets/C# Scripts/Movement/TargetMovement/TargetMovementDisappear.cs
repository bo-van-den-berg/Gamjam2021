using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovementDisappear : MonoBehaviour, TargetMovement
{
    [Header("Options")]
    [SerializeField] float disiredDistance = -1;

    public void OnStateChange()
    {

    }

    public TargetMovement Run(Movement iMovement, TargetMovementController iController)
    {
        iMovement.SetKnockbackVelocity(new Vector3(0, disiredDistance, 0));
        iMovement.SetDisiredVelocity(new Vector3());

        if (iController.targetMovementDied != null)
        {
            return iController.targetMovementDied;
        }
        else if (iController.targetMovementIdle != null)
        {
            return iController.targetMovementIdle;
        }
        else if(iController.targetMovementAppear != null)
        {
            return iController.targetMovementAppear;
        }
        else
        {
            return this;
        }
    }
}
