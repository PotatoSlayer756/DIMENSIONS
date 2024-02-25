using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public GameObject Fade;
    TimerScript timerScript;
    Animator fadeAnim;
    LevelFadingScript levelFadingScript;

    private void Start()
    {
        fadeAnim = Fade.GetComponent<Animator>();
        timerScript = gameObject.GetComponent<TimerScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timerScript.StopTimer();
            fadeAnim.SetTrigger("FadeOut");
        }
    }

}
