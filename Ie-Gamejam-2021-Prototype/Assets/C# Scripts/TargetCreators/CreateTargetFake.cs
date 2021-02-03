using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CreateTargetFake : MonoBehaviour, CreateTarget
{
    [Header("Positioning")]
    [SerializeField] private Vector2[] targetPositions;
    [SerializeField] private Vector2 xBounds;

    [Header("Recourses")]
    [SerializeField] private GameObject targetPrefab;

    [Header("Timing")]
    [SerializeField] private Vector2 randomSpawnRange;

    [Header("Options")]
    [SerializeField] public string poolName;

    private bool newCreated;

    private void Start()
    {
        SetNewCreated();
    }

    private void SetNewCreated()
    {
        Invoke("SetNewCreated", Random.Range(randomSpawnRange.x, randomSpawnRange.y));

        newCreated = true;
    }

    public GameObject Run(ObjectPool iObjectPool)
    {
        GameObject curTarget = null;

        if (newCreated == true)
        {
            newCreated = false;

            curTarget = iObjectPool.GetPoolObject(poolName);

            if (curTarget == null)
            {
                curTarget = Instantiate(targetPrefab);
            }

            Vector2 curTargetPosition = targetPositions[Random.Range(0, targetPositions.Length)];

            curTarget.transform.position = new Vector3(Random.Range(xBounds.x, xBounds.y), curTargetPosition.x, curTargetPosition.y);

            iObjectPool.AddObjectToPool(poolName, curTarget);

            curTarget.SetActive(true);
        }

        return curTarget;
    }
}
