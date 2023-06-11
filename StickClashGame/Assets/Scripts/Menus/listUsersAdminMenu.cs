using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class listUsersAdminMenu : MonoBehaviour
{
    // Start is called before the first frame update


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDataRow(Usuario usuario)
    {
        TMP_Text [] row = GetComponentsInChildren<TMP_Text>();

        row[0].SetText(usuario.id.ToString());
        row[1].SetText(usuario.name);

        string status = usuario.status;
        row[2].SetText(status);

        if (status == "activated")
        {
            row[2].color = Color.green;
        }
        else
        {
            row[2].color = Color.red;
        }
    }

}
