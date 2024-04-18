using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    [SerializeField] float _objectLife;
    public float objectMaxLife;

    private void Start()
    {
        _objectLife = objectMaxLife;

        //la vida del objeto sera igual a la maxima
        _objectLife = objectMaxLife;
        Debug.Log($"{gameObject.name} tiene {_objectLife} de vida base.");
    }

    //el objeto recibe daño por parametro de la funcion al ser llamada
    public void LifeController(float damage)
    {
        _objectLife -= damage;
        LifeRemaining();
    }

    //se destruye al no tener vida o comenta la vida faltante
    void LifeRemaining()
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
