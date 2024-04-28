using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public GameObject Fade;
    //public bool isDebugOn;
    TimerScript timerScript;
    Animator fadeAnim;
    LevelFadingScript levelFadingScript;

    [SerializeField] private AudioClip nextLevelSoundClip;
    //public GameObject debugMenu;

    private void Start()
    {
        Time.timeScale = 1f;
        //debugMenu.SetActive(false);
        fadeAnim = Fade.GetComponent<Animator>();
        timerScript = gameObject.GetComponent<TimerScript>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            // Toggle the state of isDebugOn before updating the active status of debugMenu
            //isDebugOn = !isDebugOn;

            // Update the active status of debugMenu based on the new state of isDebugOn
            //debugMenu.SetActive(isDebugOn);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timerScript.StopTimer();
            AudioManager.Instance.PlaySoundClip(nextLevelSoundClip, transform, 1f);
            fadeAnim.SetTrigger("FadeOut");
            Time.timeScale = 0.5f;
        }
    }
    public void LoadLevel0()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene(4);
    }
}
