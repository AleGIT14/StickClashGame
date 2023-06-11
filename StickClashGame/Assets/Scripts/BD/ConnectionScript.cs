using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MySql.Data.MySqlClient;

public class ConnectionScript : MonoBehaviour
{
    // Start is called before the first frame update

    private MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
    {
        /*
        Server = "localhost",
        UserID = "root",
        Database = "stick_clash"
        */

        Server = "home.netindio.synology.me",
        Port = 3306,
        UserID = "root",
        Password = "examplepassword",
        Database = "stick_clash"

    };

    public string getConexion()
    {
        string stringCon = builder.ToString();
        return stringCon;
    }

}
