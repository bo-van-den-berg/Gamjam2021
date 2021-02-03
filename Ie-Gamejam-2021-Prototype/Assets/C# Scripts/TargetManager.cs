using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TargetManager : MonoBehaviour
{
    private ObjectPool objectPool;

    private List<CreateTarget> targetCreators = new List<CreateTarget>();

    private void Awake()
    {
        objectPool = new ObjectPool();
    }

    private void Update()
    {
        targetCreators = FindObjectsOfType<MonoBehaviour>().OfType<CreateTarget>().ToList();

        for (int i = 0; i < targetCreators.Count; i++)
        {
            GameObject curObject = targetCreators[i].Run(objectPool);
        }
    }
}
