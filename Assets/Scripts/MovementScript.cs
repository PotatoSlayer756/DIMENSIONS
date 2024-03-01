using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5f;
    public float jumpForce = 5.0f;
    public bool isOnGround = true, isHolding = false, isLasered = false;
    public int keyCount = 0, CameraRotation;

    public Rigidbody rb;
    public GameObject portal;
    public Vector3 respawnPos;
    public float respawnR;
    public CinemachineVirtualCamera playerCamera;
    public GameObject WallPlayer;

    private zonescript zone;
    private PickUpScript pickUpScript;
    private TimerScript timerScript;
    private SceneLoaderScript sceneLoaderScript;

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

        // Move the player in the calculated direction
        rb.MovePosition(rb.position + moveDirection * playerSpeed * Time.deltaTime);

        // Update the player's rotation to face the movement direction
        if (moveDirection != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);
            rb.MoveRotation(newRotation);
        }

        if (moveInput != 0f || strafeInput != 0f)
        {
            anim.SetFloat("Speed", 2);
        }
        else
        {
            anim.SetFloat("Speed", 0);
            anim.SetBool("IsHolding", isHolding);
            // Let the player jump       
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                anim.SetBool("IsOnGround", isOnGround);
            }
        }
        if (isLasered)
        {
            PlayerRespawn(respawnPos, playerCamera);
        }
        anim.transform.localPosition = Vector3.zero;
        anim.transform.localEulerAngles = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            anim.SetBool("IsOnGround", isOnGround);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Death")))
        {
            PlayerRespawn(respawnPos, playerCamera);

        }
        if (other.CompareTag("CheckPoint"))
        {
            zone = other.GetComponent<zonescript>();
            respawnPos = zone.CheckpointXYZ;
            respawnR = zone.CheckpointR;
            print("new checkpoint set - " + respawnPos);
        }
        if (other.CompareTag("Portal"))
        {
            timerScript.StopTimer();
        }
        if (other.CompareTag("Key"))
        {
            keyCount++;
            other.gameObject.SetActive(false);
        }
    }
    public void PlayerRespawn(Vector3 respawnPos, CinemachineVirtualCamera playerCamera)
    {
        pickUpScript.DropObject(pickUpScript.childObj);
        isLasered = false;
        print("player respawns");
        transform.position = respawnPos;
        print("respawned at - " + respawnPos + ", with rotation - " + respawnR);
        playerCamera.transform.rotation = Quaternion.Euler(35, respawnR, 0);
        WallPlayer.transform.rotation = Quaternion.Euler(0, respawnR + CameraRotation, 0); //баг 003
    }

}