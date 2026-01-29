using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    // Referanse til cinemachine kameraene våre.
    [SerializeField] private CinemachineCamera staticCamera;
    [SerializeField] private CinemachineCamera orbitalCamera;

    // En bool for å holde styr på om et kamera er aktivt eller ikke aktivt
    private bool isStaticCameraActive = false;

    // Update is called once per frame
    void Update()
    {
        // Hvis spilleren trykker på spacebar skal vi bytte kamera
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {    
            // Setter isStaticCameraActive til motsatt av hva det er nå (true/false)
            isStaticCameraActive = !isStaticCameraActive;

            // Logger isStaticCameraActiv for å se så den endres som forventet (kan fjernes)
            Debug.Log(isStaticCameraActive);

            // Vi sjekker om isStaticCameraActiv er true eller ikke
            if (isStaticCameraActive)
            {
                // Endrer prioritet på kameraene slik at vi får et nytt aktivt kamera.
                staticCamera.Priority = 1;
                orbitalCamera.Priority = 0;
            }
            else
            {
                staticCamera.Priority = 0;
                orbitalCamera.Priority = 1;
            }
        }
    }
}

