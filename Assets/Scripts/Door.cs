using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform _previousRoom;
    [SerializeField] private Transform _nextRoom;

    [SerializeField] private IsaacCamera cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            if (collision.transform.position.y < transform.position.y)
            {
                cam.MoveToNewRoom(_nextRoom);
            }
            else cam.MoveToNewRoom(_previousRoom);
        }
    }
}
