using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyButton : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        animator.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.anyKeyDown) animator.SetTrigger("isMoving");
    }
}
