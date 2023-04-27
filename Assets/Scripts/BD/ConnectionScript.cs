using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MySql.Data.MySqlClient;

public class ConnectionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
    {
        Server = "sql8.freemysqlhosting.net",
        UserID = "sql8614216",
        Password = "6q27zNzm2x",
        Database = "sql8614216"
    };

    public string getConexion()
    {
        string stringCon = builder.ToString();
        return stringCon;
    }

}
