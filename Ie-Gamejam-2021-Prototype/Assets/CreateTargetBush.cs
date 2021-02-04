using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CreateTargetBush : MonoBehaviour, CreateTarget
{
    [Header("Positioning")]
    [SerializeField] private Vector2[] targetPositions;
    [SerializeField] private Vector2 xBounds;

    [Header("Recourses")]
    [SerializeField] private GameObject targetPrefab;

    [Header("Timing")]
    [SerializeField] private Vector2 randomSpawnRange;
    [SerializeField] private float timeDecreaseRate;

    [Header("Options")]
    [SerializeField] public string poolName;

    private bool newCreated;

    public float timeDecrease = 1;

    private int createdCount;

    private void Start()
    {
        SetNewCreated();
    }

    private void SetNewCreated()
    {
        Invoke("SetNewCreated", Random.Range(randomSpawnRange.x, randomSpawnRange.y) * timeDecrease);

        timeDecrease = timeDecrease - timeDecrease / timeDecreaseRate;

        newCreated = true;
    }

    public void OnReset()
    {
        createdCount = 0;
    }

    public bool Run(ObjectPool iObjectPool, int iMaxCreatedCount)
    {
        GameObject curTarget = null;

        if (newCreated == true)
        {
            if (createdCount < iMaxCreatedCount || iMaxCreatedCount == -1)
            {
                newCreated = false;

                createdCount++;

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
        }

        if (createdCount >= iMaxCreatedCount && iMaxCreatedCount != -1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
