using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgusPlayerAttack : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] bool isAttacking;
    [SerializeField] KeyCode attackKey;
    [SerializeField] float attackCD;
    [SerializeField] GameObject swordHbox;
    //Scripts a deshabilitar al atacar
    [SerializeField] Animator animator;
    [SerializeField] PlayerMovement playerMovement;

    [SerializeField] float currentCD, cooldown;

    [SerializeField] Slider sliderCD;

    [SerializeField] Transform spawner;

    private Quaternion newRotation;

    private GameObject currentHitbox;

    [SerializeField] AudioManager audioManager;

    private void Awake()
    {
        if (animator == null) animator = GetComponentInChildren<Animator>();
        if (playerMovement == null) playerMovement = GetComponent<PlayerMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
        currentCD = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        currentCD += Time.fixedDeltaTime;
        currentCD = Mathf.Clamp(currentCD, 0, cooldown);

        if (currentCD == cooldown)
        {
            if (Input.GetMouseButtonDown(0) && !isAttacking)
            {
                currentCD = 0;
                animator.SetTrigger("isAttacking");
                audioManager.SeleccionAudio(2, 0.8f);
                audioManager.SeleccionAudio(3, 0.8f);
            }
        }
        //le agrego 90 grados al spawner.rotation que por alguna razon estaba mal puesto
        newRotation = Quaternion.Euler(0, 0, spawner.rotation.eulerAngles.z + 90f);

        //Debug.Log(spawner.rotation);
        //Debug.Log(newRotation);

        if (sliderCD != null ) sliderCD.value = currentCD / cooldown;
    }
    /*
    IEnumerator Ataque()
    {
        isAttacking = true;

        //animator.enabled = false;
        //playerMovement.enabled = false;

        animator.SetTrigger("isAttacking");
        audioManager.SeleccionAudio(2,0.8f);
        yield return new WaitForSeconds(attackCD);

        //animator.enabled = true;
        //playerMovement.enabled = true;

        isAttacking = false;
    }
    */
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
