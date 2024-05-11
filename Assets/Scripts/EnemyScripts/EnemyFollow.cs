using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]

public class EnemyFollow : MonoBehaviour
{
    public Transform target; // Referencia al jugador
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private bool isMovingHorizontally = false;
    private bool isMovingVertically = false;
    private bool isStopped = false; // Controla si el enemigo está detenido

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
                // Mueve primero horizontalmente si la diferencia en X es mayor
                if (Mathf.Abs(target.position.x - transform.position.x) > Mathf.Abs(target.position.y - transform.position.y))
                {
                    rb.velocity = new Vector2(Mathf.Sign(target.position.x - transform.position.x) * moveSpeed, 0f);
                    isMovingHorizontally = true;
                }
                else
                {
                    // Si la diferencia en Y es mayor, cambia a moverse verticalmente
                    rb.velocity = new Vector2(0f, Mathf.Sign(target.position.y - transform.position.y) * moveSpeed);
                    isMovingVertically = true;
                }
            }
            else if (isMovingHorizontally)
            {
                // Mueve horizontalmente hasta alcanzar la misma coordenada X que el jugador
                if (Mathf.Abs(target.position.x - transform.position.x) > 0.1f)
                {
                    rb.velocity = new Vector2(Mathf.Sign(target.position.x - transform.position.x) * moveSpeed, 0f);

                    //actualX = gameObject.transform.position.x;
                }
                else
                {
                    rb.velocity = Vector2.zero;
                    isMovingHorizontally = false;
                }
            }
            else if (isMovingVertically)
            {
                // Mueve verticalmente hasta alcanzar la misma coordenada Y que el jugador
                if (Mathf.Abs(target.position.y - transform.position.y) > 0.1f)
                {
                    rb.velocity = new Vector2(0f, Mathf.Sign(target.position.y - transform.position.y) * moveSpeed);

                    //actualY = gameObject.transform.position.y;

                }
                else
                {
                    rb.velocity = Vector2.zero;
                    isMovingVertically = false;
                }
            }
        }

        //if (gameObject.transform.position.y )
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Si el objeto que entra en el área de detección es el jugador, detiene al enemigo
        if (other.CompareTag("Player"))
        {
            rb.velocity = Vector2.zero;
            isStopped = true;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        // Si el objeto que sale del área de detección es el jugador, permite que el enemigo avance
        if (other.CompareTag("Player"))
        {
            isStopped = false;
        }
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
