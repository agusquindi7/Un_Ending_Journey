using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingBoss1 : stateBoss1
{
    BossCharge _myBossCharge;

    public WalkingBoss1 (BossCharge myBossCharge)
    {
        _myBossCharge = myBossCharge;
    }

    public override void OnEnter()
    {
        Debug.LogWarning("WALKING");
    }

    public override void OnExit()
    {
        _myBossCharge.rb.velocity = Vector2.zero;
    }

    public override void OnStay()
    {
        /*
         * si la distancia es mayor a la zona de deteccion entra en idle, pero aca no necesito Idle
        if (Vector2.Distance(_myBossCharge.transform.position, _myBossCharge.target.transform.position) > _myBossCharge.detectionRadius)
        {
            fsmBoss1.ChangeState(StateID.Idle);
        }
        animator.SetBool("isWalking",false);
        */

        _myBossCharge.animator.SetBool("isWalking",true);



        //si la distancia es menor o igual, entra en estado de ataque
        if (Vector2.Distance(_myBossCharge.transform.position, _myBossCharge.target.transform.position) <= _myBossCharge.attackRadius)
        {
            fsmBoss1.ChangeState(StateIDBoss1.AttakingBoss1);
        }


        if (!_myBossCharge.isMovingHorizontally && !_myBossCharge.isMovingVertically)
        {
            //Se mueve mueve primero horizontalmente si la diferencia en X es mayor que Y
            if (Mathf.Abs(_myBossCharge.target.transform.position.x - _myBossCharge.transform.position.x) > Mathf.Abs(_myBossCharge.target.transform.position.y - _myBossCharge.transform.position.y))
            {
                _myBossCharge.rb.velocity = new Vector2(Mathf.Sign(_myBossCharge.target.transform.position.x - _myBossCharge.transform.position.x) * _myBossCharge.speed, 0f);
                _myBossCharge.isMovingHorizontally = true;

            }
            else
            {
                //Si la diferencia en Y es mayor que X, va a moverse verticalmente
                _myBossCharge.rb.velocity = new Vector2(0f, Mathf.Sign(_myBossCharge.target.transform.position.y - _myBossCharge.transform.position.y) * _myBossCharge.speed);
                _myBossCharge.isMovingVertically = true;

            }
        }

        else if (_myBossCharge.isMovingHorizontally)
        {
            //Se mueve horizontalmente hasta alcanzar la misma coordenada X que el jugador
            if (Mathf.Abs(_myBossCharge.target.transform.position.x - _myBossCharge.transform.position.x) > 0.1f)
            {
                _myBossCharge.rb.velocity = new Vector2(Mathf.Sign(_myBossCharge.target.transform.position.x - _myBossCharge.transform.position.x) * _myBossCharge.speed, 0f);
            }
            //Si la distancia es la misma apago el bool horizontal
            else
            {
                _myBossCharge.rb.velocity = Vector2.zero;
                _myBossCharge.isMovingHorizontally = false;
            }
        }

        else if (_myBossCharge.isMovingVertically)
        {
            //Se mueve verticalmente hasta alcanzar la misma coordenada Y que el jugador
            if (Mathf.Abs(_myBossCharge.target.transform.position.y - _myBossCharge.transform.position.y) > 0.1f)
            {
                _myBossCharge.rb.velocity = new Vector2(0f, Mathf.Sign(_myBossCharge.target.transform.position.y - _myBossCharge.transform.position.y) * _myBossCharge.speed);
            }

            //Si la distancia es la misma apago el bool vertical
            else
            {
                _myBossCharge.rb.velocity = Vector2.zero;
                _myBossCharge.isMovingVertically = false;
            }
        }
    }
}
