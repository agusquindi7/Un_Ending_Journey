using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleBullet : MonoBehaviour
{
    public float deadTimer;
    public float damage;

    private void Awake()
    {
        damage = 10f;
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, deadTimer);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerLife>().LifeController(damage);
            Debug.Log($"{gameObject.name} Golpeado");
            Destroy(gameObject);
        }
    }
}
