using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Apreto _teclaAtaque - Instancio HBox Prefab - Espero a terminar la animacion - Destruyo el Hbox 
    [Header("Values")]
    [SerializeField] public float _danioEstocada = 12.5f;
    [SerializeField] private float _attackCD = 1;
    [SerializeField] private KeyCode _myAttack;
    [SerializeField] private float _timeToDestroy;
    [Header("Referencias")]
    public GameObject hBox;
    public GameObject swordSprite;
    public Transform spawner;
    [SerializeField] private float _attackCurrentCD;

    public GameObject player;
    public PlayerMovement myPlayerMovement;


    //[SerializeField] private float _spawnerOffset;

    public void Awake()
    {
        _attackCurrentCD = _attackCD;
        //Fijo el valor del Cooldown de 0 a 100
        
    }

    public void FixedUpdate()
    {
        //Si el CD actual es mayor a cero, correr el "timer", sino no tocar
        if(_attackCurrentCD > 0) _attackCurrentCD -= Time.deltaTime ;
        //Anclo el valor actual del cooldown a 0
        //if (_attackCurrentCD < 0) _attackCurrentCD = 0;
        _attackCurrentCD = Math.Clamp(_attackCurrentCD, 0, 100);

        if (Input.GetKeyUp(_myAttack) && _attackCurrentCD == 0)
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            //GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
            Attack();
            //GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
            player.GetComponent<PlayerMovement>().enabled = true;

        }
    }

    private void Attack()
    {
        //Cuando ataco, el CD pasa a ser el cooldown que el dev quiera de vuelta
        _attackCurrentCD = _attackCD;
        var copy = Instantiate(hBox, spawner);
        var copySprite = Instantiate(swordSprite, spawner);
        Destroy(copySprite, _timeToDestroy);
        Destroy(copy , _timeToDestroy);


    }
}
