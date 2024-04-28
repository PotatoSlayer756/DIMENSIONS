using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialScript : MonoBehaviour
{
    public TextMeshProUGUI tutorialtext1, tutorialtext2, tutorialtext3, tutorialtext4, gateOpenText, secretFoundText, secretLostText;
    public float displayDuration = 1f; // Duration in seconds
    public float fadeDuration = 1f; // Duration in seconds
    bool isNotWall;

    private bool connected = false;

    IEnumerator CheckForControllers()
    {
        while (true)
        {
            var controllers = Input.GetJoystickNames();

            if (!connected && controllers.Length > 0)
            {
                connected = true;
                Debug.Log("Connected");

            }
            else if (connected && controllers.Length == 0)
            {
                connected = false;
                Debug.Log("Disconnected");
            }

            yield return new WaitForSeconds(1f);
        }
    }

    void Awake()
    {
        StartCoroutine(CheckForControllers());
    }

    void Start()
    {
        
    }
    private void Update()
    {
        isNotWall = gameObject.activeSelf;
    }
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.name == "TutorTrigger1")
        {
            tutorialtext1.gameObject.SetActive(true);
        }
        if (other.gameObject.name == "TutorTrigger2")
        {
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
        if (other.gameObject.name == "TutorTrigger2End")
        {
            StartCoroutine(FadeTextToZeroAlpha(tutorialtext2, 1.0f));
        }
        if (other.gameObject.name == "TutorTrigger3End")
        {
            StartCoroutine(FadeTextToZeroAlpha(tutorialtext3, 1.0f));
        }
        if (other.gameObject.name == "TutorTrigger4End")
        {
            StartCoroutine(FadeTextToZeroAlpha(tutorialtext4, 1.0f));
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "TutorTrigger1")
        {
            StartCoroutine(FadeTextToZeroAlpha(tutorialtext1, 1.0f));
        }
    }

    public void GateOpenedNotification()
    {
        StartCoroutine(FadeTextToZeroAlpha(gateOpenText, 3.0f));
    }

    public void SecretFoundNotification()
    {
        StartCoroutine(FadeTextToZeroAlpha(secretFoundText, 1.5f));
    }

    public void SecretLostNotification()
    {
        StartCoroutine(FadeTextToZeroAlpha(secretLostText, 1.5f));
        /*secretLostText.gameObject.SetActive(false);
        Color newColor = secretLostText.color;
        newColor.a = 255;
        secretLostText.color = newColor;*/
    }

    /*public void SecretFoundNotificationRestored()
    {
        Color NewColor = secretFoundText.color;
        NewColor.a = 255;
        secretFoundText.color = NewColor;
    }

    public void SecretLostNotificationRestored()
    {
        Color NewColor = secretLostText.color;
        NewColor.a = 255;
        secretLostText.color = NewColor;
    }*/

    public IEnumerator FadeTextToZeroAlpha(TextMeshProUGUI textToFade, float t)
    {
        Debug.Log("fading " + textToFade + "...");
        Color newColor = textToFade.color;
        while (textToFade.color.a > 0)
        {
            newColor.a -= Time.deltaTime / t;
            textToFade.color = newColor;
            yield return null;
        }
        textToFade.gameObject.SetActive(false);
        //newColor.a = 255;
        //textToFade.color = newColor;
    }
}
