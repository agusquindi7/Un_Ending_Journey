using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestingBoss1 : stateBoss1
{
    BossCharge _myBossCharge;

    public RestingBoss1 (BossCharge myBossCharge)
    {
        _myBossCharge = myBossCharge;
    }

    public override void OnEnter()
    {
        _myBossCharge.rb.velocity = Vector2.zero;
        Debug.LogWarning("RESTING");

        _myBossCharge.StartCoroutine(RestCoroutine());

    }

    public override void OnExit()
    {
        //_myBossCharge.rb.velocity = Vector2.zero;
    }

    public override void OnStay()
    {
        _myBossCharge.rb.velocity = Vector2.zero;

    }

    private IEnumerator RestCoroutine()
    {
        yield return new WaitForSeconds(_myBossCharge.restTime*1.5f); //Espera
        //yield return new WaitForSeconds(_myBossCharge.restTime); // Esperar después de atacar

        fsmBoss1.ChangeState(StateIDBoss1.WalkingBoss1);
    }
}
