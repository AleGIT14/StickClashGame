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

    private string user;
    private string pass;

    private bdMananger objBd;

    void Start()
    {

        //Debug.Log(a.GetType());
        btn.onClick.AddListener(checkUser);
        
    }

    void Update()
    {
       
    }

    void checkUser()
    {

        //Asignar en
        user = userObj.GetComponent<TMP_Text>().text;
        pass = passObj.GetComponent<TMP_Text>().text;

        Debug.Log("hola");
        Debug.Log(user);
        Debug.Log(pass);
        if(scriptsObj.GetComponent<bdMananger>().ComprobarUsuario(user, pass))
        {
            Debug.Log("Login Correcto");
        } else
        {
            Debug.Log("caca db");
        }
    }

    
}
