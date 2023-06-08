using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class sesion : MonoBehaviour
{
    // Start is called before the first frame update
    private static string username;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static string getPlayerName()
    {
        return username;
    }

    public static void setPlayername(string user)
    {
        username = user;
    }

    public static void setNull()
    {
        username = null;
    }

}
