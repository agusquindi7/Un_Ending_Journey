using UnityEngine;

public class LavaGolemFollow : MonoBehaviour
{
    public Transform player;            // Referencia al jugador
    public float moveSpeed = 2f;         // Velocidad de movimiento del enemigo
    public float attackRange = 1f;       // Rango de ataque del enemigo
    public GameObject hitboxPrefab;      // Prefab de la hitbox
    public float attackCooldown = 3f;    // Tiempo de enfriamiento entre ataques

    private float lastAttackTime;        // Tiempo del último ataque

    public Animator animator;

    public string attackTrigger, deathBool, walkingBool;

    public CheloEnemyLife enemyLife;
    void Update()
    {
        // Calcular la distancia al jugador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Si el jugador está dentro del rango de ataque
        if (distanceToPlayer <= attackRange)
        {
            animator.SetBool(walkingBool, false);
            // Intentar atacar
            TryAttack();
        }
        else
        {
            animator.SetBool(walkingBool, true);
            // Seguir al jugador
            FollowPlayer();
        }

        //Chequeo si se muere
        if (enemyLife._objectLife <= 0)
        {
            animator.SetBool(deathBool, true);
            Destroy(gameObject, 1f);
        }
    }

    void FollowPlayer()
    {
        // Calcular la dirección hacia el jugador
        Vector2 direction = (player.position - transform.position).normalized;

        // Mover al enemigo hacia el jugador
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    void TryAttack()
    {
        // Verificar si ha pasado el tiempo suficiente desde el último ataque
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            animator.SetTrigger(attackTrigger);
            // Instanciar la hitbox en la posición del enemigo
            Instantiate(hitboxPrefab, transform.position, Quaternion.identity);

            // Actualizar el tiempo del último ataque
            lastAttackTime = Time.time;
        }
    }
}