using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class LookAtTarget : MonoBehaviour
{
    //Target del personaje - RigidBody2D
    public Transform target;
    public Rigidbody2D myRB;
    public PlayerChecker playerChecker;
    

    //Carga el ataque cuando jugador esta en layout - _tiempoDeAtaque - Ataque - Recarga


    public void Awake()
    {
        myRB = this.GetComponent<Rigidbody2D>();
        playerChecker = FindObjectOfType<PlayerChecker>();
    }

    public void Update()
    {
        Vector3 direction = (target.position - transform.position);
        //Hago el calculo del angulo
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Se lo sumo a mi angulo actual
        myRB.rotation = angle;
        
    }
}
