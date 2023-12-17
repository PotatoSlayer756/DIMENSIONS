using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformScript : MonoBehaviour
{
    public Animator animator;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.enabled = false;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.enabled = true;
        }
    }
}
