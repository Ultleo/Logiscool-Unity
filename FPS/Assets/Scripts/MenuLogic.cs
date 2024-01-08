using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityStandardAssets.Characters.FirstPerson;

public class MenuLogic : MonoBehaviour
{
    public static bool IsGamePaused = false;
    public GameObject PauseUI;
    public FirstPersonController Controller;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused)
            {
                Resume();
            }
            
            else
            {
                Pause();
            }

            Controller.enabled = !IsGamePaused;
        }
    }

    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }

    public void Pause()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
    }

    public void LoadMenu()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}