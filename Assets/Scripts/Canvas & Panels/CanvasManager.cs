using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    //RECORDAR QUE LOS COLORES SE PONEN CON ALPHA 0, ASI QUE VAN A DESAPARECER.
    public Image barLife;
    public Image stamina;

    public Color fullLife, criticalLife;

    public float life2, maxLife2;

    public float lerpLife;
    public float lastLife;


// Start is called before the first frame update
void Start()
    {
        lerpLife = maxLife2;
        barLife.color = fullLife;
    }

    private void Update()
    {
        lerpLife = Mathf.Lerp(lerpLife,life2, Time.deltaTime*2);
        barLife.fillAmount = lerpLife/maxLife2;
    }

    public void UpdateMyLife (float life, float maxLife)
    {
        life2 = life;
        maxLife2 = maxLife;
        
        Debug.Log($" CANVAS: la vida es {life} y la maxima es {maxLife}");

        //lerp de color verde a rojo, si quiero que funcione a partir del 50% hago life/(maxlife/2)
        barLife.color = Color.Lerp(criticalLife, fullLife, life2 / (maxLife2 / 2));
    }

    public void UpdateMyStamina()
    {

    }
}
