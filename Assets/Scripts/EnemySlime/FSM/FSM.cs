using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM
{
    state currentstate;
    Dictionary<StateID, state> _states = new Dictionary<StateID, state> ();

    public void AddState(StateID ID, state state)
    {
        _states.Add(ID, state);
        state.fsm = this;
    }

    public void OnUpdate()
    {
        currentstate.OnStay();
    }

    public void ChangeState(StateID iD)
    {
        if (currentstate != null)
        {
            currentstate.OnExit();
        }
        currentstate = _states[iD];
        currentstate.OnEnter();
    }
}


public enum StateID
{
    Idle,
    Attaking,
    Walking
}