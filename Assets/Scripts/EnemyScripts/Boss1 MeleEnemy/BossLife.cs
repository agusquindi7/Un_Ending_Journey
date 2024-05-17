using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossLife : DestructibleObject
{
    public CanvasBoss myBossCanvas;
    public GameObject darkParticles;


    //EL AWAKE DEL SCRIPT PADRE IGUALA _objectLife = objectMaxLife

    void Start()
    {
        Debug.Log($"PLAYER: vida {_objectLife} y vida maxima {objectMaxLife}");
        darkParticles.SetActive(false);
        AdjustCanvas();
    }
    
    public override void LifeRemaining()
    {
        //CANVAS DE LA BARRA DE VIDA
        AdjustCanvas();

        if (_objectLife <= objectMaxLife/2) darkParticles.SetActive(true);
        base.LifeRemaining();


        //ACA DEBERIA INICIAR OTRO NIVEL AGUS?
        if (_objectLife <= 0) SceneManager.LoadScene(6);


    }

    //CANVAS DE LA BARRA DE VIDA
    public void AdjustCanvas()
    {
        //paso por parametro la vida y la vida maxima al metodo UpdateMyLife() en el script del Canvas
        myBossCanvas.UpdateMyLife(_objectLife, objectMaxLife);
    }
}
