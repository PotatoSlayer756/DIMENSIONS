using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Place this code in the Update method of object 2
        float rotationSpeed = 10f; // Adjust this value to change the rotation speed
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
