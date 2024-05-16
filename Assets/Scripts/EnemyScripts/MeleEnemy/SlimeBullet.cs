using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBullet : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] float _deadTimer;
    public float damage;
    //public GameObject slowZone;
    //public bool slowbool = false;

    //public Transform target;

    public GameObject target;
    public PlayerLife myPlayerLife;

    private void Awake()
    {
        _deadTimer = 1;
        damage = 10f;

        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
        else return;

    }

    private void Start()
    {
        Destroy(gameObject, _deadTimer);
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
