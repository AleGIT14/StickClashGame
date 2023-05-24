using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class deleteUserRow : MonoBehaviour
{
    [SerializeField] GameObject idField;
    [SerializeField] GameObject row;

    private int id;

    // Start is called before the first frame update
    void Start()
    {
        id = Int32.Parse(idField.GetComponent<TMP_Text>().text);
        Debug.Log(id);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Elimina el usuario de la bd y destruye el contenedor en el listado
    public void buttonClicked()
    {
        this.GetComponent<bdMananger>().deleteUser(id);
        Destroy(row);
    }

}
