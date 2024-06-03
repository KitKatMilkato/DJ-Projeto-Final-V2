using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private string NomeLevelDoJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void jogar()
    {
        SceneManager.LoadScene("PlayerMove");
    }

    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }
    public void FecharOpcoes()
    {

        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }
    public void Exit()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();
    }
}
