using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMBoss1
{
    stateBoss1 currentstate;
    Dictionary<StateIDBoss1, stateBoss1> _states = new Dictionary<StateIDBoss1, stateBoss1>();

    public void AddState(StateIDBoss1 ID, stateBoss1 state)
    {
        _states.Add(ID, state);
        state.fsmBoss1 = this;
    }

    public void OnUpdate()
    {
        currentstate.OnStay();
    }

    public void ChangeState(StateIDBoss1 iD)
    {
        if (currentstate != null)
        {
            currentstate.OnExit();
        }
        currentstate = _states[iD];
        currentstate.OnEnter();
    }
}

public enum StateIDBoss1
{
    RestingBoss1,
    AttakingBoss1,
    WalkingBoss1,
    SpecialAttackBoss1
}
