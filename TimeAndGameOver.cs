using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeAndGameOver : MonoBehaviour
{
    // Referanse til teksten vår som skal telle ned
    [SerializeField] private TextMeshProUGUI timerText;

    // Referanse til GameOverPanel slik at vi kan skru det av og på når tiden går ut
    [SerializeField] private GameObject gameOverPanel;

    // Vi trenger en timer
    [SerializeField] private int time = 60;

    // Vi må vite hvilken scene som er aktiv, slik at vi kan loade scenen når vi trykker på reload
    private int _sceneNumber;
    
    // Finne ut hvilken scene vi er i
    private void Awake()
    {
        _sceneNumber = SceneManager.GetActiveScene().buildIndex;
    }
    
    // Når vi starter spillet vil vi gjøre et par ting..
    private void Start()
    {
    // Oppdatere teksten som står i telleren slik at den har rett verdi
    timerText.text = "Time remaining: " + time;
    
    // Kalle på en metode som teller ned hvert sekund
    InvokeRepeating("CoundDownTime", 1, 1);
    }

    private void CoundDownTime()
    {
        // Hvis timeren er mer enn null (det er tid igjen)
        if (time > 0)
        {
            // Reduser timeren med 1
            time--;
            // Oppdater teksten slik at den viser riktig tid
            timerText.text = "Time remaining: " + time;
        }
        // Hvis tiden er ute
        else
        {
            // Aktiver GameOverPanel
            gameOverPanel.SetActive(true);
            // Stopp tiden
            Time.timeScale = 0f;
        }
    }
    
    // Metode for å restarte spillet
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_sceneNumber);
    }
}
