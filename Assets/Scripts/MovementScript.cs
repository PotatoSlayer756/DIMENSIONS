using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5f;
    public float jumpForce = 5.0f;
    public bool isOnGround = true;

    public Rigidbody rb;

    Vector3 playerPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        print(collision.gameObject);
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Death")) || (other.CompareTag("Portal")))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}