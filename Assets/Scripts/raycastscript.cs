using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class raycastscript : MonoBehaviour
{
    public float eee = 0f;
    public float rayDistance;

    void Start()
    {
        
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.gameObject.CompareTag("Wall"))
            {
                Vector3 normal = hit.normal;
                if (Input.GetKeyDown(KeyCode.X))
                {
                    Debug.Log("The normal of the surface hit is: " + normal);
                    Debug.Log("Hit object: " + hit.collider.gameObject.name);
                }
                transform.parent.rotation = Quaternion.LookRotation(hit.normal, Vector3.up) * Quaternion.Euler(0, eee, 0);
            }
        }
        Debug.DrawRay(ray.origin, ray.direction, Color.green);
    }
}
