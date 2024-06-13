using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockedPadlock : MonoBehaviour
{
    public string tagPlayer;
    public string triggerBlocked, triggerUnlocked;
    private Animator anim;
    [SerializeField] GameObject enemigo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagPlayer))
        {
            anim = GetComponent<Animator>();
            if (enemigo != null) anim.SetTrigger(triggerBlocked);
            else anim.SetTrigger(triggerUnlocked);
        }
    }
}
