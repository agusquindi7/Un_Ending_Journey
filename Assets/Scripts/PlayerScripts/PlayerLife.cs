using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    //CANVAS DE VIDA Y PANEL
    //public CanvasManager myCanvas;
    //public GameObject defeatPanel;

    // Start is called before the first frame update
    void Start()
    {
        //AdjustCanvas();
    }


    //controlador de vida
    public void LifeController(float value)
    {

        //_life += value;
        //if (_life > _maxLife) _life = _maxLife;
        
        //_life = Mathf.Clamp(_life + value, 0, _maxLife);

        LifeRemaining();
    }

    public void LifeRemaining()
    {
        //CANVAS DE LA BARRA DE VIDA
        //AdjustCanvas();

        /*
        //si es menor a 0 se destruye el personaje, sino debugueo la vida actual
        if (_life <= 0)
        {
            Destroy(gameObject);
            //defeatPanel.SetActive(true);

        }
        */
    }    

    /*
    //CANVAS DE LA VIDA    
    private void AdjustCanvas()
    {
        myCanvas.UpdateMyLife(_life, _maxLife);
    }
    */
}
