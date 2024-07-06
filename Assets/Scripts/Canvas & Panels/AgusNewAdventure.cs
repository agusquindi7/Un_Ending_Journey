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

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void HoverSoundNA()
    {
        audioManager.SeleccionAudio(1, 1f);
    }
}
