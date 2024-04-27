using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformScript : MonoBehaviour
{
    public Animator animator;
    public AudioClip fallingStonesSoundClip;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("IsPlayerOn", false);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(animator != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                animator.SetBool("IsPlayerOn", true);
            }
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (animator != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                animator.SetBool("IsPlayerOn", false);
            }
        }
    }

    public void StonesAreFalling()
    {
        AudioManager.Instance.PlaySoundClip(fallingStonesSoundClip, transform, 1f);
    }
}
