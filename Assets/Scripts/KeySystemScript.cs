using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KeySystemScript : MonoBehaviour
{
    public GameObject player, k1, k2, k3;
    public float scale;
    PlayerMovement playerscript;
    void Start()
    {
        k1.SetActive(false); k2.SetActive(false); k3.SetActive(false);
        playerscript = player.GetComponent<PlayerMovement>();
        Debug.Log("key system active");
    }

    // Update is called once per frame
    void Update()
    {
        if(playerscript.keyCount == 1)
        {
            k1.SetActive(true);
        }
        if (playerscript.keyCount == 2)
        {
            k2.SetActive(true);
        }
        if (playerscript.keyCount == 3)
        {
            k3.SetActive(true);
        }
    }
}
