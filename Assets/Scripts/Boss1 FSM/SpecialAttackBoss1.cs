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

        _myBossCharge.specialActivate = false;

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
        if (_myBossCharge.currentCharges > _myBossCharge.maxCharges)
        {
            //_myBossCharge.currentCharges = 1;
            fsmBoss1.ChangeState(StateIDBoss1.RestingBoss1);
        }

        //si el estado es verdadero ejecuta la corrutina
        else if (_myBossCharge.currentCharges <= _myBossCharge.maxCharges && _myBossCharge.specialActivate == true)
        {
            Debug.LogWarning("NumberCharges: " + _myBossCharge.currentCharges);

            _myBossCharge.specialActivate = false;
            //_myBossCharge.StartCoroutine(SpecialCoroutine());
            _myBossCharge.StartCoroutine(WaitAndExecuteCoroutine());            
        }        
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
            _myBossCharge.targetPos = _myBossCharge.target.transform.position;
            
            //Debug.Log("TrackTime es " + _myBossCharge.trackTime);
            //busca la posicion hacia el jugador mientras este dentro del while

            //_myBossCharge.direction = (_myBossCharge.target.transform.position - _myBossCharge.transform.position).normalized;

            //si es normalized pasa algo en la direccion?
            //_myBossCharge.direction = (_myBossCharge.target.transform.position - _myBossCharge.transform.position);

            _myBossCharge.trackTime += Time.deltaTime;

            //yield return null; //Espera hasta el siguiente frame
        }

        if (_myBossCharge.trackTime >= _myBossCharge.trackDuration)
            

        //setactive la flecha hacia el jugador        

        //un segundo de espera para que termine el track y vaya a BossBehavior
        yield return new WaitForSeconds(_myBossCharge.restTime * 0.3f);        
    }

    /*
    //hace el dash terminando su ejecucion, ahi activa el bool para activar corrutina si entra mas de 1 vez
    private IEnumerator BossBehavior()
    {
        Debug.Log("entro en BossBehavior");
        //SE LANZA HACIA LA DIRECCION CON UNA VELOCIDAD AUMENTADA
        //_myBossCharge.transform.position += _myBossCharge.direction * (_myBossCharge.speed * 2) * Time.deltaTime;

        //_myBossCharge.rb.MovePosition (_myBossCharge.direction * (_myBossCharge.speed * 2) * Time.deltaTime);
        //_myBossCharge.rb.MovePosition(_myBossCharge.direction);

        //_myBossCharge.rb.Move Toward (_myBossCharge.targetPos * (_myBossCharge.speed * 2) * Time.deltaTime);

        //Vector3 = (_myBossCharge.transform.position, 0

        float step = (_myBossCharge.speed * 2) * Time.deltaTime;
        //float step = _myBossCharge.speed * Time.deltaTime;

        //while (_myBossCharge.transform.position != _myBossCharge.targetPos)
        while (Vector3.Distance(_myBossCharge.rb.position, _myBossCharge.targetPos) > 0.1f)
        {
            //_myBossCharge.transform.position += Vector3.MoveTowards(_myBossCharge.transform.position, _myBossCharge.targetPos, step);
            
            _myBossCharge.rb.MovePosition(Vector3.MoveTowards(_myBossCharge.rb.position, _myBossCharge.targetPos, step));
            yield return null;
        }


        //********************************* Verificar si colisionó con una pared y se detiene???? ***************************************************************
        //if (_myBossCharge.collidingWithWall == true) _myBossCharge.rb.velocity = Vector2.zero;                  

        //Incrementa número de cargas al terminar el ataque y habilito un segundo ataque si es que no se pasa con las cargas
        _myBossCharge.currentCharges++;
        _myBossCharge.specialActivate = true;
        yield return null;        
    }
    */

    private IEnumerator BossBehavior()
    {
        Debug.Log("entro en BossBehavior");

        Vector3 startPosition = _myBossCharge.rb.position;
        Vector3 targetPosition = _myBossCharge.targetPos;

        // Calcula la distancia total y el tiempo total
        float totalDistance = Vector3.Distance(startPosition, targetPosition);
        float totalTime = totalDistance / (_myBossCharge.speed * 2); // Multiplica la velocidad por 2, según lo que quieras

        float elapsedTime = 0f;

        while (elapsedTime < totalTime)
        {
            // Calcula la nueva posición usando MoveTowards
            Vector3 newPosition = Vector3.MoveTowards(_myBossCharge.rb.position, targetPosition, _myBossCharge.speed * 2 * Time.deltaTime);

            // Mueve el Rigidbody2D a la nueva posición calculada
            _myBossCharge.rb.MovePosition(newPosition);

            // Incrementa el tiempo transcurrido
            elapsedTime += Time.deltaTime;

            yield return null; // Espera hasta el siguiente frame
        }

        // Asegúrate de que el jefe esté exactamente en la posición objetivo al finalizar
        _myBossCharge.rb.MovePosition(targetPosition);

        // Incrementa el número de cargas al terminar el ataque y habilita un segundo ataque si es que no se pasa con las cargas
        _myBossCharge.currentCharges++;
        _myBossCharge.specialActivate = true;
        yield return null;
    }

    //Calculo la cantidad de cargas maximas en el ataque
    public void NumberCharges()
    {
        //comparo la vida actual con la vida maxima en tantos % de vida
        if (_myBossCharge.myBossLife._objectLife > _myBossCharge.myBossLife.objectMaxLife * 0.75f)
            _myBossCharge.maxCharges = 1;
        else if (_myBossCharge.myBossLife._objectLife <= _myBossCharge.myBossLife.objectMaxLife * 0.75f && _myBossCharge.myBossLife._objectLife > _myBossCharge.myBossLife.objectMaxLife * 0.50f)
            _myBossCharge.maxCharges = 2;
        else if (_myBossCharge.myBossLife._objectLife <= _myBossCharge.myBossLife.objectMaxLife * 0.50f)
            _myBossCharge.maxCharges = 3;
    }

    private IEnumerator WaitAndExecuteCoroutine()
    {
        float waitTime = 0;
        float waitDuration = 0.3f;

        while (waitTime < waitDuration)
        {
            waitTime += Time.deltaTime;
            yield return null;
        }

        Debug.LogWarning("NumberCharges: " + _myBossCharge.currentCharges);

        _myBossCharge.StartCoroutine(SpecialCoroutine());
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.gameObject.CompareTag("Wall"))
        {
            _myBossCharge.collidingWithWall = true;
            //_myBossCharge.rb.velocity = Vector2.zero;

            //_myBossCharge.currentCharges++;
            //_myBossCharge.resting = true;
            //_myBossCharge.StartCoroutine(Rest());
        }
        */
        if (collision.CompareTag("Player"))
        {
            if (_myBossCharge.canDamage == true)
            {
                Debug.Log("Entra en el collider de daño");
                collision.GetComponent<PlayerLife>().LifeController(_myBossCharge.damage);
                _myBossCharge.canDamage = false;
            }
        }
    }
}
