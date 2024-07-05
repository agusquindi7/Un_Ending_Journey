using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : DestructibleObject
{
    //CANVAS DE VIDA
    public CanvasManager myCanvas;

    //PANEL DE DERROTA
    //public GameObject defeatPanel;

    //EL AWAKE DEL SCRIPT PADRE IGUALA _objectLife = objectMaxLife

    public void Start()
    {
        Debug.Log($"PLAYER: vida {_objectLife} y vida maxima {objectMaxLife}");
        AdjustCanvas();      
    }

    /*
    //controlador de vida
    public void LifeController(float value)
    {

        //_life += value;
        //if (_life > _maxLife) _life = _maxLife;
        
        //_life = Mathf.Clamp(_life + value, 0, _maxLife);

        LifeRemaining();
    }
    */

    public override void LifeRemaining()
    {
        //CANVAS DE LA BARRA DE VIDA
        AdjustCanvas();
        base.LifeRemaining();
        if (_objectLife <= 0)
        {
            SceneManager.LoadScene (SceneManager.GetActiveScene().name);
        }
    }
    
    //CANVAS DE LA BARRA DE VIDA
    public void AdjustCanvas()
    {
        //paso por parametro la vida y la vida maxima al metodo UpdateMyLife() en el script del Canvas
        myCanvas.UpdateMyLife(_objectLife, objectMaxLife);
    }
    
}
