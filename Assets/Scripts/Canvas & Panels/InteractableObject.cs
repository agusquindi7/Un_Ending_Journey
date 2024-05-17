using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] GameObject interactableText;
    public bool isInteracting;

    private void Awake()
    {
        interactableText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) interactableText.SetActive(true);
        isInteracting = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) interactableText.SetActive(false);
        isInteracting = false;
    }
}
