using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public bool isEmpty = true, canPickUp;
    public GameObject GrabSlot, heldObj;
    private Rigidbody rb;
    private BoxCollider bxc;

    private void Start()
    {
        Debug.Log("are his hands empty " + isEmpty);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button1) && canPickUp)
        {
            if (isEmpty)
            {
                PickUpObject(heldObj, GrabSlot);
                isEmpty = false;
            }
            else if (!isEmpty)
            {
                print(heldObj);
                DropObject(heldObj);
                isEmpty = true;
            }
        }
    }
    void PickUpObject(GameObject heldObj, GameObject GrabSlot)
    {
        if(heldObj != null)
        {
            rb = heldObj.GetComponent<Rigidbody>();
            bxc = heldObj.GetComponent<BoxCollider>();
            heldObj.transform.position = GrabSlot.transform.position;
            heldObj.transform.SetParent(GrabSlot.transform);
            rb.isKinematic = true;
            bxc.isTrigger = true;
            print("picked up");
        }
    }
    void DropObject(GameObject heldObj)
    {
        if(heldObj != null)
        {
            rb = heldObj.GetComponent<Rigidbody>();
            bxc = heldObj.GetComponent<BoxCollider>();
            rb.isKinematic = false;
            bxc.isTrigger = false;
            heldObj.transform.parent = null;
            print("putted down");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickable"))
        {
            canPickUp = true;
            heldObj = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pickable"))
        {
            canPickUp = false;
            heldObj = null;
        }
    }
}
