using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
public class SwapScript : MonoBehaviour
{
    public GameObject Player, WallPlayer, GrabSlot, PlayerChecker;
    public CinemachineVirtualCamera playerCamera;
    public Camera wallCamera;
    public Vector3 wallCameraOffSet;
    public bool playerInTrigger = false;
    public bool isWall = false;
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
            print(playerInTrigger);
            if (playerInTrigger && pickup.isEmpty)
            {
                print("swapping");
                switch (isWall)
                {
                    case false:
                        WallPlayer.transform.position = gameObject.transform.position + wallCameraOffSet;
                        wp.minX = wallRestrictionMin; wp.maxX = wallRestrictionMax;
                        Player.SetActive(false);
                        WallPlayer.SetActive(true);
                        playerCamera.gameObject.SetActive(false);
                        wallCamera.gameObject.SetActive(true);
                        playerCamera.transform.rotation = wallCamera.transform.rotation;
                        print("player check");
                        isWall = true;
                        break;

                    case true:
                        Player.transform.position = PlayerChecker.transform.position;
                        WallPlayer.SetActive(false);
                        Player.SetActive(true);
                        playerCamera.gameObject.SetActive(true);
                        wallCamera.gameObject.SetActive(false);
                        playerCamera.transform.rotation = wallCamera.transform.rotation;
                        print("wallplayer check");
                        isWall = false;
                        break;
                }
            }
            else
            {
                print("can't swap");
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
