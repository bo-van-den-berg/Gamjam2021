using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualHearts : MonoBehaviour
{
    [SerializeField] private HealthManager healthManager;

    [SerializeField] List<GameObject> hearts = new List<GameObject>();

    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            if (hearts.Count > healthManager.health)
            {
                Destroy(hearts[hearts.Count - 1]);

                hearts.RemoveAt(hearts.Count - 1);
            }
        }
    }
}
