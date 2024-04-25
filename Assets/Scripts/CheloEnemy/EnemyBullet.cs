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

    public GameObject target;
    public PlayerLife myPlayerLife;

    private Vector3 _direction;

    private void Awake()
    {
        _deadTimer = 3;
        _speed = 4f;
        damage = 10f;
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }

        if (target != null)
        {
            _direction = (target.transform.position - transform.position).normalized;
        }

    }

    private void Start()
    {
        Destroy(gameObject, _deadTimer);

        //_direction = (target.transform.position - transform.position).normalized;

    }

    void Update()
    {

        // Calcula la dirección hacia el jugador
        //Vector3 direction = (target.transform.position - transform.position).normalized;

        // Mueve la bala en la dirección calculada
        transform.position += _direction * _speed * Time.deltaTime;
    }

    /*
     * // B A L A  Q U E  S I G U E  A L  P J
     * 
    [Header("Values")]
    [SerializeField] float _deadTimer, _speed;
    public float damage;
    //public GameObject espadazo;
    //public GameObject slowZone;
    //public bool slowbool = false;

    //public Transform target;

    private GameObject target;
    public DestructibleObject myDestructibleObject;

    private Vector3 _direction;

    private void Awake()
    {
        _deadTimer = 3;
        _speed = 4f;
        damage = 10f;
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }

        else return;

        if (_playerObject != null)
        {
            _direction = (target.transform.position - transform.position).normalized;
        }

    }

    private void Start()
    {
        Destroy(gameObject, _deadTimer);

        //_direction = (target.transform.position - transform.position).normalized;

    }

    void Update()
    {
        
        // Calcula la dirección hacia el jugador
        //Vector3 direction = (target.transform.position - transform.position).normalized;

        // Mueve la bala en la dirección calculada
        //transform.position += direction * _speed * Time.deltaTime;

        Direction();
    }

    */



    private void Direction()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;

        transform.position += direction * _speed * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerSword"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Player"))
        {
            target.GetComponent<PlayerLife>().LifeController(damage);
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
