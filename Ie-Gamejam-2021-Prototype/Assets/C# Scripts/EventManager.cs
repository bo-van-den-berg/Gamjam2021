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
    public event ObjectDelegate objectDestroyed;

    public void ObjectDestroyed(GameObject iObject)
    {
        if (objectDestroyed != null)
        {
            objectDestroyed(iObject);
        }
    }
}
