using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    public UnityEvent buttonpressed;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Activated()
    {
        animator.SetTrigger("buttonpressed");
        buttonpressed.Invoke();
    }
}
