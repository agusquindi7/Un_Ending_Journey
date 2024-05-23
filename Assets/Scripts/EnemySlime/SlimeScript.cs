using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public bool isMovingHorizontally = false;
    public bool isMovingVertically = false;


    public bool isStopped = false; //Controla si el enemigo esta quieto
    public float detectionRadius;
    public float attackRadius;

    public bool canAttack = false;

    public GameObject slimeBullet;
    public GameObject spawner;

    public float cd;
    public float cdReload;

    public bool isAttacking = false; // Para evitar ataques múltiples


    public float _waitSeconds;
    public float _postAttackWaitSeconds; // Tiempo adicional de espera después del ataque


    FSM myfsm;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        cdReload = 3f;

        cd = 0;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        myfsm = new FSM();
        myfsm.AddState(StateID.Idle, new Idle(this));
        myfsm.AddState(StateID.Walking, new Walking(this));
        myfsm.AddState(StateID.Attaking, new Attaking(this));

        myfsm.ChangeState(StateID.Idle);
    }

    private void Update()
    {
        myfsm.OnUpdate();
    }

    /*
    void Update()
    {
        CanMove();

        if (isStopped && canAttack && !isAttacking)
        {
            Attack();
        }

        else if (target != null && isStopped == false)
        {
            if (!isMovingHorizontally && !isMovingVertically)
            {
                //Se mueve mueve primero horizontalmente si la diferencia en X es mayor que Y
                if (Mathf.Abs(target.transform.position.x - transform.position.x) > Mathf.Abs(target.transform.position.y - transform.position.y))
                {
                    rb.velocity = new Vector2(Mathf.Sign(target.transform.position.x - transform.position.x) * moveSpeed, 0f);
                    isMovingHorizontally = true;
                    
                }
                else
                {
                    //Si la diferencia en Y es mayor que X, va a moverse verticalmente
                    rb.velocity = new Vector2(0f, Mathf.Sign(target.transform.position.y - transform.position.y) * moveSpeed);
                    isMovingVertically = true;
                    
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

    }*/

    void CanMove()
    {
        //Verifico la distancia entre el jugador y el slime, si es menor, permito que se mueve si no es mayor al area de ataque
        if (Vector2.Distance(transform.position, target.transform.position) < detectionRadius && Vector2.Distance(transform.position, target.transform.position) > attackRadius)
        {
            isStopped = false;
            cd = 0;
        }

        //Si la distancia es mayor no puede moverse
        else if (Vector2.Distance(transform.position, target.transform.position) > detectionRadius)
        {
            isStopped = true;
            rb.velocity = Vector2.zero;
        }

        //Si la distancia de attaque es menor no puede moverse y habilita a atacar
        else if (Vector2.Distance(transform.position, target.transform.position) <= attackRadius)
        {
            rb.velocity = Vector2.zero;
            isStopped = true;
            canAttack = true;
        }
    }

    void Attack()
    {        
            isAttacking = true;
            isStopped = true;
            rb.velocity = Vector2.zero;
            StartCoroutine(AttackCoroutine());
        
    }

    private IEnumerator AttackCoroutine()
    {
        

        yield return new WaitForSeconds(_waitSeconds); // Esperar antes de atacar
        Instantiate(slimeBullet, spawner.transform.position, spawner.transform.rotation);
        yield return new WaitForSeconds(_waitSeconds); // Esperar después de atacar

        isStopped = false;
        canAttack = false;
        isAttacking = false;
    }

    private IEnumerator Waiting(float _waitSeconds)
    {
        yield return new WaitForSeconds(_waitSeconds);        
    }

    private void OnDrawGizmos()
    {
        if (target == null) return;

        Gizmos.color = Color.cyan;
        //Gizmos.color = new Color(0.468f, 0.284f, 0.752f);
        Gizmos.DrawLine(transform.position, target.transform.position);

        //calculo la distancia entre el enemigo y el target, y la comparo si es mejor a la zona de deteccion, el gizmo se pone rojo
        if (Vector2.Distance(transform.position, target.transform.position) < detectionRadius) Gizmos.color = Color.red;
        //sino la zona es verde
        else Gizmos.color = Color.green;
        //dibujo el gizmo
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        //calculo la distancia entre el enemigo y el target, y la comparo si es mejor a la zona de ataque, el gizmo se pone rojo
        if (Vector2.Distance(transform.position, target.transform.position) < attackRadius) Gizmos.color = Color.red;
        //sino la zona es verde
        else Gizmos.color = Color.green;
        //dibujo el gizmo
        Gizmos.DrawWireSphere(transform.position, attackRadius);

    }
}
