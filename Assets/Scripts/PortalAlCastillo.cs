using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalAlCastillo : MonoBehaviour
{
    public GameObject enemy;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(enemy==null)
        {
            if(collision.CompareTag("Player"))
            {
                SceneManager.LoadScene(4);
            }
        }
    }
}
