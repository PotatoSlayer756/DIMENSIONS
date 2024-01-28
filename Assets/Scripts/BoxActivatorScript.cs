using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxActivatorScript : MonoBehaviour
{
    public GameObject activatingObject, neededObject;
    [HideInInspector]
    public Animator animator;
    void Start()
    {
        animator = activatingObject.GetComponent<Animator>();
    }

    void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == neededObject)
        {
            if (animator != null)
            {
                animator.SetTrigger("PlayerEnt");
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == neededObject)
        {
            if (animator != null)
            {
                animator.SetTrigger("PlayerExi");
            }
        }
    }
}
