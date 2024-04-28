using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    public UnityEvent buttonpressed;
    Animator animator;
    [SerializeField] private AudioClip buttonSoundClip;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Activated()
    {
        AudioManager.Instance.PlaySoundClip(buttonSoundClip, transform, 0.6f);
        animator.SetTrigger("buttonpressed");
        buttonpressed.Invoke();
    }
}
