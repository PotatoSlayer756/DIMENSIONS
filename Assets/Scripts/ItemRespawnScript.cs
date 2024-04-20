using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRespawnScript : MonoBehaviour
{
    public Vector3 defaultPosition;
    public bool isConnected = false;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            print("item " + gameObject.name + " respawns");
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

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(this.gameObject + " collisioning with: " + collision.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
       //Debug.Log(this.gameObject + " exiting collision with: " + collision.gameObject);
    }
}
