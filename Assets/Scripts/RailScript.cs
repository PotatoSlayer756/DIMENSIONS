using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class RailScript : MonoBehaviour
{
    List<GameObject> children = new List<GameObject>();
    public GameObject[] points;
    public GameObject moveable;
    Rigidbody rb;
    ItemRespawnScript itemReScript;
    public int pointCount, startingPoint;
    public float speed, upper;
    public bool goesForward = true, isConnected = true;

    [SerializeField] private AudioClip railSoundClip;

    private void Awake()
    {
        FindAllChildren();
        moveable.transform.parent = this.gameObject.transform;
        rb = moveable.GetComponent<Rigidbody>();    
        rb.isKinematic = true;
        moveable.transform.DOMove(new Vector3(points[startingPoint].transform.position.x, points[startingPoint].transform.position.y + upper, points[startingPoint].transform.position.z), 0.1f);
        if(moveable.GetComponent<ItemRespawnScript>() != null )
        {
            itemReScript = moveable.GetComponent<ItemRespawnScript>();
            itemReScript.isConnected = true;
        }
    }

    private void FindAllChildren()
    {
        Transform[] childrenTransform = GetComponentsInChildren<Transform>();
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            if (child != null && child.gameObject != null && child.childCount == 1)
            {
                children.Add(child.gameObject);
            }
        }
        pointCount = children.Count;
        points = new GameObject[pointCount];
        int i = 0;
        foreach (GameObject child in children)
        {
            points[i] = child;

            i++;
        }
    }
    private void Update()
    {
        if (moveable.GetComponent<ItemRespawnScript>() != null)
        {
            isConnected = itemReScript.isConnected;
        }
        /*if (Input.GetKeyDown(KeyCode.Z))
        {
            
            {
                Debug.Log("point " + startingPoint);
                MoveObject();
            }
        }*/
    }
    public void MoveObject()
    {
        if (isConnected)
        {
            if (startingPoint == points.Length - 1)
            {
                goesForward = false;
            }
            else if (startingPoint == 0)
            {
                goesForward = true;
            }
            if (goesForward)
            {
                Debug.Log("rail goes forward");
                startingPoint++;
            }
            else if (!goesForward)
            {
                Debug.Log("rail goes back");
                startingPoint--;
            }
            AudioManager.Instance.PlaySoundClip(railSoundClip, transform, 1f);
            moveable.transform.DOMove(new Vector3(points[startingPoint].transform.position.x, points[startingPoint].transform.position.y + upper, points[startingPoint].transform.position.z), 1f);
        }
    }
}
