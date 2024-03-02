using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCscript : MonoBehaviour
{
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
            dialogueScript.dialogueCanStart = true;
        }
    }
}
