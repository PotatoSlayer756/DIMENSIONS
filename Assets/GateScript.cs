using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public GameObject Player;
    private int keyCount;
    private PlayerMovement movement;
    private void Start()
    {
        movement = Player.GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        keyCount = movement.keyCount;
        if(keyCount > 3)
        {
            gameObject.SetActive(false);
        }
    }
}
