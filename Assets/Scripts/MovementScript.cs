using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5f;
    public float jumpForce = 5.0f;
    public bool isOnGround = true;
    public int keyCount = 0;

    public Rigidbody rb;
    public GameObject PanelMenu, portal;
    public Vector3 respawnPos;
    public CinemachineVirtualCamera playerCamera;

    private zonescript zone;
    private TimerScript timerScript;
    private SceneLoaderScript sceneLoaderScript;

    Vector3 playerPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        timerScript = portal.GetComponent<TimerScript>();
        sceneLoaderScript = portal.GetComponent<SceneLoaderScript>();
        PanelMenu.SetActive(false);

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

        // Let the player jump 
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Death")))
        {
            print("player respawns");
            transform.position = respawnPos;
            playerCamera.transform.eulerAngles = new Vector3(playerCamera.transform.eulerAngles.x, 0f, playerCamera.transform.eulerAngles.z);

        }
        if (other.CompareTag("CheckPoint"))
        {
            zone = other.GetComponent<zonescript>();
            respawnPos = zone.CheckpointXYZ;
        }
        if (other.CompareTag("Portal"))
        {
            timerScript.StopTimer();
            PanelMenu.SetActive(true);
            gameObject.SetActive(false);
        }
        if (other.CompareTag("Key"))
        {
            keyCount++;
            other.gameObject.SetActive(false);
        }
    }
}