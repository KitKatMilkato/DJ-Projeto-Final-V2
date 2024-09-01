using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private bool isPlayerNearby = false; // Variável para verificar se o jogador está próximo

    public GameObject InstB; // Referência ao GameObject que será instanciado/destruído

    public bool Action = false; // Flag para ação

    // Método chamado quando o jogador entra na zona de trigger da caixa
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou no trigger tem a tag "Player"
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true; // Jogador está próximo
            InstB.SetActive(true); // Ativa a instrução
            Action = true; // Define a flag de ação como verdadeira
        }
    }

    // Método chamado quando o jogador sai da zona de trigger da caixa
    private void OnTriggerExit(Collider other)
    {
        // Verifica se o objeto que saiu do trigger tem a tag "Player"
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false; // Jogador não está mais próximo
            InstB.SetActive(false); // Desativa a instrução
            Action = false; // Define a flag de ação como falsa
        }
    }

    // Método Update chamado a cada frame
    void Update()
    {
        // Verifica se o jogador está próximo e se a tecla 'B' foi pressionada
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.B))
        {
            Destroy(gameObject); // Destrói a caixa
        }
    }
}
