using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialScript : MonoBehaviour
{
    public TextMeshProUGUI tutorialtext1, tutorialtext2, tutorialtext3, tutorialtext4;
    public float displayDuration = 1f; // Duration in seconds
    public float fadeDuration = 1f; // Duration in seconds

    void Start()
    {

    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.name == "TutorTrigger1")
        {
            tutorialtext1.gameObject.SetActive(true);
        }
        if (other.gameObject.name == "TutorTrigger2")
        {
            print("aaeee");
            tutorialtext2.gameObject.SetActive(true);
        }
        if (other.gameObject.name == "TutorTrigger3")
        {
            tutorialtext3.gameObject.SetActive(true);
        }
        if (other.gameObject.name == "TutorTrigger4")
        {
            tutorialtext4.gameObject.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "TutorTrigger1")
        {
            StartCoroutine(FadeTextToZeroAlpha(tutorialtext1, 1.0f));
        }
        if (other.gameObject.name == "TutorTrigger2")
        {
            StartCoroutine(FadeTextToZeroAlpha(tutorialtext2, 1.0f));
        }
        if (other.gameObject.name == "TutorTrigger3")
        {
            StartCoroutine(FadeTextToZeroAlpha(tutorialtext3, 1.0f));
        }
        if (other.gameObject.name == "TutorTrigger4")
        {
            StartCoroutine(FadeTextToZeroAlpha(tutorialtext4, 1.0f));
        }
    }
    public IEnumerator FadeTextToZeroAlpha(TextMeshProUGUI textToFade, float t)
    {
        Color newColor = textToFade.color;
        while (textToFade.color.a > 0)
        {
            newColor.a -= Time.deltaTime / t;
            textToFade.color = newColor;
            yield return null;
        }
    }
}
