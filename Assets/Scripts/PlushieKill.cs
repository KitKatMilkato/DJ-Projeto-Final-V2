using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KillOnKeyPress : MonoBehaviour
{
    [SerializeField] private KeyCode killKey = KeyCode.R; // A tecla que ativa a ação foi alterada para 'R'
    [SerializeField] private string gameOverSceneName = "GameOver"; // Nome da cena de Game Over
    [SerializeField] private AudioSource audioSource; // Referência ao AudioSource para tocar o áudio
    [SerializeField] private Image transitionImage; // Imagem para a transição de tela
    [SerializeField] private float transitionDuration = 1f; // Duração da transição (em segundos)

    public GameObject InstrucaoK;
    public bool Action = false;
    public bool isPlayerInside = false; // Variável para verificar se o jogador está dentro do Collider

    void Update()
    {
        // Verifica se a tecla 'R' foi pressionada e se o jogador está dentro do Collider
        if (Input.GetKeyDown(KeyCode.R) && isPlayerInside)
        {
            PlaySound();
            StartCoroutine(KillPlayerWithTransition()); // Inicia a corrotina com transição
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            InstrucaoK.SetActive(true);
            Action = true;
            isPlayerInside = true; // Define que o jogador está dentro do Collider
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            InstrucaoK.SetActive(false);
            Action = false;
            isPlayerInside = false; // Define que o jogador saiu do Collider
        }
    }

    private void PlaySound()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play(); // Toca o áudio
            Debug.Log("Áudio tocado!");
        }
        else
        {
            Debug.LogWarning("AudioSource não configurado ou já está tocando.");
        }
    }

    private IEnumerator KillPlayerWithTransition()
    {
        Debug.Log("Iniciando a transição...");
        if (transitionImage != null)
        {
            transitionImage.gameObject.SetActive(true); // Torna a imagem visível
            Color color = transitionImage.color;
            float elapsedTime = 0f;

            // Gradualmente aumenta a opacidade da imagem
            while (elapsedTime < transitionDuration)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Clamp01(elapsedTime / transitionDuration);
                color.a = alpha;
                transitionImage.color = color;
                yield return null;
            }
        }

        // Espera por mais 2 segundos
        yield return new WaitForSeconds(2);

        // Verifica se o nome da cena não está vazio e carrega a cena
        if (!string.IsNullOrEmpty(gameOverSceneName))
        {
            SceneManager.LoadScene(gameOverSceneName);
            Debug.Log("Cena de Game Over carregada.");
        }
        else
        {
            Debug.LogError("Nome da cena de Game Over não configurado.");
        }
    }
}
