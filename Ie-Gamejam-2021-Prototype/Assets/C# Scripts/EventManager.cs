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
    public delegate void ScreenShakeDelegate(float iDuration, float iAmount);
    public delegate void EmptyDelegate();
    public delegate void DropableDelegate(GameObject iObject, string iTableName);


    public event ObjectDelegate objectDeath;

    public event EmptyDelegate waveCompleted;

    public event ScreenShakeDelegate screenShake;

    public event DropableDelegate dropAtObject;

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

    public void ScreenShake(float iDuration, float iAmount)
    {
        if (screenShake != null)
        {
            screenShake(iDuration, iAmount);
        }
    }

    public void DropAtObject(GameObject iObject, string iTableName)
    {
        if (dropAtObject != null)
        {
            dropAtObject(iObject, iTableName);
        }
    }
}
