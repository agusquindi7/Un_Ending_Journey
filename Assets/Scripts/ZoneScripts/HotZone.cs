using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZone : MonoBehaviour
{
    [Header("Values")]
    public float damage;
    [SerializeField]private bool _ignite;

    [SerializeField] private float _damageCD, _damageCDRefreh;

    private GameObject _playerObject;
    
    public DestructibleObject myDestructibleObject;

    private void Awake()
    {
        damage = 10;
        _damageCD = 0;
        _damageCDRefreh = 1;

        _ignite = false;

        _playerObject = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        if (_ignite == true && _playerObject.CompareTag("Player"))
        {
            Debug.Log($"entre en _ignite");

            //El daño por fuergo del piso se activa al igualar valores
            if (_damageCD >= _damageCDRefreh)
            {
                Debug.Log($"entra en el cd");

                _playerObject.GetComponent<DestructibleObject>().LifeController(damage);

                _damageCD = 0;
                //llama a la funcion del playerlife Lifecontroles con el parametro de damage de la bala en negativo para restarle vida
                Debug.Log($"{gameObject.name} Quemado");
                                    
            }
            if (_damageCD < _damageCDRefreh) _damageCD += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _ignite = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _ignite = false;
            if (_damageCD < _damageCDRefreh && _damageCD < 2) _damageCD += Time.deltaTime;
        }            
    }
}
