using UnityEngine;

public class PickUpWalkieTalkie : MonoBehaviour
{
    public Transform walkieHoldPoint; // O ponto onde o walkie-talkie será segurado
    public Camera playerCamera; // A câmera do jogador
    public float pickUpRange = 3f; // A distância máxima para pegar o walkie-talkie
    private GameObject walkieTalkie; // Referência ao walkie-talkie
    private bool hasWalkieTalkie = false; // Se o jogador já pegou o walkie-talkie

    void Update()
    {
        // Detecta se o jogador pressiona a tecla E
        if (Input.GetKeyDown(KeyCode.E) && !hasWalkieTalkie)
        {
            RaycastHit hit;
            // Lança um Raycast a partir da câmera do jogador
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, pickUpRange))
            {
                // Verifica se o Raycast atingiu o walkie-talkie
                if (hit.transform.CompareTag("WalkieTalkie"))
                {
                    Debug.Log("Walkie-Talkie detected: " + hit.transform.name);

                    // Pegar o walkie-talkie
                    walkieTalkie = hit.transform.gameObject;

                    // Mover o walkie-talkie para o ponto de segurar
                    walkieTalkie.transform.SetParent(walkieHoldPoint);

                    // Definir a posição e rotação locais
                    walkieTalkie.transform.localPosition = Vector3.zero;
                    walkieTalkie.transform.localRotation = Quaternion.identity;

                    // Manter a escala original do walkie-talkie
                    walkieTalkie.transform.localScale = walkieTalkie.transform.localScale;

                    // Tornar o walkie-talkie cinemático
                    walkieTalkie.GetComponent<Rigidbody>().isKinematic = true;

                    hasWalkieTalkie = true;
                    
                    // Ativar funcionalidades do walkie-talkie (como receber mensagens)
                    EnableWalkieTalkieMessages();
                }
                else
                {
                    Debug.Log("Raycast hit: " + hit.transform.name + ", but it's not the walkie-talkie.");
                }
            }
            else
            {
                Debug.Log("Raycast didn't hit anything.");
            }
        }
    }

    void EnableWalkieTalkieMessages()
    {
        Debug.Log("Walkie-Talkie picked up, you can now receive messages.");
        // Aqui você pode ativar scripts ou funcionalidades que permitirão ao jogador receber mensagens
    }
}

