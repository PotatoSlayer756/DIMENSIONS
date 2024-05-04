using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialScript : MonoBehaviour
{
    public TextMeshProUGUI tutorialtext1, tutorialtext2, tutorialtext3, tutorialtext4, gateOpenText, secretFoundText, secretLostText;
    public RawImage tutorialtext1jbutton, tutorialtext2jbutton, tutorialtext3jbutton, tutorialtext4jbutton;
    public float displayDuration = 1f; // Duration in seconds
    public float fadeDuration = 1f; // Duration in seconds
    bool isNotWall;

    public bool isGamepadConnected;

    void Start()
    {
        string[] joystickNames = Input.GetJoystickNames();
        foreach (string joystickName in joystickNames)
        {
            if (!string.IsNullOrEmpty(joystickName))
            {
                isGamepadConnected = true;
                break;
            }
        }
        if (isGamepadConnected)
        {
            Debug.Log("i can see gamepad");
        }
        tutorialtext1jbutton.enabled = false;
        tutorialtext2jbutton.enabled = false;
        tutorialtext3jbutton.enabled = false;
        tutorialtext4jbutton.enabled = false;

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
            Debug.Log(isGamepadConnected);

            if (isGamepadConnected)
            {
                tutorialtext1jbutton.enabled = true;
            }
            else
            {
                tutorialtext1jbutton.enabled = false;
            }
        }
        if (other.gameObject.name == "TutorTrigger2")
        {
            tutorialtext2.gameObject.SetActive(true);
            Debug.Log(isGamepadConnected);

            if (isGamepadConnected)
            {
                tutorialtext2jbutton.enabled = true;
            }
            else
            {
                tutorialtext2jbutton.enabled = false;
            }
        }
        if (other.gameObject.name == "TutorTrigger3")
        {
            tutorialtext3.gameObject.SetActive(true);
            Debug.Log(isGamepadConnected);
            if (isGamepadConnected)
            {
                tutorialtext3jbutton.enabled = true;
            }
            else
            {
                tutorialtext3jbutton.enabled = false;
            }

        }
        if (other.gameObject.name == "TutorTrigger4")
        {
            tutorialtext4.gameObject.SetActive(true);
            Debug.Log(isGamepadConnected);
            if (isGamepadConnected)
            {
                tutorialtext4jbutton.enabled = true;
            }
            else
            {
                tutorialtext4jbutton.enabled = false;
            }
        }
        if (other.gameObject.name == "TutorTrigger2End")
        {
            StartCoroutine(FadeTextToZeroAlpha(tutorialtext2, 1.0f));
            if(isGamepadConnected)
            {
                StartCoroutine(FadeButtonToZeroAlpha(tutorialtext2jbutton, 1.0f));
            }

        }
        if (other.gameObject.name == "TutorTrigger3End")
        {
            StartCoroutine(FadeTextToZeroAlpha(tutorialtext3, 1.0f));
            if (isGamepadConnected)
            {
                StartCoroutine(FadeButtonToZeroAlpha(tutorialtext3jbutton, 1.0f));
            }

        }
        if (other.gameObject.name == "TutorTrigger4End")
        {
            StartCoroutine(FadeTextToZeroAlpha(tutorialtext4, 1.0f));
            if (isGamepadConnected)
            {
                StartCoroutine(FadeButtonToZeroAlpha(tutorialtext4jbutton, 1.0f));
            }

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "TutorTrigger1")
        {
            StartCoroutine(FadeTextToZeroAlpha(tutorialtext1, 1.0f));
            if (isGamepadConnected)
            {
                StartCoroutine(FadeButtonToZeroAlpha(tutorialtext1jbutton, 1.0f));
            }
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
        //newColor.a = 255;
        //textToFade.color = newColor;
    }
    public IEnumerator FadeButtonToZeroAlpha(RawImage buttonToFade, float t)
    {
        Debug.Log("fading " + buttonToFade + "...");
        Color newColor = buttonToFade.color;
        while (buttonToFade.color.a > 0)
        {
            newColor.a -= Time.deltaTime / t;
            buttonToFade.color = newColor;
            yield return null;
        }
        //newColor.a = 255;
        //textToFade.color = newColor;
    }
}
