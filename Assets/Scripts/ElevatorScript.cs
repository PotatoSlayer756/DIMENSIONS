using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed = 2.0f;
    public GameObject gear1, gear2, elevatorSFX;
    Animator g1anim, g2anim;
    [HideInInspector]
    public Rigidbody rb;
    private bool movingTowardsA = true, hasPlayerTouched = false;
    Vector3 pA, pB;
    private void Awake()
    {
        g1anim = gear1.GetComponent<Animator>();
        g2anim = gear2.GetComponent<Animator>();  
        rb = GetComponent<Rigidbody>();
        pA = pointA.position;
        pB = pointB.position;
    }
    void FixedUpdate()
    {
        if (hasPlayerTouched)
        {
            Debug.Log("elevator activated");
            elevatorSFX.SetActive(true);
            /*if (movingTowardsA)
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
            }*/

            if (movingTowardsA)
            {
                rb.MovePosition(Vector3.MoveTowards(rb.position, pA, speed * Time.fixedDeltaTime));
                if (transform.position == pointA.position)
                {
                    movingTowardsA = false;
                }
            }
            else
            {
                rb.MovePosition(Vector3.MoveTowards(rb.position, pB, speed * Time.fixedDeltaTime));
                if (transform.position == pointB.position)
                {
                    movingTowardsA = true;
                }
            }
        }  
    }
    public void Activated()
    {
        Debug.Log("elevator activated");
        hasPlayerTouched = true;
        g1anim.SetBool("PlayerEnt", true);
        g2anim.SetBool("PlayerEnt", true);
    }
    public void Deactivated()
    {
        elevatorSFX.SetActive(false);
        hasPlayerTouched = false;
        g1anim.SetBool("PlayerEnt", false);
        g2anim.SetBool("PlayerEnt", false);
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
}
