using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textoUsuarioLogado : MonoBehaviour
{
    [SerializeField] GameObject usernameText;
    [SerializeField] GameObject pointsText;

    [SerializeField] GameObject scriptBD;

    // Start is called before the first frame update
    void Start()
    {
        string username = sesion.getPlayerName();

        usernameText.GetComponent<TMP_Text>().text = username;

        pointsText.GetComponent<TMP_Text>().text = scriptBD.GetComponent<bdMananger>().obtenerPuntosActuales(username).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
