using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleMovementNewSystem : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;

    void Update()
    {
        // Setter inputVector til (0,0) på hver frame.
        Vector2 inputVector = Vector2.zero;
        
        // Setter inputVector til riktig verdi basert på input
        if (Keyboard.current.wKey.isPressed) inputVector.y = 1;
        if (Keyboard.current.sKey.isPressed) inputVector.y = -1;
        if (Keyboard.current.aKey.isPressed) inputVector.x = -1;
        if (Keyboard.current.dKey.isPressed) inputVector.x = 1;

        // Lager en Vector3 som fylles med data på x og z posisjon fra inputVector og normaliserer.
        Vector3 movementVector = new Vector3(inputVector.x, 0f, inputVector.y).normalized;

        // Flytter spilleren relativt til nåværende posisjon.
        transform.Translate(movementVector * (movementSpeed * Time.deltaTime));
    }
}
