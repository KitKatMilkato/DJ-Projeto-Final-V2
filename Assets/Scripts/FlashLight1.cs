using UnityEngine;

public class FlashLightController : MonoBehaviour
{
    public Light flashlight; // A luz que será ligada/desligada
    private bool isOn = false; // Estado da lanterna (ligada/desligada)

    void Start()
    {
        // Verifica se a luz foi associada no Inspetor
        if (flashlight == null)
        {
            flashlight = GetComponent<Light>();
        }

        // Inicialmente, desliga a luz
        flashlight.enabled = isOn;
    }

    void Update()
    {
        // Verifica se a tecla F foi pressionada
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Alterna o estado da luz
            isOn = !isOn;
            flashlight.enabled = isOn;
        }
    }
}
