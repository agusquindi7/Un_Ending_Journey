using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestingRoom : MonoBehaviour
{
    public AudioSource audioController;
    public AudioManager audioManager;

    public void ToTestRoom()
    {
        SceneManager.LoadScene(2);
    }

    public void HoverSoundTR()
    {
        audioManager.SeleccionAudio(2, 1f);
    }
}
