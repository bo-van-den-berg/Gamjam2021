using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class TargetMovementController : MonoBehaviour
{
    [Header("Target Movements")]
    public TargetMovement targetMovementAppear;
    public TargetMovement targetMovementIdle;
    public TargetMovement targetMovementDisappear;
    public TargetMovement targetMovementDied;

    private Movement movement;

    private TargetMovement currentTargetMovement;

    private void OnEnable()
    {
        currentTargetMovement = targetMovementAppear;
    }

    private void OnDisable()
    {
        currentTargetMovement = targetMovementAppear;
    }

    private void Awake()
    {
        GetAllComponents();
    }

    void Update()
    {
        if (currentTargetMovement != null)
        {
            currentTargetMovement = currentTargetMovement.Run(movement, this);
        }
    }

    private void GetAllComponents()
    {
        if (TryGetComponent<TargetMovementAppear>(out TargetMovementAppear iTargetMovementAppear))
        {
            targetMovementAppear = iTargetMovementAppear;
        }

        if (TryGetComponent<TargetMovementIdle>(out TargetMovementIdle iTargetMovementIdle))
        {
            targetMovementIdle = iTargetMovementIdle;
        }

        if (TryGetComponent<TargetMovementDisappear>(out TargetMovementDisappear iTargetMovementDisappear))
        {
            targetMovementDisappear = iTargetMovementDisappear;
        }

        if (TryGetComponent<TargetMovementDied>(out TargetMovementDied iTargetMovementDied))
        {
            targetMovementDied = iTargetMovementDied;
        }

        if (TryGetComponent<Movement>(out Movement iMovement))
        {
            movement = iMovement;
        }
    }
}
