using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]

public class EnemyFollow : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private bool isMovingHorizontally = false;
    private bool isMovingVertically = false;
    private bool isStopped = false; //Controla si el enemigo esta quieto

    private float _waitSeconds = 1.5f;

    /*
    public float actualX;
    public float actualY;

    public GameObject spawnery;
    public GameObject spawnerY;
    public GameObject spawnerx;
    public GameObject spawnerX;

    public bool spawneryBool;
    public bool spawnerYBool;
    public bool spawnerxBool;
    public bool spawnerXBool;
    */

    public GameObject spawner;

    private void Awake()
    {        
            target = GameObject.FindGameObjectWithTag("Player");

    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (target != null && !isStopped)
        {
            if (!isMovingHorizontally && !isMovingVertically)
            {
                //Se mueve mueve primero horizontalmente si la diferencia en X es mayor que Y
                if (Mathf.Abs(target.transform.position.x - transform.position.x) > Mathf.Abs(target.transform.position.y - transform.position.y))
                {
                    rb.velocity = new Vector2(Mathf.Sign(target.transform.position.x - transform.position.x) * moveSpeed, 0f);
                    isMovingHorizontally = true;

                    UpdateSpawnerRotation();
                }
                else
                {
                    //Si la diferencia en Y es mayor que X, va a moverse verticalmente
                    rb.velocity = new Vector2(0f, Mathf.Sign(target.transform.position.y - transform.position.y) * moveSpeed);
                    isMovingVertically = true;

                    UpdateSpawnerRotation();
                }
            }
            else if (isMovingHorizontally)
            {
                //Se mueve horizontalmente hasta alcanzar la misma coordenada X que el jugador
                if (Mathf.Abs(target.transform.position.x - transform.position.x) > 0.1f)
                {
                    rb.velocity = new Vector2(Mathf.Sign(target.transform.position.x - transform.position.x) * moveSpeed, 0f);                    
                }
                //Si la distancia es la misma apago el bool horizontal
                else
                {
                    rb.velocity = Vector2.zero;
                    isMovingHorizontally = false;
                }
            }
            else if (isMovingVertically)
            {
                //Se mueve verticalmente hasta alcanzar la misma coordenada Y que el jugador
                if (Mathf.Abs(target.transform.position.y - transform.position.y) > 0.1f)
                {
                    rb.velocity = new Vector2(0f, Mathf.Sign(target.transform.position.y - transform.position.y) * moveSpeed);
                }

                //Si la distancia es la misma apago el bool vertical
                else
                {
                    rb.velocity = Vector2.zero;
                    isMovingVertically = false;
                }
            }
        }

        //Metodo de rotacion del spawner, que se actualiza cuando se mueve
        void UpdateSpawnerRotation()
        {
            //calculo la dirección entre el enemigo y el jugador
            Vector2 direction = target.transform.position - transform.position;
            //calculo el ángulo en radianes
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //creo una rotación
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            //spawner rota
            spawner.transform.rotation = rotation;
        }

        /*

        // Calcula la dirección relativa entre el enemigo y el jugador
        Vector2 direction = target.position - transform.position;
        // Calcula el ángulo en radianes
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Crea una rotación
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        // Aplica la rotación al spawner
        spawner.transform.rotation = rotation;

        */
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Si el player entra en el collider, el enemigo no puede moverse
        if (collision.CompareTag("Player"))
        {
            rb.velocity = Vector2.zero;
            isStopped = true;
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        //Si el player sale del collider, el enemigo puede moverse
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Waiting(_waitSeconds));
        }
    }

    private IEnumerator Waiting(float _waitSeconds)
    {        
        yield return new WaitForSeconds(_waitSeconds);
        isStopped = false;
    }
    /*
    private void SpawnerActive()
    {
        if (gameObject.transform.position.x <= actualX) spawnerxBool = true;
        else if (gameObject.transform.position.x >= actualX) spawnerXBool = true;
        else if (gameObject.transform.position.y <= actualY) spawneryBool = true;
        else if (gameObject.transform.position.y >= actualY) spawnerYBool = true;


    }*/
}
