using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyRaycast : MonoBehaviour
    {
        [SerializeField] private int rayLength = 5; // Fixed typo: rayLenght to rayLength
        [SerializeField] private LayerMask layerMaskInteract;
        [SerializeField] private string excludeLayerName = null; // Fixed typo: excluseLayerName to excludeLayerName

        private KeyItemController raycastedObject;
        [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;

        private bool isCrosshairActive;
        private bool doOnce;

        private string interactableTag = "InteractiveObject";

        public void Update()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value; // Fixed function call

            if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
            {
                if (hit.collider.CompareTag(interactableTag))
                {
                    if (!doOnce)
                    {
                        raycastedObject = hit.collider.gameObject.GetComponent<KeyItemController>();
                    }

                    isCrosshairActive = true;
                    doOnce = true;

                    if (Input.GetKeyDown(openDoorKey))
                    {
                        raycastedObject.ObjectInteraction(); // Fixed typo: raycatedObject to raycastedObject
                    }
                }
            }
            else
            {
                if (isCrosshairActive)
                {
                    doOnce = false;
                }
            }
        }
    }
}
