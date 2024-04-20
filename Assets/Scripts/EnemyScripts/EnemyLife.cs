using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyLife : MonoBehaviour
{
    //vidaMaxima - vidaActual - armadura - Destroy GameObject cuando vida sea menor o igual a 0
    [SerializeField] private float _vidaActual;
    [SerializeField] private float _vidaMaxima = 50f;
    public Rigidbody2D enemyRB;
    public PlayerAttack playerAttack;

    public void Awake()
    {
        //playerAttack = GetComponent<PlayerAttack>();
        enemyRB = GetComponent<Rigidbody2D>();
        _vidaMaxima = _vidaActual;
    }

    public void Update()
    {
        if (_vidaActual <= 0) Death();
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("PlayerHBox"))
        {
            Debug.Log("Enemy says: OUCH!");
            _vidaActual -= playerAttack._danioEstocada;
        }
        
    }
}
