using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSesitivity = 100f;
    public Transform PlayerBody;

    float xRotation;
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked; 
    }

    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSesitivity * Time.deltaTime;

        float mouseY = Input.GetAxis("Mouse Y") * mouseSesitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation =Mathf.Clamp(xRotation, -90,90);

        transform.localRotation = Quaternion.Euler(xRotation, 0,0);

        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
