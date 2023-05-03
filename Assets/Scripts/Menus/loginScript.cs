using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class loginScript : MonoBehaviour
{

    //asignar el componente text del componente para escribir
    [SerializeField] GameObject userObj;
    [SerializeField] GameObject passObj;

    [SerializeField] GameObject scriptsObj;

    public Button btn;
    private GameObject errorTextObj;
    private string errorText;

    private string user;
    private string pass;

    private bdMananger objBd;


    void Start()
    {
        btn.onClick.AddListener(checkUser);
        errorTextObj = GameObject.FindWithTag("errortext");
    }

    void Update()
    {
    }

    private void checkUser()
    {

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
            if (scriptsObj.GetComponent<bdMananger>().ComprobarUsuario(user, pass))
            {
                Debug.Log("Login Correcto");
                string msg = "Login correcto";
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
        go.GetComponent<TMP_Text>().text = msg;
    }
}
