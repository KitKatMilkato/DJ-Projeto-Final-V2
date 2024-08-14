using UnityEngine;

public class LanternControl : MonoBehaviour
{
    private Light lanternLight;
    private bool isOn = false;

    void Start()
    {
        lanternLight = GetComponentInChildren<Light>();
        if (lanternLight != null)
        {
            lanternLight.enabled = false;  // Lanterna começa desligada
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn;
            if (lanternLight != null)
            {
                lanternLight.enabled = isOn;
            }
        }
    }
}

