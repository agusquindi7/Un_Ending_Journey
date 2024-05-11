using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpacityObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10) collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10) collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
    }
}
