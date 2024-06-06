using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypoints : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform[] _waypoints;
    public int currentWaypoint;

    public void Update()
    {
        //Chequeo antes de moverme al proximo waypoint si hice el recorrido completo y setteo el current Waypoint a 0

        if (transform.position != _waypoints[currentWaypoint].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, _waypoints[currentWaypoint].position, speed * Time.deltaTime);
        }
        else
        {
            currentWaypoint++;
        }

        if(currentWaypoint == _waypoints.Length)
        {
            currentWaypoint = 0;
        }
    }
}
