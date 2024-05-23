using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : state
{
    SlimeScript _mySlime;

    public Walking(SlimeScript mySlime)
    {
        _mySlime = mySlime;
    }

    public override void OnEnter()
    {
        Debug.LogWarning("WALKING");

    }

    public override void OnExit()
    {
        _mySlime.rb.velocity = Vector2.zero;
    }

    public override void OnStay()
    {
        if (Vector2.Distance(_mySlime.transform.position, _mySlime.target.transform.position) > _mySlime.detectionRadius)
        {
            fsm.ChangeState(StateID.Idle);
        }

        if (Vector2.Distance(_mySlime.transform.position, _mySlime.target.transform.position) <= _mySlime.attackRadius)
        {
            fsm.ChangeState(StateID.Attaking);
        }

        if (!_mySlime.isMovingHorizontally && !_mySlime.isMovingVertically)
        {
            //Se mueve mueve primero horizontalmente si la diferencia en X es mayor que Y
            if (Mathf.Abs(_mySlime.target.transform.position.x - _mySlime.transform.position.x) > Mathf.Abs(_mySlime.target.transform.position.y - _mySlime.transform.position.y))
            {
                _mySlime.rb.velocity = new Vector2(Mathf.Sign(_mySlime.target.transform.position.x - _mySlime.transform.position.x) * _mySlime.moveSpeed, 0f);
                _mySlime.isMovingHorizontally = true;

            }
            else
            {
                //Si la diferencia en Y es mayor que X, va a moverse verticalmente
                _mySlime.rb.velocity = new Vector2(0f, Mathf.Sign(_mySlime.target.transform.position.y - _mySlime.transform.position.y) * _mySlime.moveSpeed);
                _mySlime.isMovingVertically = true;

            }
        }

        else if (_mySlime.isMovingHorizontally)
        {
            //Se mueve horizontalmente hasta alcanzar la misma coordenada X que el jugador
            if (Mathf.Abs(_mySlime.target.transform.position.x - _mySlime.transform.position.x) > 0.1f)
            {
                _mySlime.rb.velocity = new Vector2(Mathf.Sign(_mySlime.target.transform.position.x - _mySlime.transform.position.x) * _mySlime.moveSpeed, 0f);
            }
            //Si la distancia es la misma apago el bool horizontal
            else
            {
                _mySlime.rb.velocity = Vector2.zero;
                _mySlime.isMovingHorizontally = false;
            }
        }

        else if (_mySlime.isMovingVertically)
        {
            //Se mueve verticalmente hasta alcanzar la misma coordenada Y que el jugador
            if (Mathf.Abs(_mySlime.target.transform.position.y - _mySlime.transform.position.y) > 0.1f)
            {
                _mySlime.rb.velocity = new Vector2(0f, Mathf.Sign(_mySlime.target.transform.position.y - _mySlime.transform.position.y) * _mySlime.moveSpeed);
            }

            //Si la distancia es la misma apago el bool vertical
            else
            {
                _mySlime.rb.velocity = Vector2.zero;
                _mySlime.isMovingVertically = false;
            }
        }
    }
}
