using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]

public class SlowZone : MonoBehaviour
{
    [Header ("Values")]
    public float slowSpeed;
    public PlayerMovement myPlayerMovement;

    private float _mySlowSpeed, _myNormalSpeed, _myConstantSpeed;

    private void Awake()
    {
        //traigo componentes de playermovement
        if (myPlayerMovement == null) myPlayerMovement = FindObjectOfType<PlayerMovement>();

        //igualo valores de variables locales a las del script de playermovent para tener sus velocidades 
        _myConstantSpeed = myPlayerMovement.constantSpeed;
        _myNormalSpeed = myPlayerMovement.normalSpeed;
        _mySlowSpeed = myPlayerMovement.normalSpeed*0.5f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //modifico la varable normal speed del personaje sin retornarla, es mas rapido
        myPlayerMovement.normalSpeed = _mySlowSpeed;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //modifico de nuevo la varable normal speed del personaje al salir del collider
        myPlayerMovement.normalSpeed = _myConstantSpeed;
    }
}
