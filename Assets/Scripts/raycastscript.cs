using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class raycastscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 normal = hit.normal;
            Debug.Log("The normal of the surface hit is: " + normal);
            Debug.Log("Hit object: " + hit.collider.gameObject.name);
            transform.rotation = Quaternion.LookRotation(hit.transform.forward, Vector3.up); ;
        }
        Debug.DrawRay(ray.origin, ray.direction, Color.green);
    }
}