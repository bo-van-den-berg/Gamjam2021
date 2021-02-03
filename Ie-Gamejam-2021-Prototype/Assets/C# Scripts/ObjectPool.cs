using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private Dictionary<string, List<GameObject>> objectPool = new Dictionary<string, List<GameObject>>();

    public void AddObjectToPool(string iPoolName, GameObject iObject)
    {
        if (objectPool.ContainsKey(iPoolName))
        {
            objectPool[iPoolName].Add(iObject);
        }
        else
        {
            objectPool.Add(iPoolName, new List<GameObject>());

            AddObjectToPool(iPoolName, iObject);
        }
    }

    public GameObject GetPoolObject(string iPoolName)
    {
        if (objectPool.ContainsKey(iPoolName))
        {
            for (int i = 0; i < objectPool[iPoolName].Count; i++)
            {
                GameObject curObject = objectPool[iPoolName][i];

                if (!curObject.activeSelf)
                {
                    return curObject;
                }
            }
        }

        return null;
    }
}
