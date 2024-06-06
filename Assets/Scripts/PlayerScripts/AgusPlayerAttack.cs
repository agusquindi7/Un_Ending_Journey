using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgusPlayerAttack : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] bool isAttacking;
    //[SerializeField] KeyCode attackKey;
    //[SerializeField] float attackCD;
    [SerializeField] GameObject swordHbox;
    [SerializeField] GameObject swordStrongHbox;
    //Scripts a deshabilitar al atacar
    [SerializeField] Animator animator;
    [SerializeField] PlayerMovement playerMovement;

    [SerializeField] float currentCD, cooldown;

    [SerializeField] float currentLightCD, cooldownLight;

    [SerializeField] Slider sliderCD;

    [SerializeField] Transform spawner;

    private Quaternion newRotation;

    private GameObject currentHitbox;

    [SerializeField] AudioManager audioManager;

    private void Awake()
    {
        if (animator == null) animator = GetComponentInChildren<Animator>();
        //if (playerMovement == null) playerMovement = GetComponent<PlayerMovement>();
    }

    void Start()
    {
        isAttacking = false;
        currentCD = cooldown;
        currentLightCD = cooldownLight;
    }

    void Update()
    {
        currentCD += Time.deltaTime;
        currentCD = Mathf.Clamp(currentCD, 0, cooldown);

        currentLightCD += Time.deltaTime;
        currentLightCD = Mathf.Clamp(currentLightCD, 0, cooldownLight);

        if (currentCD == cooldown)
        {
            if (Input.GetMouseButtonDown(1) && !isAttacking)
            {
                isAttacking = true;
                currentCD = 0;
                animator.SetTrigger("isStronging");
                audioManager.SeleccionAudio(5, 1f);
                audioManager.SeleccionAudio(3, 0.8f);
            }
        }
        else isAttacking = false;

        if (currentLightCD == cooldownLight)
        {
            if (Input.GetMouseButtonDown(0) && !isAttacking)
            {
                isAttacking = true;
                currentLightCD = 0;
                animator.SetTrigger("isAttacking");
                audioManager.SeleccionAudio(2, 0.2f);
                //audioManager.SeleccionAudio(3, 0.4f);
            }
        }
        else isAttacking = false;
        //le agrego 90 grados al spawner.rotation que por alguna razon estaba mal puesto
        newRotation = Quaternion.Euler(0, 0, spawner.rotation.eulerAngles.z + 90f);

        if (sliderCD != null ) sliderCD.value = currentCD / cooldown;
    }
    void HBoxStrongSpawner()
    {
        if (swordStrongHbox != null && currentHitbox == null)
        {
            //Le sumo 90 grados a la rotacion del spawner porque no se xd
            //Almaceno mi prefab en una variable para poder destruir
            currentHitbox = Instantiate(swordStrongHbox, spawner.position, newRotation);
            currentHitbox.transform.parent = spawner; // Hacer que la Hitbox sea hija del spawner
            //Deshabilito el movimiento cuando spawneo
            playerMovement.enabled = false;
        }
    }
    void HBoxSpawner()
    {
        if (swordHbox != null && currentHitbox == null)
        {
            //Le sumo 90 grados a la rotacion del spawner porque no se xd
            //Almaceno mi prefab en una variable para poder destruir
            currentHitbox = Instantiate(swordHbox, spawner.position, newRotation);
            currentHitbox.transform.parent = spawner; // Hacer que la Hitbox sea hija del spawner
            //Deshabilito el movimiento cuando spawneo
            playerMovement.enabled = false;
        }
    }
    void HBoxDestroyer()
    {
        if (currentHitbox != null)
        {
            Destroy(currentHitbox);
            currentHitbox = null;
            //Habilito el movimiento de nuevo
            playerMovement.enabled = true;
        }
    }
}
