using UnityEngine;

public class LavaGolemHitbox : MonoBehaviour
{
    public float lifeTime = 0.5f; // Duraci�n de la hitbox
    public float damage;
    void Start()
    {
        // Destruir la hitbox despu�s de un tiempo
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si la hitbox colisiona con el jugador
        if (other.CompareTag("Player"))
        {
            //PlayerLife playerLife = other.GetComponent<PlayerLife>();
            other.GetComponent<PlayerLife>().LifeController(damage);

            // Aqu� puedes aplicar da�o al jugador
            //playerLife._objectLife -= damage;

            // Destruir la hitbox
            Destroy(gameObject);
        }
    }
}