using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsaacCamera : MonoBehaviour
{
    //Varios colliders en los layouts, si estoy pisando el trigger del layout tal, lo sigo con la camara
    public Transform target;
    public Transform[] layouts = new Transform [4];

    private void OnTriggerEnter2D(Collider2D collision)
    {

        
    }

}
