using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcheckscript : MonoBehaviour
{
    PlayerMovement movementScript;
    Animator anim;
    public GameObject player, playermodel;

    private void Awake()
    {
        anim = playermodel.GetComponent<Animator>();
    }
    void Start()
    {
        movementScript = player.GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            movementScript.isOnGround = true;
            Debug.Log("is on ground - " + movementScript.isOnGround);
            anim.SetBool("IsOnGround", movementScript.isOnGround);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            movementScript.isOnGround = false;
            Debug.Log("is on ground - " + movementScript.isOnGround);
            anim.SetBool("IsOnGround", movementScript.isOnGround);
        }
    }
}
