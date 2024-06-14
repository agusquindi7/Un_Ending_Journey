using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Necesario
using UnityEngine.SceneManagement;

public class SceneManagerAdd : MonoBehaviour
{
    public string[] scenes;
    public int index;
    public string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag)) SceneManager.LoadScene(scenes[index]);
    }
}
