using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualHearts : MonoBehaviour
{
    [SerializeField] private HealthManager healthManager;

    [SerializeField] List<GameObject> hearts = new List<GameObject>();

    void Update()
    {
        while (hearts.Count > healthManager.health)
        {
            Destroy(hearts[hearts.Count - 1]);
        }
    }
}
