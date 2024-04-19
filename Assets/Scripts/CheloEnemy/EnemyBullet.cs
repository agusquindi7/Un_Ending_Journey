using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] float _deadTimer, _speed;
    public float damage;
    //public GameObject espadazo;
    //public GameObject slowZone;
    //public bool slowbool = false;

    //public Transform target;

    private GameObject _playerObject;
    public DestructibleObject myDestructibleObject;

    private void Awake()
    {
        _deadTimer = 10f;
        _speed = 4f;
        damage = 10f;
        _playerObject = GameObject.FindGameObjectWithTag("Player");

    }

    private void Start()
    {
        Destroy(gameObject, _deadTimer);
    }

    void Update()
    {
        //la bala va a spawnear en una determinada posicion a tal velocidad
        transform.position += transform.right * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_playerObject.CompareTag("Player"))
        {
            _playerObject.GetComponent<DestructibleObject>().LifeController(damage);
            Debug.Log($"{gameObject.name} Disparado");
            Destroy(gameObject);
        }
    }

    /*     
     * private void OnCollisionEnter2D(Collision2D collision)
     * 
    {        
        //if (collision.gameObject.layer == 6) collision.gameObject.GetComponent<DestructibleObject>().LifeController(damage); 
        
        if (collision.gameObject.CompareTag("Player"))
        {
            //llama a la funcion del playerlife Lifecontroles con el parametro de damage de la bala en negativo para restarle vida
            collision.gameObject.GetComponent<PlayerLife>().LifeController(-damage);
            Debug.Log($"{gameObject.name} destruido");

            /*
            //si slowzone es true, si es falso pongo !slowbool
            if (slowbool)
            {
                //collision.transform.position da la posicion del espacio

                //spawneo la zona de realentizacion en la posicion donde colision y en la rotacion
                Instantiate(slowZone, collision.transform.position, transform.rotation);

            }
            
        Destroy(gameObject);

        }

        

        //si el tag es el de la espada, la bala es destruida
        if (collision.gameObject.CompareTag("SwordSlashTag"))
        {
            Debug.Log($"{gameObject.name} destruido");
            Destroy(gameObject);
        }
        

        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log($"{gameObject.name} destruido");
            Destroy(gameObject);
        }
    }
     
     
     //


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.layer == 6)
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<DestructibleObject>().LifeController(damage);
        }
        Destroy(gameObject);
    }
    */
}
