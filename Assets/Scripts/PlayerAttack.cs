using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Apreto _teclaAtaque - Instancio HBox Prefab - Espero a terminar la animacion - Destruyo el Hbox 

    [SerializeField] public float _danioEstocada = 12.5f;
    public GameObject hBox;
    public Transform spawner;
    [SerializeField] private float _spawnerOffset;
    [SerializeField] private KeyCode _myAttack;
    [SerializeField] private float _timeToDestroy;
    [SerializeField] private float _attackCD = 1;
    [SerializeField] private float _attackCurrentCD;

    public void Awake()
    {
        _attackCurrentCD = _attackCD;
    }

    public void FixedUpdate()
    {
        //Si el CD actual es mayor a cero, correr el "timer", sino no tocar
        if(_attackCurrentCD > 0) _attackCurrentCD -= Time.deltaTime ;
        //Anclo el valor actual del cooldown a 0
        if (_attackCurrentCD < 0) _attackCurrentCD = 0;

        if (Input.GetKeyDown(_myAttack) && _attackCurrentCD == 0) Attack();
    }

    private void Attack()
    {
        //Cuando ataco, el CD pasa a ser el cooldown que el dev quiera de vuelta
        _attackCurrentCD = _attackCD;
        var copy = Instantiate(hBox, spawner);
        Destroy(copy , _timeToDestroy);
    }
}
