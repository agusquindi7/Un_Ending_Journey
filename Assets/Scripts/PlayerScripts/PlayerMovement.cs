using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Ataque melee y a distancia?
    //Salto/Esquive?

    [Header("Referencias")]

    public AudioManager audioManager;
    public Animator anim;
    public Transform character;
    public Rigidbody2D myRB2D;
    public Transform spawner;

    [Header("Valores")]

    public float normalSpeed, constantSpeed, dashSpeed;
    public float dashTime;
    Vector2 lastImput;
    public KeyCode myKeyDash;
    public float dashCooldown, initialDashCooldown;


    public bool isDashing = false;

    //[SerializeField] TrailRenderer trail;


        //CANVAS DE DASH
    //public CanvasManager myCanvas;

    //private bool playingSound = false;

    private void Awake()
    {
        //busco el gameobjecto por tag
        if (character == null) character = GameObject.FindGameObjectWithTag("Player").transform;
       

        //la velocidad normal es la constante
        normalSpeed = constantSpeed;

        //trail.emitting = false;

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Obtengo inputs en los ejes horizontal y vertical
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        //Cambio las variables X e Y del Blend Tree
        
        //anim.SetFloat("X", Input.GetAxisRaw("Horizontal"));
        //anim.SetFloat("Y", Input.GetAxisRaw("Vertical"));

        //Normalizo ambos inputs en un vector para guardar su direccion
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        //Si el el movimiento es en diagonal lo igualo a 0, para que el pj camine solo en 4 direcciones
        if (Mathf.Abs(moveDirection.x) > Mathf.Abs(moveDirection.y))
        {
            moveDirection.y = 0;
        }
        else
        {
            moveDirection.x = 0;
        }


        lastImput = moveDirection;


        if (isDashing == false)
        {
            //myRB2D.MovePosition(myRB2D.position + moveDirection * speed * Time.fixedDeltaTime);

            myRB2D.velocity = moveDirection * normalSpeed;
            //Llamo al metodo de seleccion de audios
            

            //si la direccion del vector2 es distinta de 0 hago un calculo de angulo para que la rotacion del spawner respete a donde mire el personaje
            if (moveDirection != Vector2.zero)
            {
                //calculo de radianes
                //float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;

                //este calculo de angulo es mas facil de entender, dependiendo de a donde este mirando el jugador al empezar pongo right, up, etc. y el agrego el vector de movimiento. signed da el angulo desde donde esta mirando hasta donde mira
                float angle = Vector2.SignedAngle(Vector2.right, moveDirection);

                //El spawner tiene la rotacion del angulo en un Quaternion.Euler, el cual crea una rotacion a partir de X, Y, Z. Me especifica esa rotacion en el spawner
                spawner.rotation = Quaternion.Euler(0f, 0f, angle);
            }
        }

        if (Input.GetKey(myKeyDash) && dashCooldown <= 0)
        {
            //anim.SetTrigger("isDashing");
            Dash();
        }

        //CDDASH
        if (dashCooldown > 0)
        {
            dashCooldown -= Time.fixedDeltaTime;
        }

        //use un matf de aproximacion para aproximar el cd a 0 porque largaba un error que no permitia usara el dash a -0.00001 cd
        if (Mathf.Approximately(dashCooldown, 0f) && isDashing)
        {
            isDashing = false;
            dashCooldown = 0f;
        }

    }

    private void Update()
    {
        //CANVAS DE DASH
        //AdjustCanvas();
    }

    private void Dash()
    {
        if (dashCooldown <= 0)
        {
            //Setteo el trigger para que dashee y ademas reproduzco el sonido del dash
            anim.SetTrigger("isDashing");
            audioManager.SeleccionAudio(1,0.8f);

            //Llamo al sonido del dash
            isDashing = true;
            //agrego una fuerza de impulso a la ultima direccion donde fue el personaje
            myRB2D.AddForce(lastImput * dashSpeed, ForceMode2D.Impulse);
            //anim.SetFloat("XDash", Input.GetAxisRaw("Horizontal"));
            //anim.SetFloat("YDash", Input.GetAxisRaw("Vertical"));
            //trail.emitting = true;
            //CODIGOAGUS anim.SetBool("isDashing",false);
            //co rutina para que lo haga por un tiempo determinado y luego la igualo a 0
            StartCoroutine(EndDash(dashTime));
            dashCooldown = initialDashCooldown;
        }
        //transform.Translate(direction * (Time.deltaTime*(distance/time)));

    }

    // CO RUTINA para la ejecucion normal y ejecuta en el tiempo que pase por paramentro lo que tengo en paralelo
    private IEnumerator EndDash(float dashTime)
    {
        //pausa la accion por una determinada cantidad de tiempo, la que pase con el dashtime, pero se ejecuta el addforce que hace el impulso
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        //trail.emitting = false;
    }

    /*
    private void AdjustCanvas()
    {
        myCanvas.UpdateMyDash(dashCooldown, initialDashCooldown);
    }
    */
}