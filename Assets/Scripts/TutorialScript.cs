using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public Text tutorialtext1, tutorialtext2, tutorialtext3, tutorialtext4;
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
            StartCoroutine(FadeOutText(tutorialtext1));
        }
        if (other.gameObject.name == "TutorTrigger2")
        {
            StartCoroutine(FadeOutText(tutorialtext2));
        }
        if (other.gameObject.name == "TutorTrigger3")
        {
            StartCoroutine(FadeOutText(tutorialtext3));
        }
        if (other.gameObject.name == "TutorTrigger4")
        {
            StartCoroutine(FadeOutText(tutorialtext4));
        }
    }
    IEnumerator FadeOutText(Text tutorialtext)
    {
        // Get the initial color of the text
        Color textColor = tutorialtext.color;

        // Gradually reduce the text's alpha value over the fade duration
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            textColor.a = alpha;
            tutorialtext.color = textColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // Hide the text
        tutorialtext.enabled = false;
    }
}
