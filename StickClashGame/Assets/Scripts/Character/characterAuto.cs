using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class characterAuto : MonoBehaviour
{
    [Header("Movimiento")]

    [SerializeField] float jumpForce = 8;
    [SerializeField] float speed = 8;

    private float horizontal = 0;

    [SerializeField] GameObject feetPlayer;
    private BoxCollider2D feetColl;

    private Rigidbody2D playerRig;

    public static bool activeMov;

    [Header("Animaciones")]

    private Animator animator;
    private bool flipInIdle;

    [Header("Disparo 1/2/3/4 sniper/auto/pistol/shotgun")]
    
    [SerializeField] int tipoArma;
    private bool fireAux;
    [SerializeField] float cadencia;
    [SerializeField] GameObject salidaArma;
    [SerializeField] GameObject bala;

    // Start is called before the first frame update
    void Start()
    {
        activeMov = false;
        fireAux = true;
        playerRig = this.GetComponent<Rigidbody2D>();
        feetColl = feetPlayer.GetComponent<BoxCollider2D>();

        animator = GetComponent<Animator>();

        //Aparezca mirando para la derecha
        flip(true);

    }

    private void FixedUpdate()
    {
        playerRig.velocity = new Vector2(speed * horizontal, playerRig.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("horizontal", Mathf.Abs(horizontal));

        //Rotación segun direccion de movimiento
        if (horizontal < 0) flip(false);
        else if (horizontal > 0) flip(true);
        else if (horizontal.Equals(0)) flip(flipInIdle);

        float verVel = playerRig.velocity.y;

        //Saltar solo si presionas la tecla y toca el suelo
        if (Input.GetButtonDown("Jump") && feetColl.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            playerRig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        animator.SetFloat("verticalVel", verVel);


        

        //este dispara auto
        if (Input.GetButton("Fire1") && fireAux)
        {
            StartCoroutine(fire());
        }

    }

    private void flip(bool a)
    {

        if (a)
        {
            this.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
            flipInIdle = true;
        }
        else
        {
            this.GetComponent<Transform>().rotation = Quaternion.Euler(0, -180f, 0);
            flipInIdle = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("isJumping", false);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("isJumping", true);
    }

    IEnumerator fire()
    {
        fireAux = false;
        Instantiate(bala, salidaArma.GetComponent<Transform>().position, this.gameObject.GetComponent<Transform>().rotation);
        yield return new WaitForSeconds(cadencia);
        fireAux = true;
    }

    public void respawn(GameObject respawnPoint)
    {
        Instantiate(this, respawnPoint.transform, false);
    }
}
