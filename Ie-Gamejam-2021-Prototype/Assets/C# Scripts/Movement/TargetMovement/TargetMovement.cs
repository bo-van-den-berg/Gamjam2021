using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface TargetMovement
{
    TargetMovement Run(Movement iMovement, TargetMovementController iController);

    void OnStateChange();
}
