using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AgusNewAdventure : MonoBehaviour
{
    private AudioSource audioController;
    public AudioManager audioManager;


    public void Awake()
    {
        audioController = GetComponent<AudioSource>();
        audioManager = GetComponent<AudioManager>();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NewAdventure()
    {
        SceneManager.LoadScene("entrada a la montana");
    }

    public void HoverSoundNA()
    {
        audioManager.SeleccionAudio(1, 1f);
    }
}
