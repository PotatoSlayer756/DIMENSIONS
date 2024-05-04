using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EyeScript : MonoBehaviour
{
    Quaternion defaultRotation;

    private void Start()
    {
        defaultRotation = transform.rotation;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.LookAt(new Vector3(other.transform.position.x, other.transform.position.y + 90, other.transform.position.z));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(defaultRotation);
            transform.DORotate(defaultRotation.eulerAngles, 1f);
        }
    }
}
