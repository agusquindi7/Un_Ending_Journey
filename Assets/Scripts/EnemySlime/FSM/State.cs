using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//se pone el nombre del script en minuscula �porque? nomenclatura abstract?
public abstract class state
{
    public FSM fsm;

    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void OnStay();
}
