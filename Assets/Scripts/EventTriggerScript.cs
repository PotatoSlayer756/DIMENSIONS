using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTriggerScript : MonoBehaviour
{
    public UnityEvent eventCalled;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            eventCalled.Invoke();
        }
    }
}
