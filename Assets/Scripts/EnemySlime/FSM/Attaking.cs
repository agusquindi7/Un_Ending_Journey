using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attaking : state
{
    SlimeScript _mySlime;

    public Attaking(SlimeScript mySlime)
    {
        _mySlime = mySlime;
    }

    public override void OnEnter()
    {
        _mySlime.rb.velocity = Vector2.zero;
        Debug.LogWarning("ATTAKING");

        _mySlime.StartCoroutine(AttackCoroutine());
    }

    public override void OnExit()
    {
    }

    public override void OnStay()
    {
        _mySlime.rb.velocity = Vector2.zero;

    }

    private IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(_mySlime._waitSeconds); // Esperar antes de atacar
        Object.Instantiate(_mySlime.slimeBullet, _mySlime.spawner.transform.position, _mySlime.spawner.transform.rotation);
        yield return new WaitForSeconds(_mySlime._waitSeconds); // Esperar después de atacar

        fsm.ChangeState(StateID.Idle);
    }
}
