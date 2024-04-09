using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PickUpScript : MonoBehaviour
{
    public bool isEmpty, canPickUp, canRotate = false, canPress = false, isConnected;
    public GameObject GrabSlot, heldObj, childObj;
    private Rigidbody rb;
    ItemRespawnScript itemReScript;
    private float Resulting_Value_from_Input;
    private Quaternion Quaternion_Rotate_From;
    private Quaternion Quaternion_Rotate_To;

    PlayerMovement playerMovement;
    private void Start()
    {
        //Debug.Log("are his hands empty " + isEmpty);
        playerMovement = GetComponentInParent<PlayerMovement>();
        isEmpty = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            if (isEmpty)
            {
                if (canPickUp)
                {
                    PickUpObject(heldObj, GrabSlot);
                    isEmpty = false;
                }
            }
            else if (!isEmpty)
            {
                DropObject(childObj);
                isEmpty = true;
            }
            if (canRotate)
            {
                print("Rotating...");
                RotateLaserTurett(heldObj);
            }
            if(canPress)
            {
                print("button pressing...");
                PressTheButton(heldObj);
            }

        }
    }
    public void PickUpObject(GameObject heldObj, GameObject GrabSlot)
    {
        if(heldObj != null)
        {
            playerMovement.isHolding = true;
            rb = heldObj.GetComponent<Rigidbody>();
            if (heldObj.GetComponent<ItemRespawnScript>() != null)
            {
                itemReScript = heldObj.GetComponent<ItemRespawnScript>();
                itemReScript.isConnected = false;
            }
            heldObj.transform.position = GrabSlot.transform.position;
            heldObj.transform.SetParent(GrabSlot.transform);
            rb.isKinematic = true;
            childObj = heldObj;
            Physics.IgnoreLayerCollision(7, 8);
            print("picked up " + childObj);
        }
    }
    public void DropObject(GameObject heldObj)
    {        
        if(childObj != null)
        {
            playerMovement.isHolding = false;
            rb = heldObj.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            childObj.transform.parent = null;
            Physics.IgnoreLayerCollision(7, 8, false);
            print("putted down " + childObj);
            childObj = null;
        }
    }
    
    void RotateLaserTurett(GameObject heldObj)
    {
        if (heldObj != null)
        {
            LaserScript laserScript = heldObj.GetComponent<LaserScript>();
            DropObject(childObj);
            laserScript.Rotate();
        }
    }
    void PressTheButton(GameObject heldObj)
    {
        if (heldObj != null)
        {
            ButtonScript buttonScript = heldObj.GetComponent<ButtonScript>();
            DropObject(childObj);
            buttonScript.Activated();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickable"))
        {
            canPickUp = true;
            heldObj = other.gameObject;
        }
        if (other.CompareTag("LaserGun"))
        {
            canRotate = true;
            heldObj = other.gameObject;
        }
        if (other.CompareTag("Pressable"))
        {
            print("can press button");
            canPress = true;
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
        if (other.CompareTag("LaserGun"))
        {
            canRotate = false;
            heldObj = null;
        }
        if (other.CompareTag("Pressable"))
        {
            canPress = false;
            heldObj = null;
        }
    }
    public void ObjectGotDestroyed()
    {
        playerMovement.isHolding = false;
        rb = heldObj.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        heldObj.transform.parent = null;
        print("putted down");
    }
}
