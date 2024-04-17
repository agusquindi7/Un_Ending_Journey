using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    float _life;
    [SerializeField] float _maxLife = 100;

    //CANVAS DE VIDA Y PANEL
    //public CanvasManager myCanvas;
    //public GameObject defeatPanel;

    // Start is called before the first frame update
    void Start()
    {
        _life = _maxLife;
        Debug.Log($"{this.gameObject.name} tiene {_life}");

        //AdjustCanvas();
    }

    // Update is called once per frame
    void Update()
    {
        //DAÑO VENENO A FUTURO PENDIENTE
        /*
        //El daño por veneno de los enemigos
        if(poisoned && damageCooldown >= damageCooldownRefresh)
        {
            LifeController(-poisonDamage);
            damageCooldown = 0;
        }
        if (damageCooldown < damageCooldownRefresh) damageCooldown += Time.deltaTime;
        */

    }

    //controlador de vida
    public void LifeController(float value)
    {

        //_life += value;
        //if (_life > _maxLife) _life = _maxLife;
        
        _life = Mathf.Clamp(_life + value, 0, _maxLife);

        LifeRemaining();
    }

    public void LifeRemaining()
    {
        //_Life -= damage;
        //CANVAS DE LA BARRA DE VIDA
        //AdjustCanvas();
        //si es menor a 0 se destruye el personaje, sino debugueo la vida actual
        if (_life <= 0)
        {
            Destroy(gameObject);
            //defeatPanel.SetActive(true);

        }
        else Debug.Log($"{gameObject.name} le queda {_life} de vida actual.");
    }

    //retorno valores de vida y vida maxima
    float GetLifeValue() { return _life; }
    public float GetMaxLifeValue() { return _maxLife; }

    /*
    //CANVAS DE LA VIDA    
    private void AdjustCanvas()
    {
        myCanvas.UpdateMyLife(_life, _maxLife);
    }
    */
}
