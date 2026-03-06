using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    // Ha en referanse til lydkilden vår (AudioSource)
    [SerializeField] private AudioSource audioSource;

    // Ha en referanse til slideren vår
    [SerializeField] private Slider volumeSlider;

    // Se om vi spiller musikk eller ikke.
    private bool isPlayingMusic = true;

    // Lage en metode for å skru av og på musikken - Toggle
    public void ToggleMusic()
    {
        // Endre status på isPlayingMusic til motsatt av det den er nå
        isPlayingMusic = !isPlayingMusic;
        
        if(isPlayingMusic)
        {
            // Hvis isPlayingMusic er true, spill av musikk
            audioSource.Play();
        }
        
        else
        {
            // Hvis isPlayingMusic er false, stopp/pause musikken
            audioSource.Pause();
        }
    }

    // Lage en metode som styrer volum med slideren vår
    public void SliderVolume()
    {
        // Audio source sin volum skal være like slideren sin verdi
        audioSource.volume = volumeSlider.value;
    }


}
