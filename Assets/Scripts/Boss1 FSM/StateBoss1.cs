using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class stateBoss1
{
    public FSMBoss1 fsmBoss1;

    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void OnStay();
}
