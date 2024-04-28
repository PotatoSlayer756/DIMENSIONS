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

    [SerializeField] private AudioClip activationSoundClip;

    void Start()
    {
        animator = activatingObject.GetComponent<Animator>();
    }

    void Update()
    {
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("collision");
        if (collision.gameObject == neededObject)
        {
            Debug.Log("boxpad activated");
            AudioManager.Instance.PlaySoundClip(activationSoundClip, transform, 1f);
            if (animator != null)
            {
                animator.SetTrigger("PlayerEnt");
            }
            Activated.Invoke();
        }
    }
    private void OnTriggerExit(Collider collision)
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
