using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    
    private int characterSelec;

    [Header("Prefabs Personajes")]

    [SerializeField] GameObject prefabSniper;
    //[SerializeField] GameObject prefabAuto;
    //[SerializeField] GameObject prefabPistol;
    //[SerializeField] GameObject prefabShotgun;

    private GameObject prefabSelected;

    [Header("Respawns")]

    [SerializeField] GameObject respawnL;
    [SerializeField] GameObject respawnR;

    [Header("Interfaz")]

    [SerializeField] GameObject cuadroRes;

    void Start()
    {
        characterSelec = PlayerPrefs.GetInt("personajeSeleccionado");

        // PlayerSniper - PlayerPistol - PlayerAuto - PlayerShotgun

        if (characterSelec.Equals(1))
        {
            prefabSelected = prefabSniper;
        }
        else if (characterSelec.Equals(2))
        {
            //Instantiate(prefabPersonajeAuto, respawnL.transform, false);
        }
        else if (characterSelec.Equals(3))
        {
            //Instantiate(prefabPersonajePistol, respawnL.transform, false);
        }
        else if (characterSelec.Equals(4))
        {
            //Instantiate(prefabPersonajeShotgun, respawnL.transform, false);
        }

        prefabSelected.gameObject.tag = "player1";
        

        instanciarPersonaje(prefabSelected);

        //prefabSelected.GetComponent<character>(). = true;

        //cuadroRes.GetComponent<puntuacion>().aumentarPuntuacionIzq();
        //cuadroRes.GetComponent<puntuacion>().aumentarPuntuacionDer();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void instanciarPersonaje(GameObject personaje)
    {
        Instantiate(personaje, respawnL.transform, false);
    }


}
