using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Pausepanel;

    // Update is called once per frame
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
