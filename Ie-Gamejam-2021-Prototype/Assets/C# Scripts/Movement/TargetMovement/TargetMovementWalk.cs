using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovementWalk : MonoBehaviour, TargetMovement
{
    [Header("Options")]
    [SerializeField] private float movementTime;
    [SerializeField] private float movementSpeed;
    [SerializeField] private Vector2 movementBounds;

    private bool attack = false;

    private void OnEnable()
    {
        movementSpeed = Mathf.Abs(movementSpeed);

        if (Random.Range(0, 2) == 1)
        {
            movementSpeed = -movementSpeed;

            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public TargetMovement Run(Movement iMovement, TargetMovementController iController)
    {
        Invoke("Attack", movementTime);

        if (transform.position.x < movementBounds.x)
        {
            movementSpeed = -movementSpeed;
            transform.position = new Vector3(movementBounds.x, transform.position.y, transform.position.z);
            transform.position += new Vector3(.1f, 0, 0);

            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (transform.position.x > movementBounds.y)
        {
            movementSpeed = -movementSpeed;
            transform.position = new Vector3(movementBounds.y, transform.position.y, transform.position.z);
            transform.position -= new Vector3(.1f, 0, 0);

            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            iMovement.SetDisiredVelocity(new Vector3(1 * movementSpeed, 0, 0));
        }

        if (!attack)
        {
            return this;
        }
        else
        {
            attack = false;

            //return iController.targetMovementIdle;
            return this;
        }
    }

    private void Attack()
    {
        CancelInvoke("Attack");

        attack = true;
    }
}
