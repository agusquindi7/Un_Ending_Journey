using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;

    public PlayerLife myPlayerLife;

    private void Awake()
    {
        myPlayerLife = FindObjectOfType<PlayerLife>();
            //GetComponent<PlayerLife>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //collision.GetComponent<PlayerLife>();
            if (myPlayerLife._objectLife < myPlayerLife.objectMaxLife)
            {
                collision.GetComponent<PlayerLife>().LifeController(-health);
                Debug.Log($"{gameObject.name} curado");
                Destroy(gameObject);
            }
            else Debug.Log("Tiene toda la vida");
        }            
    }
}
