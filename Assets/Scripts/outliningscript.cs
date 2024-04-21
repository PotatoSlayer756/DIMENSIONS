using Knife.HDRPOutline.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outliningscript : MonoBehaviour
{
    OutlineObject outline;
    public GameObject grabslot;
    public Color outlineColor;

    void Start()
    {
        outline = GetComponent<OutlineObject>();
        outline.Color = new Color(0f, 0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == grabslot)
        {
            Debug.Log("setting outline");
            outline.Color = outlineColor;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == grabslot)
        {
            outline.Color = new Color(0f, 0f, 0f, 0f);
        }
    }
}
