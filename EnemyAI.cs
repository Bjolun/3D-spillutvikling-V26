using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // Referanser til spilleren og patrol points som AI'en skal følge.
    [SerializeField] private Transform followTarget;
    [SerializeField] private Transform[] patrolPoints;

    // Initiell verdi på aktiv patrol point. Brukes for å peke på indeksposisjon i patrolPoints.
    private int currentPatrolPoint = 0;
    
    // Referanse av typen NavMeshAgent
    private NavMeshAgent _agent;

    // Deklarerer mulige states enemy kan ha. Separeres med komma
    private enum States
    {
        Patrolling,
        Chasing
    }
    
    private States _states;
    
    

    private void Start()
    {
        // Peker på riktig NavMeshAgent og setter initiell state.
        _agent = GetComponent<NavMeshAgent>();
        _states = States.Patrolling;
    }

    private void Update()
    {
        // Switch case som ser etter hvilken state som er aktiv og kaller på ønsket metode basert på case.
        switch (_states)
        {
            case States.Patrolling:
                Patrolling();
                break;
            case States.Chasing:
                Chasing();
                break;
        }
    }

    // Oppdaterer destinasjon til å være lik followTarget (spilleren) sin posisjon.
    private void Chasing()
    {
        _agent.SetDestination(followTarget.position);
    }

    // Patruljerer mellom posisjonen til game objektene i en array. 
    private void Patrolling()
    {
        // Ser hvor mange patrolpoints som finnes i arrayen vår
        int numberOfPatrolPoints = patrolPoints.Length;

        // Dersom vi er under en halv unit unna målet vårt endrer vi verdi på currentPatrolPoint og setter ny destinasjon.
        if (_agent.remainingDistance < .5f)
        {
            if (currentPatrolPoint + 1 == numberOfPatrolPoints)
            {
                currentPatrolPoint = 0;
                _agent.SetDestination(patrolPoints[currentPatrolPoint].position);
            }
            else
            {
                currentPatrolPoint++;
                _agent.SetDestination(patrolPoints[currentPatrolPoint].position);
            }
        }
    }

    // Ser om spilleren kommer innenfor collideren for å endre state til Chasing
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _states = States.Chasing;
        }
    }
    
    // Ser om spilleren går utenfor collideren for å endre state til Patrolling
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _states = States.Patrolling;
        }
    }
}
