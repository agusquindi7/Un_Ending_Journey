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
    }

    public void NewAdventure()
    {
        SceneManager.LoadScene(1);
    }

    public void HoverSoundNA()
    {
        audioManager.SeleccionAudio(1, 1f);
    }
}
