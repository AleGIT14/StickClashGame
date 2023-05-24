using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class registerScript : MonoBehaviour
{

    //asignar el componente text del componente para escribir
    [SerializeField] GameObject userObj;
    [SerializeField] GameObject passObj;
    [SerializeField] GameObject repeatPassObj;

    [SerializeField] GameObject scriptsObj;

    private GameObject errorTextObj;

    private string user;
    private string pass;
    private string repeatPass;


    void Start()
    {
        errorTextObj = GameObject.FindWithTag("errortext");
    }

    void Update()
    {

    }


    public void insertarUser()
    {
        user = userObj.GetComponent<TMP_InputField>().text;
        pass = passObj.GetComponent<TMP_InputField>().text;
        repeatPass = repeatPassObj.GetComponent<TMP_InputField>().text;

        if (checkUser())
        {
            if (scriptsObj.GetComponent<bdMananger>().insertarUsuario(user, pass))
            {
                Debug.Log("Registro Correcto");
                string msg = "Registro correcto, bienvenido " + user + " iniciando sesión";
                cambiarTexto(msg);

                StartCoroutine(cargarEscena("PlayerMenu"));
            }
        }
    }



    private bool checkUser()
    {
        if (user.Equals("") || pass.Equals("") || repeatPass.Equals(""))
        {
            string msg = "Debe rellenar todos los campos";
            cambiarTexto(msg);
            return false;
        }
        else if (!pass.Equals(repeatPass))
        {
            string msg = "Las contraseñas no coinciden";
            cambiarTexto(msg);
            return false;
        }
        else
        {

            if (!scriptsObj.GetComponent<bdMananger>().userExist(user))
            {
                return true;
            }
            else
            {
                string msg = "El usuario ya está registrado";
                cambiarTexto(msg);
                return false;
            }

        }
    }

    private void cambiarTexto(string msg)
    {
        errorTextObj.GetComponent<TMP_Text>().SetText(msg);
    }


    IEnumerator cargarEscena(string scene)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(scene);
    }

}
