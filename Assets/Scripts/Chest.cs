using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private bool isPlayerNearby = false; // Variável para verificar se o jogador está próximo

    // Método chamado quando o jogador entra na zona de trigger da caixa
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou no trigger tem a tag "Player"
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true; // Jogador está próximo
        }
    }

    // Método chamado quando o jogador sai da zona de trigger da caixa
    private void OnTriggerExit(Collider other)
    {
        // Verifica se o objeto que saiu do trigger tem a tag "Player"
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false; // Jogador não está mais próximo
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
