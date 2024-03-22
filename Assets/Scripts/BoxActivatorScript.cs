using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class BoxActivatorScript : MonoBehaviour
{
    public GameObject activatingObject, neededObject;
    public UnityEvent Activated, Disactivated;
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
            Debug.Log("boxpad activated");
            if (animator != null)
            {
                animator.SetTrigger("PlayerEnt");
            }
            Activated.Invoke();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == neededObject)
        {
            Debug.Log("boxpad disactivated");
            if (animator != null)
            {
                animator.SetTrigger("PlayerExi");
            }
            Disactivated.Invoke();
        }
    }
}
