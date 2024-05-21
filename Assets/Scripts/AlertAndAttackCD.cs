using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertAndAttackCD : MonoBehaviour
{
    [SerializeField] EnemyShootAttack enemyattack;
    [SerializeField] GameObject fillArea;
    [SerializeField] Slider slider;

    //Genero un valor un poco menor a cuando ataca para anticipar el ataque al jugador
    [SerializeField] float valueBeforeAttack;

    [SerializeField] Color cooldownColor;
    [SerializeField] Color attackingColor;

    [SerializeField] ParticleSystem particulas;

    public void Update()
    {
        //Llamo el booleano del enemy attack, si estoy en rango prendo el slider, sino lo apago
        if (enemyattack.isOnRange)
        {
            fillArea.SetActive(true);
        }
        else
        {
            fillArea.SetActive(false);
        }

        slider.value = enemyattack._shootCooldown / enemyattack.cooldownReloader;
    }
}
