using UnityEngine;

public class TesteTutorial : MonoBehaviour
{
    [SerializeField] private GameObject tutorialPanel;

    void Start()
    {
        PlayerMove.OnTutorialTriggered += OpenTutorial;
        Time.timeScale = 1; // Garante que o tempo no jogo esteja normal quando a cena é carregada
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            CloseTutorial();
        }
    }

    void OnDestroy()
    {
        PlayerMove.OnTutorialTriggered -= OpenTutorial;
    }

    void OpenTutorial()
    {
        Debug.Log("Abrindo tutorial...");
        tutorialPanel.SetActive(true);
        Time.timeScale = 0; // Pausa o jogo quando o tutorial é aberto
    }

    // Função para fechar o tutorial (se necessário)
    public void CloseTutorial()
    {
        
        
            Debug.Log("Fechando o tutorial...");
            tutorialPanel.SetActive(false);
            Time.timeScale = 1; // Reseta o tempo no jogo quando o tutorial é fechado
        
        
    }

}
