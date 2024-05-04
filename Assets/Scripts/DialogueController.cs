using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.Events;

public class DialogueController : MonoBehaviour
{
    public TMP_Text dialogueText;
    public string[] sentences;
    private int index;
    public float dialogueSpeed;
    public UnityEvent onDialogueEnd;
    [HideInInspector]
    public bool dialogueCanStart = false;
    public RawImage dialogueWindow;
    [SerializeField] private AudioClip npcSoundClip;
    bool isWriting = false;

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
            else if (isWriting)
            {
                StopCoroutine(WriteSentence());
                dialogueText.text = sentences[index];
                isWriting = false;
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
        dialogueText.text = "";
        if (index <= sentences.Length - 1 && isWriting)
        {
            Debug.Log("skipping to full sentence");
            StopAllCoroutines();
            dialogueText.text = sentences[index].ToString();
            isWriting = false;
            index++;
        }
        else if (index <= sentences.Length - 1 && !isWriting)
        {
            Debug.Log("writing a sentence");
            isWriting = true;
            StartCoroutine(WriteSentence());
        }
        else
        {
            Debug.Log("finishing dialogue");
            dialogueWindow.gameObject.SetActive(false);
            index = 0;
            onDialogueEnd.Invoke();
        }
    }

    IEnumerator WriteSentence()
    {
        foreach (char Character in sentences[index].ToCharArray())
        {
            dialogueText.text += Character;
            AudioManager.Instance.PlaySoundClip(npcSoundClip, transform, 1f);
            yield return new WaitForSeconds(dialogueSpeed);
        }
        index++;
        isWriting = false;
    }
}
