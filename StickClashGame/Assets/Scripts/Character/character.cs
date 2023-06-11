using System.Collections;
using UnityEngine;
public class character : MonoBehaviour
{
    [Header("Movimiento")]

    [SerializeField] float jumpForce = 8;
    [SerializeField] float speed = 8;

    private float horizontal = 0;

    [SerializeField] GameObject feetPlayer;
    private BoxCollider2D feetColl;

    private Rigidbody2D playerRig;

    public static bool activeMov;

    [Header("Invitado")]
    [SerializeField] bool esInvitado;

    private string horizontalInput = "Horizontal";
    private string horizontalJump = "Jump";
    private string horizontalFire1 = "Fire1";

    private string pad = "Gamepad";

    [Header("Animaciones")]

    private Animator animator;
    private bool flipInIdle;

    [Header("Disparo auto = true | semi = false")]

    [SerializeField] bool tipoDisparo;

    // Start is called before the first frame update
    void Start()
    {
        activeMov = false;
        playerRig = this.GetComponent<Rigidbody2D>();
        feetColl = feetPlayer.GetComponent<BoxCollider2D>();

        animator = GetComponent<Animator>();

        if (esInvitado)
        {
            horizontalInput = horizontalInput + pad;
            horizontalJump = horizontalJump + pad;
            horizontalFire1 = horizontalFire1 + pad;

} 
        else
        {
            //Aparezca mirando para la derecha
            flip(true);
        }
    }

    private void FixedUpdate()
    {
        playerRig.velocity = new Vector2(speed * horizontal, playerRig.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw(horizontalInput);

        animator.SetFloat("horizontal", Mathf.Abs(horizontal));

        //Rotación segun direccion de movimiento
        if (horizontal < 0) flip(false);
        else if (horizontal > 0) flip(true);
        else if (horizontal.Equals(0)) flip(flipInIdle);

        float verVel = playerRig.velocity.y;

        //Saltar solo si presionas la tecla y toca el suelo
        if (Input.GetButtonDown(horizontalJump) && feetColl.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            playerRig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        animator.SetFloat("verticalVel", verVel);

        disparo();
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

    private void disparo()
    {
        if (tipoDisparo)
        {
            gameObject.GetComponent<scriptDisparo>().tipoAuto(horizontalFire1);
        }
        else
        {
            gameObject.GetComponent<scriptDisparo>().tipoSemi(horizontalFire1);
        }
    }
    

    public void respawn(GameObject respawnPoint)
    {
        Instantiate(this, respawnPoint.transform, false);
    }
}
