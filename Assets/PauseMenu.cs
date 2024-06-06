using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public Animator animator;

    [Header("Audio")]
    public AudioManager audioManager;
    public AudioSource audioSource;

    public bool isPaused;

    public void Awake()
    {
        pauseMenu.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            isPaused = true;
            PausedMenu();
        }
    }

    public void PausedMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

        audioSource.mute = true;

        animator.enabled = false;
    }

    public void ResumeMenu()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;

        audioSource.mute = false;

        animator.enabled = true;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
