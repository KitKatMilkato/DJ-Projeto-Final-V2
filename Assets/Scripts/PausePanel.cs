using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public GameObject PausePanelUI;
    public static bool GamePaused = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Continue();
            }
            else
            {
                Paused();
            }
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Home();
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            QuitGame();
        }


    }

    public void Continue()
    {
        PausePanelUI.SetActive(false);
        Time.timeScale = 1;
        GamePaused = false;
    }

    public void Paused()
    {
        PausePanelUI.SetActive(true);
        Time.timeScale = 0;
        GamePaused = true;
    }


    public void Home()
    {

        SceneManager.LoadScene("NewMenu");
    }

    public void QuitGame()
    {

        Application.Quit();
    }
}
