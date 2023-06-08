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

    //DONE
    public bool insertarUsuario(string user, string pass)
    {
        string query1 = String.Format("INSERT INTO `users` (`user_id`, `role`, `status`, `username`, `password`, `create_time`) VALUES (NULL, DEFAULT, DEFAULT, @user, @pass, DEFAULT);");
        string query2 = String.Format("INSERT INTO `player_data` (`user_id`, `actualPoints`, `unlocks`) VALUES (@id_data, DEFAULT, DEFAULT);");
        string query3 = String.Format("INSERT INTO `ranking` (`user_id`, `totalPoints`) VALUES (@id_rank, DEFAULT);");


        string connString = connectionScript.GetComponent<ConnectionScript>().getConexion();


        using (conn = new MySqlConnection(connString))
        {
            conn.Open();

            MySqlTransaction transaction = conn.BeginTransaction();

            try
            {
                //insert primera tabla
                MySqlCommand cmd1 = new MySqlCommand(query1, conn);

                cmd1.Parameters.AddWithValue("@user", user);
                cmd1.Parameters.AddWithValue("@pass", pass);

                cmd1.ExecuteNonQuery();

                //obtenemos el id generado

                long last_id = cmd1.LastInsertedId;


                //insert segunda tabla
                MySqlCommand cmd2 = new MySqlCommand(query2, conn);

                cmd2.Parameters.AddWithValue("@id_data", last_id);

                cmd2.ExecuteNonQuery();

                //insert tercera tabla
                MySqlCommand cmd3 = new MySqlCommand(query3, conn);

                cmd3.Parameters.AddWithValue("@id_rank", last_id);

                cmd3.ExecuteNonQuery();


                transaction.Commit();

            }
            catch (MySqlException e)
            {
                transaction.Rollback();

                Debug.Log("Error de inserción");
                Debug.Log(e);

                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        Debug.Log("Inserción correcta");

        return true;
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
        conn.Close();

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
    //Lista los usuarios con sus puntos totales de forma descendente.
    public List<Ranking> listRanking()
    {

        string Query = String.Format("SELECT users.username, ranking.totalPoints FROM users INNER JOIN ranking ON users.user_id = ranking.user_id ORDER BY ranking.totalPoints DESC;");

        List<Ranking> listRanking = new List<Ranking>();

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

                    Ranking a = new Ranking(res["username"].ToString(), (int)res["totalPoints"]);

                    Debug.Log(a.ToString());

                    listRanking.Add(a);

                }
            }

            conn.Close();

            return listRanking;


        }
        catch (MySqlException e)
        {
            Debug.Log(e);
            return null;
        }
    }


    //DONE
    //Delete en Cascade configurado en la base de datos para todas las tablas
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


    public int obtenerPuntosActuales(string user)
    {
        int res;

        Debug.Log("debug: + " + user);


        string query1 = String.Format("SELECT actualPoints FROM player_data WHERE user_id IN (SELECT user_id FROM users WHERE username = @user);");

        string connString = connectionScript.GetComponent<ConnectionScript>().getConexion();


        using (conn = new MySqlConnection(connString))
        {

            conn.Open();

            MySqlTransaction transaction = conn.BeginTransaction();

            try
            {

                MySqlCommand cmd1 = new MySqlCommand(query1, conn);

                cmd1.Parameters.AddWithValue("@user", user);

                using (MySqlDataReader resCons = cmd1.ExecuteReader())
                {

                    if (resCons.Read())
                    {
                        res = (int)resCons["actualPoints"];
                        Debug.Log(res);
                    }
                    else
                    {
                        res = -1;
                    }
                }

                transaction.Commit();

            }
            catch (MySqlException e)
            {
                transaction.Rollback();

                Debug.Log(e);

                res = -1;
            }
            finally
            {
                conn.Close();
            }
        }



        return res;
    }

}