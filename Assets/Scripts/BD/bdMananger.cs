using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System;

public class bdMananger : MonoBehaviour
{
    private MySqlConnection conn;

    //Puede cambiarse por un findbyTag?
    [SerializeField] GameObject connectionScript;

    // Start is called before the first frame update

    public bool checkInsertUsuario(string user, string pass)
    {
        int a = comprobarUsuario(user, pass);
        if (a == 1 || a == 2)
        {
            if (insertarUsuario(user, pass))
            {
                return true;
            }
            return false;
        }
        return false;


    }

    //terminar ?
    public bool insertarUsuario(string user, string pass)
    {
        string Query = String.Format("INSERT INTO `users` (`user_id`, `role`, `status`, `username`, `password`, `create_time`) VALUES (NULL, DEFAULT, DEFAULT, @user, @pass, DEFAULT);");

        try
        {
            string connString = connectionScript.GetComponent<ConnectionScript>().getConexion();
            conn = new MySqlConnection(connString);

            conn.Open();

            using (MySqlCommand cmd = new MySqlCommand(Query, conn))
            {
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pass", pass);

                cmd.ExecuteNonQuery();

            }


            conn.Close();

            Debug.Log("Inserción correcta");

            return true;

        }
        catch (MySqlException e)
        {
            Debug.Log("Error de inserción");
            Debug.Log(e);
            return false;
        }
    }

    //DONE
    public int comprobarUsuario(string user, string pass)
    {
        List<Usuario> lst = listAllUsers();

        int aux = 0;

        foreach (Usuario usr in lst)
        {
            if (String.Equals(user, usr.name) && String.Equals(pass, usr.pass))
            {
                if (usr.role == "player")
                {
                    aux = 1;
                    Debug.Log("Si coincide, admin");
                    break;
                }
                else if (usr.role == "admin")
                {
                    aux = 2;
                    Debug.Log("Si coincide, player");
                    break;
                }
            }
            else
            {
                Debug.Log("No coincide");
                aux = 0;
            }
        }
        return aux;
    }

    public bool userExist(string user)
    {
        List<Usuario> lst = listAllUsers();

        bool aux = false;

        foreach (Usuario usr in lst)
        {
            if (String.Equals(user, usr.name))
            {
                aux = true;
                Debug.Log("user existe");
                break;
            }
            else
            {
                aux = false;
                Debug.Log("user no existe");
            }
        }
        return aux;
    }


    //DONE
    public List<Usuario> listAllUsers()
    {
        string Query = String.Format("SELECT * FROM users");
        List<Usuario> listUsers = new List<Usuario>();

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
                    Usuario a = new Usuario((int)res["user_id"], res["role"].ToString(), res["username"].ToString(), res["password"].ToString());
                    listUsers.Add(a);
                }
            }
            conn.Close();

            return listUsers;

        }
        catch (MySqlException e)
        {
            Debug.Log(e);
            return null;
        }
    }


    //DONE
    public List<Usuario> listPlayers()
    {

        string Query = String.Format("SELECT * FROM users WHERE role = 'player'");
        List<Usuario> listUsers = new List<Usuario>();

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

                    Usuario a = new Usuario((int)res["user_id"], res["status"].ToString(), res["username"].ToString());

                    Debug.Log(a.ToString());

                    listUsers.Add(a);

                }
            }

            conn.Close();

            return listUsers;


        }
        catch (MySqlException e)
        {
            Debug.Log(e);
            return null;
        }
    }


    //DONE
    public bool deleteUser(int id)
    {

        string Query = String.Format("DELETE FROM users where user_id=@id");

        try
        {
            string connString = connectionScript.GetComponent<ConnectionScript>().getConexion();
            conn = new MySqlConnection(connString);

            conn.Open();

            using (MySqlCommand cmd = new MySqlCommand(Query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

            }

            conn.Close();

            Debug.Log("Borrado Correcto");

            return true;


        }
        catch (MySqlException e)
        {
            Debug.Log(e);
            return false;
        }
    }

    public bool cambiarEstadoPorId(int id, string estado)
    {
        string Query = String.Format("UPDATE users SET status = @estado WHERE user_id = @id");

        try
        {
            string connString = connectionScript.GetComponent<ConnectionScript>().getConexion();
            conn = new MySqlConnection(connString);

            conn.Open();

            using (MySqlCommand cmd = new MySqlCommand(Query, conn))
            {
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

            }

            conn.Close();

            Debug.Log("Cambio de estado correcto");

            return true;


        }
        catch (MySqlException e)
        {
            Debug.Log(e);
            return false;
        }
    }
}
