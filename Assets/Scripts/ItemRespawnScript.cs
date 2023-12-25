using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRespawnScript : MonoBehaviour
{
    public Vector3 defaultPosition;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            print("item respawns");
            transform.position = defaultPosition;
        }
    }
}