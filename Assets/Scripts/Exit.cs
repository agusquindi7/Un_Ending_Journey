using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private AudioSource audioController;
    public AudioManager audioManager;

    public void Awake()
    {
        audioController = GetComponent<AudioSource>();
        audioManager = GetComponent<AudioManager>();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void HoverSoundEx()
    {
        audioManager.SeleccionAudio(3, 1f);
    }
}