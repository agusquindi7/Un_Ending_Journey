using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheloEnemyLife : DestructibleObject
{
    //Añado el animador y desde aca pregunto si vida es menor a 0
    public Animator enemyAnim;
    public EnemyShootAttack enemyShootAttack;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Enemigo con Script");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void LifeRemaining()
    {
        if (_objectLife <= 0) 
        {
            enemyAnim.SetBool("isReadyToAttack",false);
            enemyAnim.SetTrigger("isDead");
            enemyShootAttack.enabled = false;
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
