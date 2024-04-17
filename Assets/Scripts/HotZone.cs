using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZone : MonoBehaviour
{
    [Header("Values")]
    public float damage;
    [SerializeField] private float _damageCD, _damageCDRefreh;
    
    public PlayerLife myPlayerLife;

    private void Awake()
    {
        damage = 10;
        _damageCD = 0;
        _damageCDRefreh = 1;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //El daño por fuergo del piso se activa al igualar valores
            if (_damageCD >= _damageCDRefreh)
            {
                collision.gameObject.GetComponent<PlayerLife>().LifeController(damage);
                _damageCD = 0;
                //llama a la funcion del playerlife Lifecontroles con el parametro de damage de la bala en negativo para restarle vida
                Debug.Log($"{gameObject.name} Quemado");
            }
            if (_damageCD < _damageCDRefreh) _damageCD += Time.deltaTime;            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_damageCD < _damageCDRefreh && _damageCD < 2) _damageCD += Time.deltaTime;
    }



}
