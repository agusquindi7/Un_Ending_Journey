using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockedPadlock : MonoBehaviour
{
    public string tagPlayer;
    public string triggerBlocked, triggerUnlocked;
    private Animator anim;
    public AudioManager audioCandado;
    [SerializeField] GameObject enemigo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagPlayer))
        {
            anim = GetComponent<Animator>();
            if (enemigo != null) anim.SetTrigger(triggerBlocked);
            else
            {
                anim.SetTrigger(triggerUnlocked);
            }
        }
    }

    public void BreakPadlock()
    {
        Destroy(gameObject);
    }

    public void BrokenSound()
    {
        if (audioCandado == null)
        {
            audioCandado = GetComponent<AudioManager>();
            audioCandado.SeleccionAudio(6, 1f);
        }
        else audioCandado.SeleccionAudio(6, 1f);
    }
}
