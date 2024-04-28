using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public GameObject Player;
    private int keyCount;
    private PlayerMovement movement;
    BoxCollider bc;
    Animator anim;
    private void Start()
    {
        movement = Player.GetComponent<PlayerMovement>();
        bc = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();    
    }
    private void Update()
    {
        keyCount = movement.keyCount;
        if(keyCount == 3)
        {
            anim.SetBool("GateOpen", true);
            bc.isTrigger = true;
        }
    }
}
