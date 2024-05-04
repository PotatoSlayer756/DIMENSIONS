using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenu, settingMenu, resumeGame, masterSlider;
    public static bool isPaused = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            Debug.Log("esc");
            if (isPaused)
            {
                ResumeGame();
                SettingsClose();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(resumeGame, new BaseEventData(eventSystem));
        isPaused = true;
        Debug.Log("pausing");
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; 
        Debug.Log(eventSystem.firstSelectedGameObject.name);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Debug.Log("resuming");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SettingsOpen()
    {
        settingMenu.SetActive(true);
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(masterSlider, new BaseEventData(eventSystem));
        Debug.Log(eventSystem.firstSelectedGameObject.name);
        pauseMenu.SetActive(false);
    }

    public void SettingsClose()
    {
        settingMenu.SetActive(false);
        ResumeGame();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
