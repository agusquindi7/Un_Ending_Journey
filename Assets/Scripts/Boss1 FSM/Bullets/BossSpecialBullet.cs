using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpecialBullet : MonoBehaviour
{
    [Header("Values")]
    public float damage;

    public GameObject target;
    public PlayerLife myPlayerLife;

    private void Awake()
    {
        damage = 20f;

        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
        else return;
    }

    private void Update()
    {
        if (target != null) return;
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
