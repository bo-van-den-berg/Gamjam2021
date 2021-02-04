using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float movementSize;

    private Vector3 ancerPosition;

    private void Awake()
    {
        ancerPosition = transform.position;
    }

    void Update()
    {
        transform.position = ancerPosition + new Vector3(0, Mathf.Sin(Time.time * movementSpeed) * movementSize, 0) / 100;
    }
}
