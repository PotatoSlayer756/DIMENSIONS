using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoving : MonoBehaviour
{
    public float playerSpeed = 5f, minX, maxX;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = -transform.right * horizontalInput * playerSpeed * Time.deltaTime;
        transform.position += movement;

    }
}
