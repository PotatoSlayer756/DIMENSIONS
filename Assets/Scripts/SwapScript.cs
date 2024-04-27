using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
public class SwapScript : MonoBehaviour
{
    public GameObject Player, WallPlayer, GrabSlot, PlayerChecker, WallPlayerSlot, BGMusic;
    public CinemachineVirtualCamera playerCamera;
    public Camera mainCamera, wallCamera;
    public bool playerInTrigger = false;
    public float wallRestrictionMin, wallRestrictionMax;
    private PickUpScript pickup;
    private WallMoving wp;

    [SerializeField] private AudioClip swappingSoundClip;

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
            print("Is he in trigger? " + playerInTrigger);
            print("Are his hands empty? " + pickup.isEmpty);
            if (playerInTrigger && pickup.isEmpty)
            {
                print("swapping");
                print(WallPlayer);
                switch (Player.activeSelf)
                {
                    case true:
                        AudioManager.Instance.PlaySoundClip(swappingSoundClip, transform, 1f);
                        WallPlayer.transform.position = WallPlayerSlot.gameObject.transform.position;
                        wp.minX = wallRestrictionMin; wp.maxX = wallRestrictionMax;
                        Debug.Log(wp.minX + " , " + wp.maxX);
                        WallPlayer.SetActive(true);
                        print("is wallplayer active? " + WallPlayer.activeSelf);
                        BGMusic.transform.parent = WallPlayer.transform;
                        BGMusic.transform.position = WallPlayer.transform.position;
                        Player.SetActive(false);
                        mainCamera.gameObject.SetActive(false);
                        wallCamera.gameObject.SetActive(true);
                        print("player check");
                        print("that wallplayer still active? " + WallPlayer.activeSelf);
                        break;

                    case false:
                        AudioManager.Instance.PlaySoundClip(swappingSoundClip, transform, 1f);
                        Player.transform.position = gameObject.transform.position;
                        Player.SetActive(true);
                        BGMusic.transform.parent = Player.transform;
                        BGMusic.transform.position = Player.transform.position;
                        WallPlayer.SetActive(false);
                        mainCamera.gameObject.SetActive(true);
                        wallCamera.gameObject.SetActive(false);
                        float wallCameraYRotation = wallCamera.transform.eulerAngles.y;
                        playerCamera.transform.eulerAngles = new Vector3(playerCamera.transform.eulerAngles.x, wallCameraYRotation, playerCamera.transform.eulerAngles.z);
                        print("wallplayer check");
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
        if (other.gameObject == Player)
        {
            print("player in trigger");
            playerInTrigger = true;
        }
        else if (other.gameObject == WallPlayer)
        {
            print("player in trigger");
            playerInTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            print("player exits trigger");
            playerInTrigger = false;
        }
        else if (other.gameObject == WallPlayer)
        {
            print("player exits trigger");
            playerInTrigger = false;
        }
    }
}
