using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCscript : MonoBehaviour
{
    [HideInInspector]
    [SerializeField]
    public DialogueController dialogueScript;
    public GameObject dialogueController, GrabSlot;
    private void Start()
    {
        dialogueScript = dialogueController.GetComponent<DialogueController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == GrabSlot)
        {
            Debug.Log("dialogue can start");
            dialogueScript.dialogueCanStart = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == GrabSlot)
        {
            Debug.Log("dialogue can't start");
            dialogueScript.dialogueCanStart = false;
        }
    }
}
