using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;


    void Start()
    {
        // Set the initial value of the slider to the current volume
        if (audioSource != null && volumeSlider != null)
        {
            volumeSlider.value = audioSource.volume;
        }
        else
        {
            Debug.LogError("AudioSource or Slider not assigned in the inspector.");
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Earth");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OnVolumeChanged()
    {
        if (audioSource != null && volumeSlider != null)
        {
            // Update the volume of the audio source
            audioSource.volume = volumeSlider.value;
        }
    }
}
