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
    public GameObject button;

    [SerializeField] int index;
    [SerializeField] int indexChecker;

    [Header("Movimiento y Animacion")]
    public PlayerMovement playerMovement;
    public AnimationController animationController;

    void Start()
    {
        indexChecker = lines.Length;
        panel.enabled = false;
        button.SetActive (false);
        //isTyping = true;
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
            return;//if (textComponent.text == lines[index] && isReadyForChange) NextLine();
        }
        else
        {
            ResetDialogue();
        }
        //Apreto R para que el texto se escriba de una
        if (textComponent.text != lines[index] && isTyping && Input.GetKeyDown(KeyCode.E))
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
            isTyping = false;
        }
    }
    void ResetDialogue()
    {
        textComponent.text = string.Empty;
        panel.enabled = false;
        button.SetActive(false);

        index = 0;
        isTyping = false;
        StopAllCoroutines();
    }

    void StartDialogue()
    {
        index = 0;
        panel.enabled = true;
        button.SetActive(true);
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        if (indexChecker > index)
        {
            isTyping = true;
            //Desactivo los scripts de movimiento y animacion
            animationController.enabled = false;
            playerMovement.enabled = false;

            foreach (char c in lines[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }
        else
        {
            animationController.enabled = true;
            playerMovement.enabled = true;
        }
    }

    public void NextLine()
    {
        textComponent.text = string.Empty;
        index++;
        StartCoroutine(TypeLine());
    }
}