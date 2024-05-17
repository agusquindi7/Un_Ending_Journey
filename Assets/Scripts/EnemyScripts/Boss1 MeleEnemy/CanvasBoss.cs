using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasBoss : MonoBehaviour
{
    public Image barLife;

    public float bossLife, bossMaxLife;
    public float lerpLife;

    //public float speed = 1f;

    private void Awake()
    {
        lerpLife = bossMaxLife;
    }
    // Start is called before the first frame update
    void Start()
    {
        lerpLife = bossMaxLife;
    }

    private void Update()
    {
        lerpLife = Mathf.Lerp(lerpLife, bossLife, Time.deltaTime * 2);
        barLife.fillAmount = lerpLife / bossMaxLife;
    }

    public void UpdateMyLife(float life, float maxLife)
    {
        bossLife = life;
        bossMaxLife = maxLife;

        Debug.Log($" CANVAS ENEMIGO: la vida es {life} y la maxima es {maxLife}");

        //lerp de color verde a rojo, si quiero que funcione a partir del 50% hago life/(maxlife/2)
        //barLife.color = Color.Lerp(criticalLife, fullLife, life2 / (maxLife2 / 2));

        //Valor normal, Maximo, interpolacion
        barLife.fillAmount = Mathf.Lerp(bossLife, bossMaxLife, (bossMaxLife / 2));

        //bossLife = Mathf.Lerp(lerpLife, bossLife, speed * Time.deltaTime);
    }
}
