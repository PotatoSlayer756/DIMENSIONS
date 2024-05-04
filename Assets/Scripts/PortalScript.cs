using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    int sceneindex;
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
        sceneindex = SceneManager.GetActiveScene().buildIndex;
        if (sceneindex >= PlayerPrefs.GetInt("MaxLevel", 0))
        {
            PlayerPrefs.SetInt("MaxLevel", sceneindex);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log(PlayerPrefs.GetInt("MaxLevel"));
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
