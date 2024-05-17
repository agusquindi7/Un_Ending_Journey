using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCharge : MonoBehaviour
{
    public BossLife myBossLife;
    private Transform target;

    public float speed = 5f;
    public float chargeTime = 2f;
    public float restTime = 3f;
    public float cdRefresh = 2f;
    public float cdRefreshRest = 5f;

    private bool resting = false;
    private bool collidingWithWall = false;
    public int maxCharges = 1;
    private int currentCharges;
    private Vector3 direction;

    public float damage = 10f;
    public bool canDamage;

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
}