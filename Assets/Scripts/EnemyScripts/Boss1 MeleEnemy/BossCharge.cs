using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCharge : MonoBehaviour
{
    public BossLife myBossLife;

    [Header ("Normal")]
    public float speed = 5f;
    public float RandomNumber;
    //public float chargeTime = 2f;

    //tiempo de descanso, la multiplico en los codigos para que sea mayor o menor
    public float restTime = 1f;


    //public float cd = 2f;
    //public float cdReload = 5f;

    //public bool resting = false;

    [Header("Ataque Especial")]
    //ATAQUE ESPECIAL
    public Vector3 direction;
    public int currentCharges;
    public int maxCharges = 1;
    public bool collidingWithWall = false;
    public bool canDamage;

    public Rigidbody2D rb;
    public GameObject target;
    public GameObject bossBullet;

    public float damage = 10f;

    //public bool canAttack = false;
    //tiempo de busqueda del target
    public float trackTime = 0;
    public float trackDuration = 1;

    [Header("Ataque Normal")]
    //ATAQUE NORMAL
    public GameObject spawner;

    [Header("Caminar")]
    //WALKING
    //public float moveSpeed = 5f;
    public bool isMovingHorizontally = false;
    public bool isMovingVertically = false;

    public bool isStopped = false; //Controla si el enemigo esta quieto

    public float detectionRadius;
    public float attackRadius;

    public bool specialActivate;
    public Vector3 targetPos;

    //public GameObject bossSpecialBullet;


    FSMBoss1 myFsmBoss1;

    private void Awake()
    {
        myBossLife = FindObjectOfType<BossLife>();

        target = GameObject.FindGameObjectWithTag("Player");

        //cdReload = 3f;
        //cd = 0;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        myFsmBoss1 = new FSMBoss1();
        //myFsmBoss1.AddState(StateIDBoss1.Idle, new Idle(this));
        myFsmBoss1.AddState(StateIDBoss1.WalkingBoss1, new WalkingBoss1(this));

        myFsmBoss1.AddState(StateIDBoss1.AttakingBoss1, new AttakingBoss1(this));

        myFsmBoss1.AddState(StateIDBoss1.SpecialAttackBoss1, new SpecialAttackBoss1(this));


        myFsmBoss1.AddState(StateIDBoss1.RestingBoss1, new RestingBoss1(this));


        myFsmBoss1.ChangeState(StateIDBoss1.WalkingBoss1);
    }

    private void Update()
    {
        myFsmBoss1.OnUpdate();
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

    /*

    private void Awake()
    {
        myBossLife = FindObjectOfType<BossLife>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        StartCoroutine(BossBehavior());
    }

    private IEnumerator BossBehavior()
    {
        while (true)
        {
            NumberCharges();

            if (!resting)
            {
                for (int i = 0; i < maxCharges; i++)
                {
                    direction = (target.position - transform.position).normalized;

                    // Esperar tiempo de carga
                    yield return new WaitForSeconds(chargeTime);

                    // Lanzarse hacia el jugador
                    canDamage = true;
                    float elapsedTime = 0f;
                    collidingWithWall = false; // Reset colliding flag
                    while (elapsedTime < cdRefresh && !collidingWithWall)
                    {
                        transform.position += direction * speed * Time.deltaTime;
                        elapsedTime += Time.deltaTime;
                        yield return null;
                    }

                    // Verificar si colisionó con una pared
                    if (collidingWithWall)
                    {
                        break;
                    }

                    // Incrementar número de cargas
                    currentCharges++;
                }

                if (collidingWithWall || currentCharges >= maxCharges)
                {
                    resting = true;
                    yield return Rest();
                }
            }

            if (resting)
            {
                yield return Rest();
            }
        }
    }

    private IEnumerator Rest()
    {
        yield return new WaitForSeconds(restTime);
        resting = false;
        currentCharges = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            collidingWithWall = true;
            currentCharges++;
            resting = true;
            StartCoroutine(Rest());
        }

        else if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerLife>().LifeController(damage);
            canDamage = false;
        }
    }

    private void NumberCharges()
    {
        if (myBossLife._objectLife > myBossLife._objectLife * 0.75f)
            maxCharges = 1;
        else if (myBossLife._objectLife <= myBossLife._objectLife * 0.75f && myBossLife._objectLife > myBossLife._objectLife * 0.50f)
            maxCharges = 2;
        else if (myBossLife._objectLife <= myBossLife._objectLife * 0.50f)
            maxCharges = 3;
    }
    */
}