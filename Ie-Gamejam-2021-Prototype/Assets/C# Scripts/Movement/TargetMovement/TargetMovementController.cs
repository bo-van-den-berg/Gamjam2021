using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class TargetMovementController : MonoBehaviour
{
    private Movement movement;

    private TargetMovement TargetMovementAppear;
    private TargetMovement TargetMovementDisappear;

    private TargetMovement currentTargetMovement;

    private void Awake()
    {
        GetAllComponents();
    }

    private void Start()
    {
        currentTargetMovement = TargetMovementAppear;
    }

    void Update()
    {
        if (currentTargetMovement != null)
        {
            currentTargetMovement = currentTargetMovement.Run(movement);
        }
    }

    private void GetAllComponents()
    {
        if (TryGetComponent<TargetMovementAppear>(out TargetMovementAppear iTargetMovementAppear))
        {
            TargetMovementAppear = iTargetMovementAppear;
        }

        if (TryGetComponent<Movement>(out Movement iMovement))
        {
            movement = iMovement;
        }
    }
}
