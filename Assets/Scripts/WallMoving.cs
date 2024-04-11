using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class WallMoving : MonoBehaviour
{
    public float playerSpeed = 5f, minX, maxX;

    public GameObject leftRaycast, rightRaycast;
    public DecalProjector projector;
    Animator projectoranim;
    Transform projectorparent;
    Vector3 projectorScale;
    void Start()
    {
        projectorparent = projector.transform.parent;
        projector.transform.parent = null;
        projectorScale = transform.localScale;
        Debug.Log(projectorScale);
        projectoranim = projector.GetComponent<Animator>();
        projector.transform.parent = projectorparent;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = transform.right * horizontalInput * playerSpeed * Time.deltaTime;
        transform.position += movement;

        if(horizontalInput > 0)
        {
            projectoranim.SetBool("isWallMoving", true);
            leftRaycast.gameObject.SetActive(false);
            rightRaycast.gameObject.SetActive(true);
            projector.transform.localScale = new Vector3(projectorScale.x, projectorScale.y / (float)2.5, projectorScale.z);
        }
        if (horizontalInput < 0)
        {
            projectoranim.SetBool("isWallMoving", true);
            leftRaycast.gameObject.SetActive(true);
            rightRaycast.gameObject.SetActive(false);
            projector.transform.localScale = new Vector3(-projectorScale.x, projectorScale.y / (float)2.5, projectorScale.z);
        }
        if (horizontalInput == 0)
        {
            leftRaycast.gameObject.SetActive(false);
            rightRaycast.gameObject.SetActive(false);
            projectoranim.SetBool("isWallMoving", false);
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
