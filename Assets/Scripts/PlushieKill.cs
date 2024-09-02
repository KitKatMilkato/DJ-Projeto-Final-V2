using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KillOnKeyPress : MonoBehaviour
{
    [SerializeField] private KeyCode killKey = KeyCode.E; // A tecla que ativa a ação foi alterada para 'E'
    [SerializeField] private string gameOverSceneName = "GameOverScene"; // Nome da cena de Game Over
    [SerializeField] private AudioSource audioSource; // Referência ao AudioSource para tocar o áudio
    [SerializeField] private Image transitionImage; // Imagem para a transição de tela
    [SerializeField] private float transitionDuration = 1f; // Duração da transição (em segundos)

    public GameObject InstrucaoK;

    public bool Action = false;

    void Update()
    {
        // Verifica se a tecla 'E' foi pressionada
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlaySound();
            StartCoroutine(KillPlayerWithTransition()); // Inicia a corrotina com transição
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            InstrucaoK.SetActive(true);
            Action = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        InstrucaoK.SetActive(false);
        Action = false;
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