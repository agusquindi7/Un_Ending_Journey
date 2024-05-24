using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] Transform spawner;

    private Quaternion newRotation;

    private GameObject currentHitbox;

    [SerializeField] AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(attackKey) && !isAttacking)
        {
            StartCoroutine(Ataque());
        }
        //le agrego 90 grados al spawner.rotation que por alguna razon estaba mal puesto
        newRotation = Quaternion.Euler(0, 0, spawner.rotation.eulerAngles.z + 90f);

        //Debug.Log(spawner.rotation);
        //Debug.Log(newRotation);
    }

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

    void HBoxSpawner()
    {
        if (swordHbox != null && currentHitbox == null)
        {
            //Le sumo 90 grados a la rotacion del spawner porque no se xd
            //Almaceno mi prefab en una variable para poder destruir
            currentHitbox = Instantiate(swordHbox, spawner.position, newRotation);
            currentHitbox.transform.parent = spawner; // Opcional: hacer que la Hitbox sea hija del spawner
        }
    }

    void HBoxDestroyer()
    {
        if (currentHitbox != null)
        {
            Destroy(currentHitbox);
            currentHitbox = null;
        }
    }
}
