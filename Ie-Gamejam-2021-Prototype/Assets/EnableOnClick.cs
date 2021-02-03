using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnClick : MonoBehaviour
{
    [SerializeField] private float activeTime;

    [SerializeField] private GameObject clickObject;

    private void SetActive()
    {
        CancelInvoke("SetActive");

        clickObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickObject.SetActive(true);

            Invoke("SetActive", activeTime);
        }
    }
}
