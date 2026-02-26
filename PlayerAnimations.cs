using System;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    // Referanse til PlayerMovement klassen på spilleren vår
    [SerializeField] private PlayerMovement player;

    // Referanse av typen animator slik at vi kan peke på komponenten vår
    private Animator animator;

    // Hvilken animator komponent skal referansen vår peke på?
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // På hver frame ønsker vi å se om spilleren flytter seg eller ikke
    private void Update()
    {
        // Hvis spilleren flytter seg, spill av walking animasjon (isWalking = true)
        if (player.IsWalking())
        {
            animator.SetBool("isWalking", true);
        }
        // Hvis ikke, spill av idle (isWalking = false) 
        else
        {
            animator.SetBool("isWalking", false);
        }
        
    }
    


}
