using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttackBoss1 : stateBoss1
{
    //ESTOY GUARDANDO LA DIRECCION, Y ESTOY DIRIGIENDO AL BOSS HACIA LA DIRECCION, PERO TAL VEZ NO A LA DIRECCION EXACTA? TAL VEZ POR ESO CRUZA LA PARED
    //AL ENTRAR NO HACE EL METODO NUMBERCHARGES() AUNQUE TENGA MENOS DE LA MITAD DE VIDA SIEMPRE TIENE 1 CARGA MAXIMA
    BossCharge _myBossCharge;

    public SpecialAttackBoss1 (BossCharge myBossCharge)
    {
        _myBossCharge = myBossCharge;
    }

    public override void OnEnter()
    {
        _myBossCharge.rb.velocity = Vector2.zero;
        Debug.LogWarning("SPECIAL ATTACK");

        //al entrar en el estado se prepara la cantidad de cargas, asi evito que cambie durante el estado
        NumberCharges();
        _myBossCharge.currentCharges = 1;
        Debug.LogWarning("NumberCharges: " + _myBossCharge.currentCharges);
        Debug.LogWarning("MaxCharges: " + _myBossCharge.maxCharges);


        _myBossCharge.StartCoroutine(SpecialCoroutine());
    }

    public override void OnExit()
    {
        _myBossCharge.rb.velocity = Vector2.zero;
    }

    public override void OnStay()
    {
        //Si las cargas actuales son mayores al maximo de cargas, el estado cambia a descanso y se reinician las cargas
        if (_myBossCharge.currentCharges >= _myBossCharge.maxCharges)
        {
            //_myBossCharge.currentCharges = 1;
            fsmBoss1.ChangeState(StateIDBoss1.RestingBoss1);
        }

        else _myBossCharge.StartCoroutine(SpecialCoroutine());
        
    }

    //CORRUTINA SECUENCIAL
    private IEnumerator SpecialCoroutine()
    {
        Debug.Log("entro en SpecialCorutine");
        _myBossCharge.rb.velocity = Vector2.zero;

        //Primero busco la posicion
        yield return _myBossCharge.StartCoroutine(TrackPosition());

        //*******************************************
        //_myBossCharge.collidingWithWall = false; // Reset colliding flag
        _myBossCharge.canDamage = true;


        //Se desplaza
        yield return _myBossCharge.StartCoroutine(BossBehavior());
    }

    //BUSCA LA POSICION DEL JUGADOR
    private IEnumerator TrackPosition()
    {
        Debug.Log("entro en TrackPosition y TrackTime es " + _myBossCharge.trackTime);

        _myBossCharge.trackTime = 0;
        //evito que se mueva al buscar la posicion
        _myBossCharge.rb.velocity = Vector2.zero;

        while (_myBossCharge.trackTime < _myBossCharge.trackDuration)
        {
            _myBossCharge.trackTime += Time.deltaTime;
            //Debug.Log("TrackTime es " + _myBossCharge.trackTime);
            //busca la posicion hacia el jugador mientras este dentro del while
            _myBossCharge.direction = (_myBossCharge.target.transform.position - _myBossCharge.transform.position).normalized;
            //yield return null; //Espera hasta el siguiente frame
        }

        if (_myBossCharge.trackTime >= _myBossCharge.trackDuration)
            

        //setactive la flecha hacia el jugador        

        //un segundo de espera para que termine el track y vaya a BossBehavior
        yield return new WaitForSeconds(_myBossCharge.restTime * 0.7f);        
    }


    private IEnumerator BossBehavior()
    {
        Debug.Log("entro en BossBehavior");
        //SE LANZA HACIA LA DIRECCION CON UNA VELOCIDAD AUMENTADA
        _myBossCharge.transform.position += _myBossCharge.direction * (_myBossCharge.speed * 2) * Time.deltaTime;
        //yield return null;


        //*********************************Verificar si colisionó con una pared y se detiene***************************************************************
        //if (_myBossCharge.collidingWithWall == true) _myBossCharge.rb.velocity = Vector2.zero;                    
        

        //Incrementa número de cargas al terminar el ataque
        _myBossCharge.currentCharges++;
        yield return null;        
    }

    //Calculo la cantidad de cargas maximas en el ataque
    public void NumberCharges()
    {
        if (_myBossCharge.myBossLife._objectLife > _myBossCharge.myBossLife._objectLife * 0.75f)
            _myBossCharge.maxCharges = 1;
        else if (_myBossCharge.myBossLife._objectLife <= _myBossCharge.myBossLife._objectLife * 0.75f && _myBossCharge.myBossLife._objectLife > _myBossCharge.myBossLife._objectLife * 0.50f)
            _myBossCharge.maxCharges = 2;
        else if (_myBossCharge.myBossLife._objectLife <= _myBossCharge.myBossLife._objectLife * 0.50f)
            _myBossCharge.maxCharges = 3;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            _myBossCharge.collidingWithWall = true;
            //_myBossCharge.rb.velocity = Vector2.zero;


            //_myBossCharge.currentCharges++;
            //_myBossCharge.resting = true;
            //_myBossCharge.StartCoroutine(Rest());
        }

        else if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerLife>().LifeController(_myBossCharge.damage);
            _myBossCharge.canDamage = false;
        }
    }
}
