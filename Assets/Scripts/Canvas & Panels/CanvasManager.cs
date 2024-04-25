using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public Image barLife;
    public Image stamina;

    public Color fullLife, criticalLife;

    // Start is called before the first frame update
    void Start()
    {
        barLife.color = fullLife;
    }

    public void UpdateMyLife (float life, float maxLife)
    {
        barLife.fillAmount = life / maxLife;
        
        Debug.Log($" CANVAS: la vida es {life} y la maxima es {maxLife}");

        //lerp de color verde a rojo, si quiero que funcione a partir del 50% hago life/(maxlife/2)
        barLife.color = Color.Lerp(criticalLife, fullLife, life / (maxLife / 2));
    }

    public void UpdateMyStamina()
    {

    }
}
