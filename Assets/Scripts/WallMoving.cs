using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoving : MonoBehaviour
{
    public float playerSpeed = 5f, minX, maxX;

    public GameObject leftRaycast, rightRaycast;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = transform.right * horizontalInput * playerSpeed * Time.deltaTime;
        transform.position += movement;

        if(horizontalInput > 0)
        {
            leftRaycast.gameObject.SetActive(false);
            rightRaycast.gameObject.SetActive(true);

        }
        if (horizontalInput < 0)
        {
            leftRaycast.gameObject.SetActive(true);
            rightRaycast.gameObject.SetActive(false);
        }
        if (horizontalInput == 0)
        {
            leftRaycast.gameObject.SetActive(false);
            rightRaycast.gameObject.SetActive(false);

        }
        // Check if player object is within range
        if (transform.position.x < minX)
        {
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > maxX)
        {
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        }
    }
}
