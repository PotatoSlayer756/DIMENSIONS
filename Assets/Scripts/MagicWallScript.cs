using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWallScript : MonoBehaviour
{
    [HideInInspector]
    [SerializeField]
    public int index = 0;
    public List<GameObject> hitList;
    public GameObject activatingObject;
    ActivatingObjectScript activatingObjectScript;
    Animator anim;
    bool puzzleActivated = false;
    void Start()
    {
        activatingObjectScript = activatingObject.GetComponent<ActivatingObjectScript>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject go in hitList)
        {
            anim = go.GetComponent<Animator>();
            bool isTriggerSet = anim.GetBool("WallHasBeenActivated");
            if (isTriggerSet)
            {
                index++;
            }
        }
        if(index == hitList.Count)
        {
            puzzleActivated = true;
        }
        else
        {
            index = 0;
        }
        if(puzzleActivated == true)
        {
            Debug.Log(puzzleActivated);
            activatingObjectScript.Activated();
            gameObject.GetComponent<MagicWallScript>().enabled = false;
        }
        
    }
}
