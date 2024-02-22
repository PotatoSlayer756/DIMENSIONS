using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformScript : MonoBehaviour
{
    public Animator animator;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(animator != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                animator.SetTrigger("PlayerEnt");
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (animator != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                animator.ResetTrigger("PlayerEnt");
            }
        }
    }
}
