using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class DialogueController : MonoBehaviour
{
    public TMP_Text dialogueText;
    public string[] sentences;
    private int index;
    public float dialogueSpeed;
    [HideInInspector]
    public bool dialogueCanStart = false;
    public RawImage dialogueWindow;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button1) && dialogueCanStart)
        {
            if (dialogueCanStart)
            {
                Debug.Log("dialogue started");
                NextSentence();
            }
        }
        else
        {

        }
        if (!dialogueCanStart)
        {
            dialogueWindow.gameObject.SetActive(false);
            index = 0;
        }
    }
    public void NextSentence()
    {
        dialogueWindow.gameObject.SetActive(true);
        if (index <= sentences.Length - 1)
        {
            dialogueText.text = "";
            StartCoroutine(WriteSentence());
        }
        else
        {
            dialogueText.text = "";
            dialogueWindow.gameObject.SetActive(false);
            index = 0;
        }
    }

    IEnumerator WriteSentence()
    {
        foreach (char Character in sentences[index].ToCharArray())
        {
            dialogueText.text += Character;
            yield return new WaitForSeconds(dialogueSpeed);
        }
        index++;    
    }
}
