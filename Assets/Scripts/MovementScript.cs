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

    public Rigidbody rb;
    public GameObject PanelMenu, portal;

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

        playerPosition.x = Input.GetAxis("Horizontal");
        playerPosition.z = Input.GetAxis("Vertical");

        rb.MovePosition(rb.position + playerPosition * playerSpeed * Time.deltaTime);

        if (playerPosition != Vector3.zero)
        {
            transform.forward = playerPosition;
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
            sceneLoaderScript.ReloadScene();
        }
        if (other.CompareTag("Portal"))
        {
            timerScript.StopTimer();
            PanelMenu.SetActive(true);
            gameObject.SetActive(false);
        }

    }
}