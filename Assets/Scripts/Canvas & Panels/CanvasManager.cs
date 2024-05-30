using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    //RECORDAR QUE LOS COLORES SE PONEN CON ALPHA 0, ASI QUE VAN A DESAPARECER.
    public Image barLife;
    //public Image stamina;

    public Color fullLife, criticalLife;

    public float life2, maxLife2;

    public float lerpLife;
    //public float lastLife;

    //Modificaciones Agus: Slider referencia - Cooldown artificial 
    [SerializeField] Slider sliderDash;
    [SerializeField] float dashCooldown;
    [SerializeField] float maxCooldown;

    void Start()
    {
        lerpLife = maxLife2;
        barLife.color = fullLife;

        //Igualo el dash principal con el maximo
        maxCooldown = 1f;
        dashCooldown = maxCooldown;
    }

    private void Update()
    {
        lerpLife = Mathf.Lerp(lerpLife,life2, Time.deltaTime*2);
        barLife.fillAmount = lerpLife/maxLife2;

        //Genero un sistema de cooldown para la barra de dash

        dashCooldown += Time.deltaTime;
        dashCooldown = Mathf.Clamp(dashCooldown, 0, 1);

        if (Input.GetKeyDown(KeyCode.Space) && dashCooldown==maxCooldown) dashCooldown = 0;

        //A ese valor del dash se lo paso al slider para que pase como con el ataque
        sliderDash.value = dashCooldown / maxCooldown;
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
