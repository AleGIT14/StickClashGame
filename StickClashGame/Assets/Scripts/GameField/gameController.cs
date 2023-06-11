using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    [Header("Prefabs Personajes")]

    [SerializeField] GameObject prefabSniper;
    [SerializeField] GameObject prefabAuto;
    [SerializeField] GameObject prefabPistol;
    //[SerializeField] GameObject prefabShotgun;
    [SerializeField] GameObject prefabSniperInvitado;
    [SerializeField] GameObject prefabAutoInvitado;
    [SerializeField] GameObject prefabPistolInvitado;
    //[SerializeField] GameObject prefabShotgunInvitado;


    private GameObject player1;
    private GameObject player2;

    private GameObject instanciaP1;
    private GameObject instanciaP2;

    [Header("Respawns")]

    [SerializeField] GameObject respawnL;
    [SerializeField] GameObject respawnR;

    private bool juegoEmpezado;

    [Header("Interfaz")]

    [SerializeField] GameObject puntIzqObj;
    [SerializeField] GameObject puntDerObj;

    private TMP_Text textPuntIzq;
    private TMP_Text textPuntDer;

    private int puntIzq;
    private int puntDer;

    [SerializeField] GameObject p1Win;
    [SerializeField] GameObject p2Win;

    [Header("ScriptBD")]

    [SerializeField] GameObject managerBD;
    void Start()
    {
        //Iniciar componentes
        textPuntIzq = puntIzqObj.GetComponent<TMP_Text>();
        textPuntDer = puntDerObj.GetComponent<TMP_Text>();

        //asignar valores

        textPuntIzq.SetText("0");
        textPuntDer.SetText("0");

        // PlayerSniper - PlayerPistol - PlayerAuto - PlayerShotgun

        player1 = asignarPersonajeAPlayer(PlayerPrefs.GetInt("personajeSeleccionado"));
        player1.gameObject.tag = "player1";

        //Personaje 2 aleatorio
        //Cuando se añada el 4 personaje, cambiar a "Random.Range(1, 5)"
        int personaje2 = Random.Range(1, 4);
        player2 = asignarPersonajeAPlayerInvitado(personaje2);
        player2.gameObject.tag = "player2";


        //Instanciar personajes la primera vez
        instanciarPlayer1();
        instanciarPlayer2();

        juegoEmpezado = true;

        habilitarMovimiento(instanciaP1);
        habilitarMovimiento(instanciaP2);

    }

    // Update is called once per frame
    void Update()
    {
        //Si el juego ha empezado, comprueba si alguno muere, cuando alguno muera, se reinicia la ronda.

        if (!juegoEmpezado)
        {
            ronda();
        }
        else
        {
            comprobarMuerto();
        }
    }

    private void ronda()
    {
        
        //Al comeinzo de ronda crea los personajes
        instanciarPlayer1();
        instanciarPlayer2();

        //les habilita el movimiento
        habilitarMovimiento(instanciaP1);
        habilitarMovimiento(instanciaP2);

        juegoEmpezado = true;

    }


    private void instanciarPlayer1()
    {
        if(instanciaP1 == null) 
        {
            instanciaP1 = Instantiate(player1, respawnL.transform, false);
        }
        
    }

    private void instanciarPlayer2()
    {
        if (instanciaP2 == null)
        {
            instanciaP2 = Instantiate(player2, respawnR.transform, false);
        }
    }

    private void aumentarPuntuacionIzq()
    {
        if (puntIzq < 10)
        {
            puntIzq++;
            textPuntIzq.text = puntIzq.ToString();
        }
    }

    private void aumentarPuntuacionDer()
    {
        if (puntDer < 10)
        {
            puntDer++;
            textPuntDer.text = puntDer.ToString();
        }
    }

    private void finPartida()
    {
        if (puntIzq.Equals(10))
        {
            p1Win.SetActive(true);
            //deshabilitarMovimiento(instanciaP1);
            deshabilitarMovimiento(instanciaP2);

            StartCoroutine(cargarEscenaMenuPlayer());
        }
        else if (puntDer.Equals(10))
        {
            p2Win.SetActive(true);
            deshabilitarMovimiento(instanciaP1);
            //deshabilitarMovimiento(instanciaP2);

            StartCoroutine(cargarEscenaMenuPlayer());
        }
    }

    private void habilitarMovimiento(GameObject player)
    {
        if (player != null)
            player.GetComponent<character>().enabled = true;
    }

    private void deshabilitarMovimiento(GameObject player)
    {
        if (player != null)
            player.GetComponent<character>().enabled = false;
    }


    private void comprobarMuerto()
    {
        if (instanciaP1 == null || instanciaP2 == null)
        {
            if (puntIzq < 10 && puntDer < 10)
            {
                if (instanciaP1 == null)
                {
                    aumentarPuntuacionDer();
                    deshabilitarMovimiento(instanciaP2);
                    Destroy(instanciaP2);
                }
                else if (instanciaP2 == null)
                {
                    aumentarPuntuacionIzq();
                    deshabilitarMovimiento(instanciaP1);
                    Destroy(instanciaP1);
                }

                juegoEmpezado = false;
            }

            if (puntIzq.Equals(10) || puntDer.Equals(10))
            {
                finPartida();
            }
        }
    }

    //TODO
    private GameObject asignarPersonajeAPlayer(int numPersonaje)
    {
        if (numPersonaje.Equals(1))
        {
            return prefabSniper;
        }
        else if (numPersonaje.Equals(2))
        {
            return prefabAuto;
        }
        else if (numPersonaje.Equals(3))
        {
            return prefabPistol;
        }
        else if (numPersonaje.Equals(4))
        {
            //Cambiar cuando se añada personaje 4 
            return prefabSniper;
        }

        return prefabSniper;
    }

    private GameObject asignarPersonajeAPlayerInvitado(int numPersonaje)
    {
        if (numPersonaje.Equals(1))
        {
            return prefabSniperInvitado;
        }
        else if (numPersonaje.Equals(2))
        {
            return prefabAutoInvitado;
        }
        else if (numPersonaje.Equals(3))
        {
            return prefabPistolInvitado;
        }
        else if (numPersonaje.Equals(4))
        {
            //Cambiar cuando se añada personaje 4 
            return prefabSniperInvitado;
        }

        return prefabSniperInvitado;
    }



    IEnumerator cargarEscenaMenuPlayer()
    {
        yield return new WaitForSeconds(4);

        Debug.Log("El usuario " + sesion.getPlayerName() + " ha ganado: " + puntIzq + "puntos");

        gameObject.GetComponent<bdMananger>().actualizarPuntos(sesion.getPlayerName(), puntIzq);

        PlayerPrefs.DeleteKey("personajeSeleccionado");
        Debug.Log("carga escena");
        SceneManager.LoadScene("PlayerMenu");
    }

}
