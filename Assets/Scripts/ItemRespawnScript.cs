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
            RespawnObject(defaultPosition);
        }
    }
    void HitByRay()
    {
        gameObject.transform.parent.SendMessage("ObjectGotDestroyed");
        RespawnObject(defaultPosition);
    }
    public void RespawnObject(Vector3 defaultPosition)
    {
        gameObject.transform.parent = null;
        transform.position = defaultPosition;
    }
}
