using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    private void Awake()
    {
        current = this;
    }

    public delegate void ObjectDelegate(GameObject iObject);
    public delegate void EmptyDelegate();

    public event ObjectDelegate objectDeath;
    public event EmptyDelegate waveCompleted;

    public void ObjectDeath(GameObject iObject)
    {
        if (objectDeath != null)
        {
            objectDeath(iObject);
        }
    }

    public void WaveCompleted()
    {
        if (waveCompleted != null)
        {
            waveCompleted();
        }
    }
}
