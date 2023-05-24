using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generaRows : MonoBehaviour
{
    List<Usuario> lstUsers;
    [SerializeField] GameObject prefabRow;

    // Start is called before the first frame update
    void Start()
    {
        lstUsers = this.GetComponent<bdMananger>().listPlayers();

        foreach(Usuario player in lstUsers)
        {
            player.ToString();

            //Se inicializa el método que da los valores para que complete los datos
            prefabRow.GetComponent<listUsersAdminMenu>().setDataRow(player);

            //Se genera una prefab por cada objeto player
            //y se indica que se instancie dentro del gameobject padre (con nombre 'Content' en unity)
            Instantiate(prefabRow, this.transform, false);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
