using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class listUsersRankingMenu : MonoBehaviour
{
    // Start is called before the first frame update


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDataRow(Ranking ranking, int pos)
    {
        TMP_Text [] row = GetComponentsInChildren<TMP_Text>();

        row[0].SetText(pos.ToString());
        row[1].SetText(ranking.name);
        row[2].SetText(ranking.totalPoints.ToString());

    }
}
