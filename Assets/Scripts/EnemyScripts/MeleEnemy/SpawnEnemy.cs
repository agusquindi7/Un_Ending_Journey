using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Tooltip("Que enemigos se van a spawnear")] public GameObject enemyToSpawn;
    public Transform spawner;

    [Tooltip("Cuantos enemigos van a spawnear al destruirse el objeto original")] public int spawnCount;

    public float radius = 1f;

    private void OnDestroy()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            /*
            //PROBLEMA, SE INSTANCIA CON LA ROTACION DEL SPAWNER
            //Instantiate(enemyToSpawn, spawner.position, spawner.rotation);

            //SOLUCIONADO, SE INSTANCIA CON EN EL SPAWNER Y LA ROTACION DEL PADRE
            Instantiate(enemyToSpawn, spawner.position, transform.rotation);
            */

            float angle = i * Mathf.PI * 2 / spawnCount;
            Vector3 spawnPosition = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius + spawner.position;

            Instantiate(enemyToSpawn, spawnPosition, transform.rotation);
        }
    
    }
}
