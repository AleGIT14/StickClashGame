using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class puntuacion : MonoBehaviour
{

    [SerializeField] GameObject puntIzq;
    [SerializeField] GameObject puntDer;

    private string textPuntIzq;
    private string textPuntDer;

    // Start is called before the first frame update
    void Start()
    {
        puntIzq.GetComponent<TMP_Text>().SetText("0");
        puntDer.GetComponent<TMP_Text>().SetText("0");

        textPuntIzq = "0";
        textPuntDer = "0";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void aumentarPuntuacionIzq()
    {
        if (int.Parse(textPuntIzq) < 10)
        {
            textPuntIzq += 1;
            puntIzq.GetComponent<TMP_Text>().SetText(textPuntIzq);
        }
            

    }

    public void aumentarPuntuacionDer()
    {
        if (int.Parse(textPuntDer) < 10)
        {
            textPuntDer += 1;
            puntDer.GetComponent<TMP_Text>().SetText(textPuntIzq);
        }
    }

}
