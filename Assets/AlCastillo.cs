using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class AlCastillo : MonoBehaviour
{
    public string castilloNoBoss;
    public string player = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(player)) SceneManager.LoadScene(castilloNoBoss);
    }
}
