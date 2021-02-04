using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] private List<GameObject> dropTablePlant = new List<GameObject>();
    [SerializeField] private List<GameObject> dropTableFake = new List<GameObject>();
    [SerializeField] private List<GameObject> dropTableZombie = new List<GameObject>();

    private void Start()
    {
        EventManager.current.dropAtObject += Drop;
    }

    private void Drop(GameObject iObject, string iTableName)
    {
        List<GameObject> newTable = new List<GameObject>();

        if (iTableName == "Plant")
        {
            for (int i = 0; i < dropTablePlant.Count; i++)
            {
                float num = GetRandNum(0, 1.25f, 1, 2);

                for (int j = 0; j < num; j++)
                {
                    newTable.Add(dropTablePlant[i]);
                }  
            }
        }
        else if(iTableName == "Zombie")
        {
            for (int i = 0; i < dropTableZombie.Count; i++)
            {
                float num = GetRandNum(0, 1.5f, 1, 2);

                for (int j = 0; j < num; j++)
                {
                    newTable.Add(dropTableZombie[i]);
                }
            }
        }
        else
        {
            for (int i = 0; i < dropTableFake.Count; i++)
            {
                float num = GetRandNum(0, 1.5f, 1, 2);

                for (int j = 0; j < num; j++)
                {
                    newTable.Add(dropTableFake[i]);
                }
            }
        }

        for (int i = 0; i < newTable.Count; i++)
        {
            Instantiate(newTable[i], iObject.transform.position, Quaternion.identity);
        }
    }

    private int GetRandNum(int min, float chance, int plus, float chanceInc)
    {
        int number = min;

        while (true)
        {
            if (Random.Range(0, 1f) <= 1 / chance)
            {
                number += plus;
                chance *= chanceInc;
            }
            else
            {
                return number;
            }
        }
    }
}
