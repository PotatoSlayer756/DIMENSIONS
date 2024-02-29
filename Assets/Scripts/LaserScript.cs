using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public List<GameObject> desiredList;
    public bool hasHit = false;
    int listIndex = 0;
    private LineRenderer lr;
    private List<GameObject> objectList;
    public GameObject player;
    public Transform startingPoint;
    PlayerMovement playerMovement;
    ItemRespawnScript itemRespawnScript;

    private void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        lr = GetComponent<LineRenderer>();
        Debug.Log(desiredList.Count);
    }
    private void Update()
    {
        lr.SetPosition(0, startingPoint.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (!hasHit)
            {
                if (hit.collider)
                {
                    lr.SetPosition(1, hit.point);
                    hasHit = true;
                }
                if (hit.transform.CompareTag("Player"))
                {
                    playerMovement.isLasered = true;
                    hasHit = true;
                }
                if (hit.transform.CompareTag("Pickable"))
                {
                    hit.transform.SendMessage("HitByRay");
                    hasHit = true;
                }
                if (hit.transform.CompareTag("MagicWall"))
                {
                    if(listIndex < desiredList.Count)
                    {
                        Debug.Log("hitted magic wall");
                        if (hit.transform.gameObject == desiredList[listIndex])
                        {
                            Debug.Log("hitted needed magic wall");
                            listIndex++;
                            hasHit = true;
                        }
                        else
                        {
                            Debug.Log("hitted useless magic wall");
                            listIndex = 0;
                            hasHit = true;
                        }
                    }
                }
                if (listIndex == desiredList.Count)
                {
                    foreach (GameObject go in desiredList)
                    {
                        Animator animator = go.GetComponent<Animator>();
                        animator.SetTrigger("WallHasBeenActivated");
                        hasHit = true;
                    }  
                }
            }
        }
        else
        {
            hasHit = false;
            lr.SetPosition(1, transform.forward * 5000);
        }
    }
}