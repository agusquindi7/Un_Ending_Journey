using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttakingBoss1 : stateBoss1
{
    BossCharge _myBossCharge;

    public AttakingBoss1 (BossCharge myBossCharge)
    {
        _myBossCharge = myBossCharge;
    }

    public override void OnEnter()
    {
        //Genero un numero al azar para que haga el ataque especial luego de hacer el ataque normal
        _myBossCharge.RandomNumber = Random.Range(50, 101);

        Debug.LogWarning("el numero random es: " + _myBossCharge.RandomNumber);

        _myBossCharge.rb.velocity = Vector2.zero;
        Debug.LogWarning("ATTAKING");

        _myBossCharge.animator.SetTrigger("isAttacking");

        _myBossCharge.StartCoroutine(AttackCoroutine());

    }

    public override void OnExit()
    {
        //_myBossCharge.rb.velocity = Vector2.zero;
    }

    public override void OnStay()
    {
        _myBossCharge.rb.velocity = Vector2.zero;
    }

    private IEnumerator AttackCoroutine()
    {
        //yield return new WaitForSeconds(_myBossCharge.restTime*0.5f); //Espera antes de atacar
        Object.Instantiate(_myBossCharge.bossBullet, _myBossCharge.spawner.transform.position, _myBossCharge.spawner.transform.rotation);
        yield return new WaitForSeconds(_myBossCharge.restTime*0.1f); //Espera después de atacar

        if (_myBossCharge.RandomNumber >= 50) fsmBoss1.ChangeState(StateIDBoss1.SpecialAttackBoss1);

        else if (_myBossCharge.RandomNumber < 50) fsmBoss1.ChangeState(StateIDBoss1.WalkingBoss1);
    }
}
