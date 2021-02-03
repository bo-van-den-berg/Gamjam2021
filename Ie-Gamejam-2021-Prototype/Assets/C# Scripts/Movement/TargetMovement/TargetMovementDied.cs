using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovementDied : MonoBehaviour, TargetMovement
{
    [SerializeField] private float destroyTime;

    public TargetMovement Run(Movement iMovement, TargetMovementController iController)
    {
        iMovement.SetDisiredVelocity(new Vector3());

        Invoke("Destroy", destroyTime);

        return this;
    }

    private void Destroy()
    {
        CancelInvoke("Destroy");

        gameObject.SetActive(false);
    }
}