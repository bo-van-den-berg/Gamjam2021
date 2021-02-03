using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovementIdle : MonoBehaviour, TargetMovement
{
    public TargetMovement Run(Movement iMovement, TargetMovementController iController)
    {
        iMovement.SetDisiredVelocity(new Vector3());

        return this;
    }
}