using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDashAttack : MonoBehaviour
{
    public GameObject target;
    public GameObject spawner;

    public float speed;
    public float cd, cdRefresh;

    public bool dashTired;
    
    private void Awake()
    {
        cdRefresh = 20f;

        target = GameObject.FindGameObjectWithTag("Player");

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //distancia toma 2 variables: la posicion del enemigo y la del target, y saca su distancia entre ellos
        float distance = Vector2.Distance(transform.position, target.transform.position);

        if (dashTired == false)
        {

        }
        Tired();
    }

    private void Dash()
    {

    }

    private void Tired()
    {
        dashTired = true;

        if (cd >= cdRefresh)
        {
            dashTired = false;
            cd = 0;            
        }

        if (cd < cdRefresh) {
        } cd += Time.deltaTime;

        cd += Time.deltaTime;
        //else
    }
}
