using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleAttack : MonoBehaviour
{
    public Transform spawner;
    public GameObject enemyMeleBullet;

    public float cd;
    public float cdReload;

    public bool attackBool = false;
    public float _waitSeconds = 1f;

    private void Awake()
    {
        //Tiempo entre cada ataque
        cdReload = 2f;
    }

    private void Update()
    {
        Attack();
        cd += Time.deltaTime;
    }

    public void Attack()
    {
        if (attackBool == true)
        {
            //CAMBIAR ACA, LA ANIMACION TIENE QUE GENERAR EL COLLIDER TAL VEZ
            if (cd >= cdReload)
            {
                Instantiate(enemyMeleBullet, spawner.position, spawner.rotation);
                cd = 0;
                StartCoroutine (Waiting(_waitSeconds));                
            }
            cd += Time.deltaTime;
        }
        else cd = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Si el player entra en el collider, puede atacar
        if (collision.CompareTag("Player")) attackBool = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) attackBool = false;
    }

    private IEnumerator Waiting(float _waitSeconds)
    {
        yield return new WaitForSeconds(_waitSeconds);
        //cd = 0;
        //attackBool = false;
        //Instantiate(enemyMeleBullet, spawner.position, spawner.rotation);
    }
}
