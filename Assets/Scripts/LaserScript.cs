using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class LaserScript : MonoBehaviour
{
    public bool hasHit = false;
    private LineRenderer lr;
    public GameObject player;
    public Transform startingPoint;
    int rotateCount = 1;
    PlayerMovement playerMovement;
    ItemRespawnScript itemRespawnScript;
    MagicWallScript magicWallScript;

    private void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        lr = GetComponent<LineRenderer>();

    }
    private void Update()
    {
        Ray ray = new Ray(startingPoint.transform.position, startingPoint.transform.forward);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit))
        {
            lr.SetPosition(0, startingPoint.transform.position);
            lr.SetPosition(1, hit.point);
            lr.enabled = true;
            if (hit.collider)
            {
            }
            if (hit.transform.CompareTag("Player"))
            {
                Debug.Log("laser hit player");
                playerMovement.isLasered = true;
            }
            if (hit.transform.CompareTag("Pickable"))
            {
                Debug.Log("laser hit cube");
                hit.transform.SendMessage("HitByRay");
            }
            if (hit.transform.CompareTag("MagicWall"))
            {
                if (!hasHit)
                {
                    Animator anim = hit.transform.transform.GetComponent<Animator>();
                    anim.SetTrigger("WallHasBeenActivated");
                }
            }
        }
        Debug.DrawRay(ray.origin, ray.direction, Color.green);
    }
    public void Rotate()
    {
        transform.DORotate(new Vector3(0, transform.eulerAngles.y + 90, 0), 1f, RotateMode.Fast);
        if(rotateCount < 4)
        {
            rotateCount++;
        }
        if(rotateCount == 4)
        {
            rotateCount = 0;
        }
        Debug.Log(rotateCount);
    }
}