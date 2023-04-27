using UnityEngine;
using UnityEngine.Tilemaps;

public class movement : MonoBehaviour
{
    [SerializeField] float jumpForce = 8;
    [SerializeField] float speed = 8;

    private float horizontal;

    private Rigidbody2D rb;
    private GameObject feetObj;

    private BoxCollider2D feetColl;
    [SerializeField] TilemapCollider2D ground;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        feetObj = GameObject.Find("feet");
        feetColl = feetObj.GetComponent<BoxCollider2D>();

    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(speed * horizontal, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Z) && feetColl.IsTouching(ground))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }


    }
}
