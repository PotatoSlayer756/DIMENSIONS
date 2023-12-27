using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed = 2.0f;
    public Rigidbody rb;
    private bool movingTowardsA = true, hasPlayerTouched = false;

    void Update()
    {
        if (hasPlayerTouched)
        {
            if (movingTowardsA)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
                if (transform.position == pointA.position)
                {
                    movingTowardsA = false;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
                if (transform.position == pointB.position)
                {
                    movingTowardsA = true;
                }
            }
        }  
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasPlayerTouched = true;
            print("entered elevator");
            //collision.transform.parent = transform;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("exited elevator");
            //collision.transform.parent = null; // Remove the player from being a child of the elevator
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
