using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform cameraTransform;

    private void Start()
    {
        // Obtener la referencia al transform de la cámara principal
        OVRCameraRig cameraRig = FindObjectOfType<OVRCameraRig>();
        if (cameraRig != null)
        {
            cameraTransform = cameraRig.centerEyeAnchor;
        }
    }

    private void LateUpdate()
    {
        // Hacer que el objeto siempre mire hacia la cámara
        if (cameraTransform != null)
        {
            transform.LookAt(cameraTransform);
        }
    }
}
