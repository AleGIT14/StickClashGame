using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sniperBullet : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField] float velocidadProyectil;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.right * velocidadProyectil * Time.deltaTime);
        //rb.velocity = new Vector2(velocidadProyectil, 0);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * velocidadProyectil * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.CompareTag("ground"))
        {
            Destroy(gameObject);
        }
    }
}
