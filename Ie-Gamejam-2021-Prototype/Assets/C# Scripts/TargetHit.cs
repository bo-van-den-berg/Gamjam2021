using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    private HealthManager healthmanager;

    private void Awake()
    {
        GetComponents();
    }

    private void OnMouseUp()
    {
        if (healthmanager != null)
        {
            healthmanager.RecieveDamage(1);
        }
    }

    private void GetComponents()
    {
        if (TryGetComponent<HealthManager>(out HealthManager iHealthManager))
        {
            healthmanager = iHealthManager;
        }
    }
}
