using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestingRoom : MonoBehaviour
{
    private AudioSource audioController;
    public AudioManager audioManager;

    public void Awake()
    {
        audioController = GetComponent<AudioSource>();
        audioManager = GetComponent<AudioManager>();
    }

    public void ToTestRoom()
    {
        SceneManager.LoadScene(2);
    }

    public void HoverSoundTR()
    {
        audioManager.SeleccionAudio(2, 1f);
    }
}
