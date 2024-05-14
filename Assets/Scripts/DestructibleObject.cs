using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestructibleObject : MonoBehaviour
{
    //Chelo tuve que cambiarlo a publico porque no me dejaba acceder
    [SerializeField] public float _objectLife;
    public float objectMaxLife;

    public void Awake()
    {
        //la vida del objeto sera igual a la maxima
        _objectLife = objectMaxLife;
        Debug.Log($"{gameObject.name} tiene {_objectLife} de vida base.");
    }

    //el objeto recibe daño por parametro de la funcion al ser llamada
    public virtual void LifeController(float damage)
    {
        //_objectLife -= damage;
        if (_objectLife > objectMaxLife) _objectLife = objectMaxLife;

        //el daño que reciba se va a restar a la vida actual. Esta clampeado, no puede salir de los limites de 0 y la vida maxima
        _objectLife = Mathf.Clamp(_objectLife - damage, 0, objectMaxLife);
        LifeRemaining();
    }

    //se destruye al no tener vida o comenta la vida faltante
    public virtual void LifeRemaining()
    {
        if (_objectLife <= 0)
        {
            Debug.Log($"{gameObject.name} destruido");
            Destroy(gameObject);
        }
        else Debug.Log($"{gameObject.name} le queda {_objectLife} de vida.");
    }

    public float GetLifeValue() { return _objectLife; }
    public float GetMaxLifeValue() { return objectMaxLife; }
}
