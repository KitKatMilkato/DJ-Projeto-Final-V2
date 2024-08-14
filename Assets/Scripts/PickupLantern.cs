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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !hasLantern)
        {
            RaycastHit hit;
            // Lançar o Raycast a partir da câmera na direção para onde ela está olhando
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, pickUpRange))
            {
                if (hit.transform.CompareTag("Lantern"))
                {
                    // Pegar a lanterna
                    lantern = hit.transform.gameObject;
                    lantern.transform.SetParent(lanternHoldPoint);
                    lantern.transform.localPosition = Vector3.zero;
                    lantern.transform.localRotation = Quaternion.identity;
                    lantern.GetComponent<Rigidbody>().isKinematic = true;
                    hasLantern = true;
                }
            }
        }
    }
}



