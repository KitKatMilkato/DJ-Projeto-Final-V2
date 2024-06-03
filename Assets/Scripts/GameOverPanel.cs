using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public GameObject GameOverpanel;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void GameOver()
    {
        GameOverpanel.SetActive(true);
        Time.timeScale = 0;

    }

    public void Restart()
    {
        SceneManager.LoadScene("PlayerMove");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("NewMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
