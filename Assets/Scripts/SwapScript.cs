using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class SwapScript : MonoBehaviour
{
    public GameObject Player, WallPlayer, GrabSlot, PlayerChecker;
    public CinemachineVirtualCamera playerCamera;
    public bool playerInTrigger = false;
    public float wallRestrictionMin, wallRestrictionMax;
    private PickUpScript pickup;
    private WallMoving wp;
    // Start is called before the first frame update
    void Start()
    {
        pickup = GrabSlot.GetComponent<PickUpScript>();
        wp = WallPlayer.GetComponent<WallMoving>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            if (playerInTrigger & pickup.isEmpty)
            {
                print("swapping");
                switch (Player.activeSelf)
                {
                    case true:
                        WallPlayer.transform.position = gameObject.transform.position;
                        wp.minX = wallRestrictionMin; wp.maxX = wallRestrictionMax;
                        WallPlayer.SetActive(true);
                        Player.SetActive(false);
                        playerCamera.Follow = WallPlayer.transform;
                        print("player check");
                        break;

                    case false:
                        Player.transform.position = PlayerChecker.transform.position;
                        WallPlayer.SetActive(false);
                        Player.SetActive(true);
                        playerCamera.Follow = Player.transform;
                        print("wallplayer check");
                        break;
                }
            }
        }       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("player in trigger");
            playerInTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("player exits trigger");
            playerInTrigger = false;
        }
    }
}
