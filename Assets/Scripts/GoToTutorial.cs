using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTutorial : MonoBehaviour
{
    public void ToTutorial()
    {
        SceneManager.LoadScene(0);
    }
}
