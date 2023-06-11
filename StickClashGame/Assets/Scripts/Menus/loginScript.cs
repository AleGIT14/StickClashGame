using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class loginScript : MonoBehaviour
{

    //asignar el componente text del componente para escribir
    [SerializeField] GameObject userObj;
    [SerializeField] GameObject passObj;

    [SerializeField] GameObject scriptsObj;

    private Button btnLogin;
    [SerializeField] Button btnRegister;

    private GameObject errorTextObj;

    private string user;
    private string pass;


    void Start()
    {

        btnLogin = this.GetComponent<Button>();
        btnLogin.onClick.AddListener(checkUser);

        errorTextObj = GameObject.FindWithTag("errortext");
    }

    void Update()
    {
    }

    private void checkUser()
    {

        cambiarTexto(errorTextObj, "");

        //Asignar en
        user = userObj.GetComponent<TMP_InputField>().text;
        pass = passObj.GetComponent<TMP_InputField>().text;

        if (user == "" || pass == "")
        {
            string msg = "Debe rellenar todos los campos";
            cambiarTexto(errorTextObj, msg);
        }
        else
        {
            int consultaRes = scriptsObj.GetComponent<bdMananger>().comprobarUsuario(user, pass);

            if (consultaRes == 1)
            {
                Debug.Log("Login Correcto");
                string msg = "Login correcto, bienvenido " + user;
                cambiarTexto(errorTextObj, msg);

                sesion.setPlayername(user);

                Debug.Log(sesion.getPlayerName());

                StartCoroutine(cargarEscena("PlayerMenu"));
            } 
            else if (consultaRes == 2)
            {
                Debug.Log("Login Correcto");
                string msg = "Login correcto, bienvenido admin";
                cambiarTexto(errorTextObj, msg);

                StartCoroutine(cargarEscena("AdminMenu"));
            }
            else if ( consultaRes == 3)
            {
                Debug.Log("usuario suspendido");
                string msg = "Error - El usuario se encuentra en estado suspendido";

                cambiarTexto(errorTextObj, msg);
            }
            else
            {
                Debug.Log("error de acceso");
                string msg = "Error de acceso, debe indicar un usuario válido";

                cambiarTexto(errorTextObj, msg);

            }
        }

        
    }

    private void cambiarTexto(GameObject go, string msg)
    {
        go.GetComponent<TMP_Text>().SetText(msg);
    }

    IEnumerator cargarEscena(string scene)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(scene);
    }

}
