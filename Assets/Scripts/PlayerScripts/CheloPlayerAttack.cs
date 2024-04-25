using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheloPlayerAttack : MonoBehaviour
{
    [SerializeField] private float _swordCD, _swordCDRefresh;

    public Transform spawner;
    public GameObject swordBullet;

    public KeyCode KeyAttack;

    // Start is called before the first frame update
    void Start()
    {
        _swordCD = 1;
        _swordCDRefresh = 1;
    }      

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyAttack) && _swordCD <= 0)
        {
            Debug.Log($"Espadaso!");
            //myEnemySpeed = 0;
            Attack();
            //myEnemySpeed = myNormalSpeed;
        }
        if (_swordCD > 0) _swordCD -= Time.deltaTime;
    }
    

    private void Attack()
    {
        _swordCD = _swordCDRefresh;
        Instantiate(swordBullet, spawner.position, spawner.rotation);
    }
}
