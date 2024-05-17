using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogos : MonoBehaviour
{
    public InteractableObject interObject;

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    public bool isTyping;

    public Image panel;

    [SerializeField] int index;
    [SerializeField] int indexChecker;

    void Start()
    {
        indexChecker = lines.Length;
        panel.enabled = false;
    }

    void Update()
    {
        if (interObject.isInteracting && Input.GetKeyDown(KeyCode.E) && !isTyping) StartDialogue();
        else if (!interObject.isInteracting)
        {
            ResetDialogue();
        }
        if (indexChecker > index)
        {
            if (textComponent.text == lines[index]) NextLine();
        }
        else
        {
            ResetDialogue();
        }
    }

    void ResetDialogue()
    {
        textComponent.text = string.Empty;
        panel.enabled = false;
        index = 0;
        isTyping = false;
        StopAllCoroutines();
    }

    void StartDialogue()
    {
        index = 0;
        panel.enabled = true;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        if (indexChecker > index)
        {
            isTyping = true;
            foreach (char c in lines[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }
    }

    void NextLine()
    {
        textComponent.text = string.Empty;
        index++;
        StartCoroutine(TypeLine());
    }
}