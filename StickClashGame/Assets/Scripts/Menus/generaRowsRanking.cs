using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generaRowsRanking : MonoBehaviour
{
    private List<Ranking> lstRanking;
    [SerializeField] GameObject prefabRow;

    // Start is called before the first frame update
    void Start()
    {
        lstRanking = this.GetComponent<bdMananger>().listRanking();

        int pos = 0;

        foreach (Ranking player in lstRanking)
        {
            player.ToString();
            pos++;
            //Se inicializa el método que da los valores para que complete los datos
            prefabRow.GetComponent<listUsersRankingMenu>().setDataRow(player, pos);

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
