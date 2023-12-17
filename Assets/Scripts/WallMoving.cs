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
        float moveX = Input.GetAxis("Horizontal");
        float clampedX = Mathf.Clamp(transform.position.x + moveX * playerSpeed * Time.deltaTime, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

    }
}
