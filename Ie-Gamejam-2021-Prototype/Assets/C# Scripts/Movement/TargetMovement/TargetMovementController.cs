using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class TargetMovementController : MonoBehaviour
{
    [Header("Target Movements")]
    public TargetMovement targetMovementAppear;
    public TargetMovement targetMovementWalk;
    public TargetMovement targetMovementIdle;
    public TargetMovement targetMovementAttack;
    public TargetMovement targetMovementDisappear;
    public TargetMovement targetMovementDied;

    private Movement movement;

    private TargetMovement currentTargetMovement;
    private TargetMovement prevTargetMovement;

    private bool died = false;

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

        EventManager.current.objectDestroyed += Died;
    }

    void Update()
    {
        if(died)
        {
            died = false;

            if (currentTargetMovement != targetMovementDied)
            {
                if (targetMovementDisappear != null)
                {
                    currentTargetMovement = targetMovementDisappear;
                }
                else
                {
                    currentTargetMovement = targetMovementDied;
                }
            }
            else
            {
                currentTargetMovement = targetMovementIdle;
            }
        }

        if (currentTargetMovement != null)
        {
            if (currentTargetMovement != prevTargetMovement)
            {
                if (prevTargetMovement != null)
                {
                    prevTargetMovement.OnStateChange();
                }

                currentTargetMovement.OnStateChange();

                prevTargetMovement = currentTargetMovement;
            }

            currentTargetMovement = currentTargetMovement.Run(movement, this);
        }
    }

    private void GetAllComponents()
    {
        if (TryGetComponent<TargetMovementAppear>(out TargetMovementAppear iTargetMovementAppear))
        {
            targetMovementAppear = iTargetMovementAppear;
        }

        if (TryGetComponent<TargetMovementWalk>(out TargetMovementWalk iTargetMovementWalk))
        {
            targetMovementWalk = iTargetMovementWalk;
        }

        if (TryGetComponent<TargetMovementIdle>(out TargetMovementIdle iTargetMovementIdle))
        {
            targetMovementIdle = iTargetMovementIdle;
        }

        if (TryGetComponent<TargetMovementDisappear>(out TargetMovementDisappear iTargetMovementDisappear))
        {
            targetMovementDisappear = iTargetMovementDisappear;
        }

        if (TryGetComponent<TargetMovementAttack>(out TargetMovementAttack iTargetMovementAttack))
        {
            targetMovementAttack = iTargetMovementAttack;
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

    private void Died(GameObject iObject)
    {
        if (iObject == gameObject)
        {
            if (currentTargetMovement == targetMovementIdle || currentTargetMovement == targetMovementWalk || currentTargetMovement == targetMovementDied)
            {
                died = true;
            }
        }
    }
}
