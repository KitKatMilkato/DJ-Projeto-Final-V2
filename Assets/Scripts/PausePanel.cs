using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public GameObject Pausepanel;

    void Update()
    {
        
    }

    public void Pause()
    {
        Pausepanel.SetActive(true);
        Time.timeScale = 0;

    }

    public void Continue()
    {
        Pausepanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Home()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
