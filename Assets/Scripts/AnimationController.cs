using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public Animator anim;
    public AudioSource audioSource;
    public AudioSource playerAudioSource;
    public AudioManager audioManager;
    public int walkingNumber, dashingNumber, attackingNumber;
    [SerializeField] private float _lastPosition = 1f;

    // Start is called before the first frame update
    void Awake()
    {
        anim.SetBool("isIdle", false);
        audioSource = audioSource.GetComponentInParent<AudioSource>();
        audioManager = audioManager.GetComponentInParent<AudioManager>();
        if (anim == null) anim = GetComponent<Animator>();
        else return;
    }

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            anim.SetFloat("X", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("Y", Input.GetAxisRaw("Vertical"));
            anim.SetBool("isIdle", false);
            playerAudioSource.volume = 1;
            if (Input.GetAxisRaw("Horizontal") < 0) _lastPosition = 3; //Idle Backwards
            else if (Input.GetAxisRaw("Horizontal") > 0) _lastPosition = 4f; //Idle Forward
            else if (Input.GetAxisRaw("Vertical") < 0) _lastPosition = 2f; //Idle Back
            else _lastPosition = 1f; //Idle Front
        }
        else if (Input.GetAxisRaw("Horizontal") == 0 || Input.GetAxisRaw("Vertical") == 0)
        {
            anim.SetBool("isIdle", true);
            playerAudioSource.volume = 0;
        }
        anim.SetFloat("Idle",_lastPosition);

        anim.SetFloat("XAttack", Input.GetAxis("Horizontal"));
        anim.SetFloat("YAttack", Input.GetAxis("Vertical"));

        /*
        if (Input.GetKeyDown(KeyCode.P))
        {
            audioManager.SeleccionAudio(attackingNumber, 1f);
            anim.SetTrigger("isAttacking");
        }
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("isDashing");
            audioManager.SeleccionAudio(dashingNumber,1f);
        }
        */
    }
}

        
        
