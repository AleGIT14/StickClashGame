using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System;

public class bdMananger : MonoBehaviour
{
    private MySqlConnection conn;
    private ConnectionScript bd;

    [SerializeField] GameObject connectionScript;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 


    public bool ComprobarUsuario(string user, string pass)
    {

        string Query = String.Format("SELECT * FROM users");
        bool flag = false;

        try
        {
            string connString = connectionScript.GetComponent<ConnectionScript>().getConexion();
            conn = new MySqlConnection(connString);

            conn.Open();

            using (MySqlCommand cmd = new MySqlCommand(Query, conn))
            {
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    if (String.Equals(user, res["username"]) && String.Equals(pass, res["password"]))
                    {
                        flag = true;
                        Debug.Log("Si coincide");
                        break;
                    }
                    else
                    {
                        Debug.Log("No coincide");
                        flag = false;
                    }
                }
            }

            conn.Close();

            if (flag) { return true; }
            else { return false; }


        }
        catch (MySqlException e)
        {
            Debug.Log(e);
            return false;
        }
    }

}
