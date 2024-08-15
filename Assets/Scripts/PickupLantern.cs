using UnityEngine;

public class PickUpLantern : MonoBehaviour
{
    public Transform lanternHoldPoint;  // Ponto onde a lanterna será segurada
    public Camera playerCamera;  // Referência à câmera do jogador
    private GameObject lantern;  // Referência para a lanterna
    private bool hasLantern = false;  // Verifica se o jogador tem a lanterna
    public float pickUpRange = 2.0f;  // Alcance para pegar a lanterna

    void Start()
    {
        if (lanternHoldPoint == null)
        {
            Debug.LogError("Lantern Hold Point is not assigned in the Inspector!");
        }
        if (playerCamera == null)
        {
            Debug.LogError("Player Camera is not assigned in the Inspector!");
        }
    }

private Vector3 originalScale;  // Adicione essa variável no início da classe

void Update()
{
    if (Input.GetKeyDown(KeyCode.E) && !hasLantern)
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, pickUpRange))
        {
            if (hit.transform.CompareTag("Lantern"))
            {
                Debug.Log("Lantern detected: " + hit.transform.name);

                // Pegar a lanterna
                lantern = hit.transform.gameObject;

                // Armazenar a escala original da lanterna
                originalScale = lantern.transform.localScale;

                Debug.Log("Lantern original position: " + lantern.transform.position);

                // Mover a lanterna para o ponto de segurar
                lantern.transform.SetParent(lanternHoldPoint);

                // Definir a posição e a rotação locais da lanterna
                lantern.transform.localPosition = Vector3.zero;
                lantern.transform.localRotation = Quaternion.identity;

                // Manter a escala original da lanterna
                lantern.transform.localScale = originalScale;

                // Tornar a lanterna cinemática para evitar que a física a mova
                lantern.GetComponent<Rigidbody>().isKinematic = true;

                Debug.Log("Lantern new position: " + lantern.transform.position);
                Debug.Log("Lantern new scale: " + lantern.transform.localScale);

                hasLantern = true;
            }
            else
            {
                Debug.Log("Raycast hit: " + hit.transform.name + ", but it's not the lantern.");
            }
        }
        else
        {
            Debug.Log("Raycast didn't hit anything.");
        }
    }
}



}



