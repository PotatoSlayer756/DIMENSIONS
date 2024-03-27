using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed = 2.0f;
    public GameObject gear1, gear2;
    Animator g1anim, g2anim;
    public Rigidbody rb;
    private bool movingTowardsA = true, hasPlayerTouched = false;

    private void Awake()
    {
        g1anim = gear1.GetComponent<Animator>();
        g2anim = gear2.GetComponent<Animator>();    
    }
    void Update()
    {
        if (hasPlayerTouched)
        {
            Debug.Log("elevator activated");
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
    public void Activated()
    {
        hasPlayerTouched = true;
        g1anim.SetBool("PlayerEnt", true);
        g2anim.SetBool("PlayerEnt", true);
    }
    public void Deactivated()
    {
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
            collision.transform.parent = transform;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("exited elevator");
            collision.transform.parent = null; // Remove the player from being a child of the elevator
        }
    }
}
