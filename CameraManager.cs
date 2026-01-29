using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineCamera staticCamera;
    [SerializeField] private CinemachineCamera orbitalCamera;

    private bool isStaticCameraActive = false;

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            isStaticCameraActive = !isStaticCameraActive;
            
            Debug.Log(isStaticCameraActive);

            if (isStaticCameraActive)
            {
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
