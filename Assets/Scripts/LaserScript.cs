using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private LineRenderer lr;
    public Transform startingPoint;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        lr.SetPosition(0, startingPoint.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {

            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }
            if (hit.transform.CompareTag("Player"))
            {
                print("Playerkilled");
            }
            if (hit.transform.CompareTag("Pickable"))
            {
                Destroy(hit.transform.gameObject);
            }
        }
        else
        {
            lr.SetPosition(1, transform.forward * 5000);
        }
    }
}
