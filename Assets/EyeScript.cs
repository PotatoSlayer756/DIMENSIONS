using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EyeScript : MonoBehaviour
{
    Vector3 defaultRotation;

    private void Start()
    {
        defaultRotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.gameObject);
            transform.LookAt(other.transform.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.DORotate(defaultRotation, 1f);
        }
    }
}
