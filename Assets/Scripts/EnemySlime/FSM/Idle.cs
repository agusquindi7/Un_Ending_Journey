using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : state
{   
    SlimeScript _mySlime;

    public Idle(SlimeScript mySlime)
    {
        _mySlime = mySlime;
        
    }

    //se ejecuta al entrar del estado
    public override void OnEnter()
    {
        Debug.LogWarning("IDLE");
        _mySlime.rb.velocity = Vector2.zero;
    }
    //se ejecuta al salir del estado
    public override void OnExit()
    {
    }
    //update
    public override void OnStay()
    {
        _mySlime.rb.velocity = Vector2.zero;

        if (Vector2.Distance(_mySlime.transform.position, _mySlime.target.transform.position) <
        _mySlime.detectionRadius && Vector2.Distance(_mySlime.transform.position, _mySlime.target.transform.position) > _mySlime.attackRadius)
        {
            fsm.ChangeState(StateID.Walking);
        }        
    }
}
