using System;
using UnityEngine;

// "Enkelt" script som tar i mot input fra Input Actions og bruker det for å flytte spilleren på X og Z aksen basert på input

public class PlayerMovement : MonoBehaviour
{
    // Hvor raskt karakteren vår kan flytte seg. Synlig i inspector
    [SerializeField] float movementSpeed = 0;

    // Referanse til klassen vår generert av Input Actions
    private PlayerControls playerControls;

    private void Awake()
    {
        // Setter playerControls til å være lik en instans av PlayerControls klassen.
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        // Aktiverer input actions
        playerControls.Enable();
    }

    private void OnDisable()
    {
        // Deaktiverer input actions
        playerControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        // Lager en variabel av typen Vector2 (holder på todimensjonale verdier(x,y) og setter den til å være lik det som blir produsert av en action i input action vår)
        Vector2 inputVector = playerControls.Player.Movement.ReadValue<Vector2>();
        
        // Siden vi ønsker informasjon i tre dimensjoner lager vi en Vector3 og setter X og Z aksen til å være lik verdiene fra inputVector
        Vector3 movementVector = new Vector3(inputVector.x, 0, inputVector.y);

        // Vi flytter objektet vårt (spilleren i dette tilfellet) relativt til nåværende posisjon med movementVector * movementSpeed * Time.deltaTime.
        transform.Translate(movementVector * movementSpeed * Time.deltaTime);

    }
}

