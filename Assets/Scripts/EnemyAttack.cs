using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _spawnerBullet;
    [SerializeField] private float _timeBullet;
    [SerializeField] private string animationName;
    public PlayerChecker playerChecker;
    public Animator animator;
    
    //Chequeo si el PJ esta en Layout - Cargo animacion de ataque - Cuando termina animacion de ataque lanzo bullet con daño puesto en bullet - Player Life chequea si le pegaron

    public void Awake()
    {

    }


    public void Update()
    {
        if (playerChecker.isPlayerHere == true)
        {
            animator.SetBool("isPlayerHere", true);
        }
        else animator.SetBool("isPlayerHere",false);
    }

    private void Shoot()
    {
        var copyBullet = Instantiate(_bullet, _spawnerBullet.position , _spawnerBullet.rotation);
        Destroy(copyBullet, _timeBullet);
    }
}
