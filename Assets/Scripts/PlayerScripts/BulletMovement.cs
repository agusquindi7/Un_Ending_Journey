using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] float _deadTimer, _speed;
    public float swordDmg;

    public CheloEnemyLife myEnemyLife;

    private void Awake()
    {
        /*
        _deadTimer = 1;
        _speed = 6f;
        swordDmg = 15f;
        */
    }

    //[SerializeField] private float _speed;

    void Start()
    {
        //Al instanciarse la espada ya tiene una cuenta regresiva para destruirse
        //Destroy(gameObject, _deadTimer);

    }

    public void Update()
    {
        //la espada se dirige en linea recta
        //transform.position += transform.right * _speed * Time.deltaTime;
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //si el trigger de la espada coliciona con un objecto con el tag de enemigo, se destruye la espada. Y le quitara vida
        if (collision.CompareTag("Enemy"))
        {
            //addForce
            collision.GetComponent<CheloEnemyLife>().LifeController(swordDmg);
            //Destroy(gameObject);
        }

        if (collision.CompareTag("Boss"))
        {
            //addForce
            collision.GetComponent<BossLife>().LifeController(swordDmg);
            //Destroy(gameObject);
        }
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
    */
}
