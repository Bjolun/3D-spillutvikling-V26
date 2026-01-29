using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    // For at dette scriptet skal fungere må du aktivere det gamle input systemet i project settings
    // File -> Project settings -> Player -> Other settings -> Active Input Handling -> Sett til "Both".
    
    // Movement speed som er synlig i inspektoren
    [SerializeField] private float movementSpeed;
    
    // Vi skal ta i mot input og oppdatere posisjon på hver frame. Derfor setter vi følgende i Update()
    void Update()
    {
        // Fyller horizontalMovement og verticalMovement med 1, 0 eller -1 basert på input fra spilleren
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
        
        // Lager en ny vector3 som får informasjon på x og z posisjon fra variablene vi deklarerte ovenfor
        Vector3 movementVector = new Vector3(horizontalMovement, 0f, verticalMovement).normalized;
        
        // Flytter posisjonen til game objektet relativt til nåværende posisjon.
        transform.Translate((movementSpeed * Time.deltaTime) * movementVector);
    }
}
