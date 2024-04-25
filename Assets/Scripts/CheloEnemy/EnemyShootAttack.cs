using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootAttack : MonoBehaviour
{
    public float attackRadius;
    public GameObject enemyBullet;
    public Transform bulletSpawner;
    public GameObject target;

    //private GameObject _playerObject;
    
    [SerializeField] private float _shootCooldown;
    [SerializeField] private float cooldownReloader = 1f;


    private void Awake()
    {
        //encuentro target
        //if (_playerObject == null) _playerObject = GameObject.FindGameObjectWithTag("Player");
        //if (target == null) target = FindObjectOfType<PlayerLife>().transform;

        attackRadius = 10f;

        if (target == null) target = GameObject.FindGameObjectWithTag("Player");
        
        else return;      
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        //distancia toma 2 variables: la posicion del enemigo y la del target, y saca su distancia entre ellos
        float distance = Vector2.Distance(transform.position, target.transform.position);

        //if (distance < attackRadius && distance >= attackRadius)
        if (distance <= attackRadius)

            {
                Debug.Log($"entra en radio");

            //dispara si no hay cd y rota hacia el personaje
            //RotationToThePlayer();
            if (_shootCooldown <= 0)
            {
                Debug.Log($"dispara!");
                //myEnemySpeed = 0;
                Shoot();
                //myEnemySpeed = myNormalSpeed;
            }         
        }

        if (_shootCooldown > 0) _shootCooldown -= Time.deltaTime;
    }

    private void Shoot()
    {
        
        //spawnea una bullet en el spawner y el cd se iguala a 1
        _shootCooldown = cooldownReloader;
        Instantiate(enemyBullet, bulletSpawner.position, bulletSpawner.rotation);
        

        /*
        // Calcula la dirección hacia el jugador
        Vector3 direction = (target.transform.position - bulletSpawner.position).normalized;

        // Calcula la rotación necesaria para apuntar hacia el jugador
        Quaternion rotation = Quaternion.LookRotation(direction);

        // Instancia la bala con la rotación ajustada
        Instantiate(enemyBullet, bulletSpawner.position, rotation);
        _shootCooldown = cooldownReloader;
        */

    }

    private void OnDrawGizmos()
    {
        if (target == null) return;

        Gizmos.color = Color.cyan;
        //Gizmos.color = new Color(0.468f, 0.284f, 0.752f);
        Gizmos.DrawLine(transform.position, target.transform.position);

        //calculo la distancia entre el enemigo y el target, y la comparo si es mejor a la zona de deteccion, el gizmo se pone rojo
        if (Vector2.Distance(transform.position, target.transform.position) < attackRadius) Gizmos.color = Color.red;
        //sino la zona es verde
        else Gizmos.color = Color.green;
        //dibujo el gizmo
        Gizmos.DrawWireSphere(transform.position, attackRadius);

        //calculo la distancia entre el enemigo y el target, y la comparo si es mejor a la zona de ataque, el gizmo se pone rojo
        if (Vector2.Distance(transform.position, target.transform.position) < attackRadius) Gizmos.color = Color.red;
        //sino la zona es verde
        else Gizmos.color = Color.green;
        //dibujo el gizmo
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
