using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitChangeColor : MonoBehaviour
{
    [SerializeField] private Color normalColor;
    [SerializeField] private Color onHitColor = Color.red;
    [SerializeField] private SpriteRenderer mySR;

    private void Awake()
    {
        mySR = GetComponentInParent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerSword"))
        {
            StartCoroutine("ChangeColor");
        }  
    }
    
    IEnumerator ChangeColor()
    {
        mySR.color = onHitColor;
        yield return new WaitForSeconds(0.5f);
        mySR.color = normalColor;
    }
}
