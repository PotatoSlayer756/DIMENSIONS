using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenu, settingMenu;
    public static bool isPaused = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
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
        isPaused = true;
        Debug.Log("pausing");
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
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
