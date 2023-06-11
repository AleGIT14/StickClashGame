using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class muerte : MonoBehaviour
{
    [SerializeField] Sprite spriteMuerto;
    [SerializeField] GameObject personaje;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("deadZone") || collision.gameObject.CompareTag("playerBullet"))
        {
            dead();
        }
    }

    //Cambia el sprite al muerto y lo combierte en muñeca de trapo
    public void dead()
    {
        personaje.GetComponent<Animator>().enabled = false;
        personaje.GetComponent<SpriteRenderer>().sprite = spriteMuerto;
        personaje.GetComponent<Rigidbody2D>().freezeRotation = false;
        personaje.GetComponent<character>().enabled = false;

        StartCoroutine(destroyP());

    }

    IEnumerator destroyP()
    {
        Debug.Log("espera 2 segundos");
        yield return new WaitForSeconds(2);
        Destroy(personaje);
        Debug.Log("personaje destruido");
    }



}
