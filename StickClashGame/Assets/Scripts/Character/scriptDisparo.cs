using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptDisparo : MonoBehaviour
{
    [SerializeField] float cadencia;
    [SerializeField] GameObject salidaArma;
    [SerializeField] GameObject bala;
    private bool fireAux;


    // Start is called before the first frame update
    void Start()
    {
        fireAux = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void tipoSemi(string horizontalFire1)
    {
        if (Input.GetButtonDown(horizontalFire1) && fireAux)
        {
            StartCoroutine(fire());
        }
    }

    public void tipoAuto(string horizontalFire1)
    {
        if (Input.GetButton(horizontalFire1) && fireAux)
        {
            StartCoroutine(fire());
        }
    }


    IEnumerator fire()
    {
        fireAux = false;
        Instantiate(bala, salidaArma.GetComponent<Transform>().position, this.gameObject.GetComponent<Transform>().rotation);
        yield return new WaitForSeconds(cadencia);
        fireAux = true;
    }
}
