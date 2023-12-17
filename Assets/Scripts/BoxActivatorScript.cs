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
        animator.enabled = false;
    }

    void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == neededObject)
        {
            print("pressed");
            animator.enabled = true;
        }
    }
}
