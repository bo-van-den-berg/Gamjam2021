using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovementIdle : MonoBehaviour, TargetMovement
{
    private bool died = false;

    private void Awake()
    {
        EventManager.current.objectDestroyed += Died;
    }

    public TargetMovement Run(Movement iMovement, TargetMovementController iController)
    {
        iMovement.SetDisiredVelocity(new Vector3());

        if (!died)
        {
            return this;
        }
        else
        {
            died = false;

            return iController.targetMovementDisappear;
        }
    }

    private void Died(GameObject iObject)
    {
        if (iObject == gameObject)
        {
            died = true;
        }
    }
}