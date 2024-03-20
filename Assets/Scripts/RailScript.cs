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
    public int pointCount, startingPoint;
    public bool goesForward = true;

    private void Awake()
    {
        FindAllChildren();
        moveable.transform.parent = this.gameObject.transform;
        moveable.transform.DOMove(new Vector3(points[startingPoint].transform.position.x, points[startingPoint].transform.position.y, points[startingPoint].transform.position.z), 0.1f);
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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("point " + startingPoint);
            MoveObject();
        }
    }
    public void MoveObject()
    {
        
        if(startingPoint == points.Length - 1)
        {
            goesForward = false;
        }
        else if(startingPoint == 0)
        {
            goesForward = true;
        }
        if (goesForward)
        {
            Debug.Log("rail goes forward");
            startingPoint++;
        }
        else if(!goesForward)
        {
            Debug.Log("rail goes back");
            startingPoint--;
        }
        moveable.transform.DOMove(new Vector3(points[startingPoint].transform.position.x, points[startingPoint].transform.position.y, points[startingPoint].transform.position.z), 1f);
    }
}
