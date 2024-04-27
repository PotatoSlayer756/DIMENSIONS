using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed, holdingSpeed;
    public float jumpForce = 5.0f, respawnR, groundDistance, cameraYRotation;
    public bool isOnGround = false, isHolding = false, isLasered = false, canHeMove = true, isDustPlaying = false, isOnElevator = false, isRespawning = false, isMoving; 
    public int keyCount = 0, CameraRotation;
    public string deathcause;
    //public List<GameObject> secrets;

    public Rigidbody rb;
    public LayerMask groundMask;
    public GameObject portal;
    public Vector3 respawnPos;
    public CinemachineVirtualCamera playerCamera;
    public GameObject WallPlayer, walkingFX;
    public Transform GroundChecker;
    public ParticleSystem dust;
    public UnityEvent onKeyPicked, onPlayerDeath, onSecretFound, onSecretLost;

    [Header("SOUNDS")]
    [SerializeField] private AudioClip[] jumpSoundClips;
    [SerializeField] private AudioClip deathSoundClip;
    [SerializeField] private AudioClip keySoundClip;



    private zonescript zone;
    private PickUpScript pickUpScript;
    private TimerScript timerScript;
    private SceneLoaderScript sceneLoaderScript;
    private SecretScript secretScript;
    private CameraRotationScript camerarotationscript;

    Vector3 playerPosition;
    Animator anim;
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        pickUpScript = GetComponentInChildren<PickUpScript>();
        rb = GetComponent<Rigidbody>();
        timerScript = portal.GetComponent<TimerScript>();
        sceneLoaderScript = portal.GetComponent<SceneLoaderScript>();
        walkingFX.SetActive(false);

    }

    void Update()
    {
        // Get the input for movement
        float moveInput = Input.GetAxis("Vertical");
        float strafeInput = Input.GetAxis("Horizontal");

        // Get the camera's forward and right vectors
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        // Remove the y component from the vectors to ensure the player stays grounded
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;

        // Calculate the movement direction based on the input and camera's orientation
        Vector3 moveDirection = (cameraForward * moveInput + cameraRight * strafeInput).normalized;

        if (canHeMove)
        {
            rb.MovePosition(rb.position + moveDirection * playerSpeed * Time.deltaTime);
        }

        if (isHolding)
        {
            playerSpeed = holdingSpeed;
        }

        // Update the player's rotation to face the movement direction
        if (moveDirection != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);
            rb.MoveRotation(newRotation);
        }

        isOnGround = Physics.CheckSphere(GroundChecker.position, groundDistance, groundMask);
        anim.SetBool("IsOnGround", isOnGround);

        if (moveInput != 0f || strafeInput != 0f)
        {
            anim.SetFloat("Speed", 2);
            isMoving = true;
        }
        else
        {
            anim.SetFloat("Speed", 0);
            isMoving = false;
            isDustPlaying = false;
        }

        if (isMoving && isOnGround)
        {
            walkingFX.SetActive(true);
        }
        else if(!isMoving || !isOnGround)
        {
            walkingFX.SetActive(false);
        }
        if(keyCount == 3)
        {
            onKeyPicked.Invoke();
        }
        anim.SetBool("IsHolding", isHolding);
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround && !isHolding)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                anim.SetBool("IsOnGround", isOnGround);
                AudioManager.Instance.PlayRandomSoundClip(jumpSoundClips, transform, 1f);
            }
        }
        if (isLasered)
        {
            PlayerRespawn(respawnPos, playerCamera, deathcause);
        }
        anim.transform.localPosition = Vector3.zero;
        anim.transform.localEulerAngles = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Elevator"))
        {
            isOnElevator = true;
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Elevator"))
        {
            isOnElevator = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Death")))
        {
            deathcause = other.gameObject.name;
            Debug.Log("player died by " + deathcause);
            PlayerRespawn(respawnPos, playerCamera, deathcause);
        }
        if (other.CompareTag("CheckPoint"))
        {
            zone = other.GetComponent<zonescript>();
            respawnPos = zone.CheckpointXYZ;
            respawnR = zone.CheckpointR;
            print("new checkpoint set - " + respawnPos);
        }
        if (other.CompareTag("StopMovement"))
        {
            Debug.Log("movement blocked...");
            canHeMove = false;
        }
        if (other.CompareTag("Portal"))
        {
            timerScript.StopTimer();
        }
        if (other.CompareTag("Key"))
        {
            Debug.Log("key picked up");
            AudioManager.Instance.PlaySoundClip(keySoundClip, transform, 1f);
            keyCount++;
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("RotationTrigger"))
        {
            Debug.Log("trigger found");
            cameraYRotation = playerCamera.transform.rotation.y;
            camerarotationscript = other.GetComponent<CameraRotationScript>();
            if(cameraYRotation != camerarotationscript.neededRotation)
            {
                Debug.Log("rotating camera at " + camerarotationscript.neededRotation + "degrees");
                playerCamera.transform.DORotate(new Vector3(35, camerarotationscript.neededRotation, 0), 0.5f);
            }
        }

        if (other.CompareTag("Secret"))
        {
            onSecretFound.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("StopMovement"))
        {
            Debug.Log("movement unblocked...");
            canHeMove = true;
        }
    }
    public void PlayerRespawn(Vector3 respawnPos, CinemachineVirtualCamera playerCamera, string deathcause)
    {
        AudioManager.Instance.PlaySoundClip(deathSoundClip, transform, 1f);
        onSecretLost.Invoke();
        onPlayerDeath.Invoke();
        pickUpScript.DropObject(pickUpScript.childObj);
        isLasered = false;
        print("player respawns, killed by " + deathcause);
        transform.position = respawnPos;
        print("respawned at - " + respawnPos + ", with rotation - " + respawnR);
        playerCamera.transform.rotation = Quaternion.Euler(35, respawnR, 0);
        WallPlayer.transform.rotation = Quaternion.Euler(0, respawnR + CameraRotation, 0);
    }

    void DustPlays()
    {
        if(!isDustPlaying)
        {
            Debug.Log("player particles starting...");
            dust.Play();
            isDustPlaying = true;
        }
    }
}