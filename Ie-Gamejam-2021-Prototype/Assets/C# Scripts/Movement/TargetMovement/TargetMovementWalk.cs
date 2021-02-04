using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovementWalk : MonoBehaviour, TargetMovement
{
    [Header("Options")]
    [SerializeField] private float maxMovementSpeed;
    [SerializeField] private float movementTime;
    [SerializeField] private Vector2 movementBounds;

    private float movementSpeed;
    private float movementDirection = 1;

    private bool attack = false;

    public void OnStateChange()
    {
        CancelInvoke("Attack");

        attack = false;

        movementSpeed = 0;

        movementDirection = Mathf.Abs(movementDirection);

        if (Random.Range(0, 2) == 1)
        {
            movementDirection = -movementDirection;

            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public TargetMovement Run(Movement iMovement, TargetMovementController iController)
    {
        movementSpeed += Time.deltaTime * maxMovementSpeed / movementTime;

        Invoke("Attack", movementTime);

        if (transform.position.x < movementBounds.x)
        {
            movementDirection = -movementDirection;
            transform.position = new Vector3(movementBounds.x, transform.position.y, transform.position.z);
            transform.position += new Vector3(.1f, 0, 0);

            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (transform.position.x > movementBounds.y)
        {
            movementDirection = -movementDirection;
            transform.position = new Vector3(movementBounds.y, transform.position.y, transform.position.z);
            transform.position -= new Vector3(.1f, 0, 0);

            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            iMovement.SetDisiredVelocity(new Vector3(1 * movementDirection * movementSpeed, 0, 0));
        }

        if (!attack)
        {
            return this;
        }
        else
        {
            attack = false;

            return iController.targetMovementAttack;
        }
    }

    private void Attack()
    {
        CancelInvoke("Attack");

        attack = true;
    }
}
