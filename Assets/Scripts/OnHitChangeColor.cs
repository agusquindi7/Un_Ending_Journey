using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitChangeColor : MonoBehaviour
{
    [SerializeField] private Color normalColor;
    [SerializeField] private Color onHitColor = Color.red;
    [SerializeField] private SpriteRenderer mySR;
    [SerializeField] EnemyShootAttack enemyShoot;
    [SerializeField] EnemyWaypoints enemyWaypoints;


    private void Awake()
    {
        if (mySR==null) mySR = GetComponentInChildren<SpriteRenderer>();
        if (enemyShoot == null) enemyShoot = enemyShoot.GetComponentInChildren<EnemyShootAttack>();
        if (enemyWaypoints == null) enemyWaypoints.GetComponent<EnemyWaypoints>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerSword"))
        {
            StartCoroutine("ChangeColor");
        }  
    }
    
    IEnumerator ChangeColor()
    {
        if (enemyShoot != null && enemyWaypoints != null && mySR != null)
        {
            enemyWaypoints.enabled = false;
            enemyShoot.enabled = false;

            mySR.color = onHitColor;
            yield return new WaitForSeconds(0.5f);
            mySR.color = normalColor;

            enemyShoot.enabled = true;
            enemyWaypoints.enabled = true;
        }
        
    }
}
