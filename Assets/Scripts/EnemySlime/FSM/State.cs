using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class state
{
    public FSM fsm;

    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void OnStay();
}
