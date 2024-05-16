using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : MonoBehaviour
{
    public Transform spawner;
    public GameObject slimeBullet;

    public float cd;
    public float cdReload;


    public bool attackBool = false;
    public float _waitSeconds = 1f;

    private void Awake()
    {
        //Tiempo entre cada ataque
        cdReload = 3f;

        cd = cdReload;
    }

    void Update()
    {
        if (attackBool == true)
        {
            if (cd >= cdReload)
            {
                Attack();
            }
            cd += Time.deltaTime;
        }
        else cd = 0;
    }

    private void Attack()
    {
        Instantiate(slimeBullet, spawner.position, spawner.rotation);
        cd = 0;
        //StartCoroutine(Waiting(_waitSeconds));
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
}
