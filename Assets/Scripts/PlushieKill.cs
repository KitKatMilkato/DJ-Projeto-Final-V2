using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillOnKeyPress : MonoBehaviour
{
    [SerializeField] private KeyCode killKey = KeyCode.K; // A tecla que mata o jogador
    [SerializeField] private string gameOverSceneName = "GameOverScene"; // Nome da cena de Game Over

    void Update()
    {
        if (Input.GetKeyDown(killKey))
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        // Carrega a cena de Game Over
        SceneManager.LoadScene(gameOverSceneName);
        Debug.Log("Jogador foi morto! Cena de Game Over carregada.");
    }
}
