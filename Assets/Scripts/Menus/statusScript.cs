using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class statusScript : MonoBehaviour
{

    [SerializeField] GameObject statusObj;
    [SerializeField] GameObject idObj;

    TMP_Text statusText;

    int id;

    enum statusEnum
    {
        activated,
        suspended
    }

    string acEnum;
    string susEnum;

    // Start is called before the first frame update
    void Start()
    {
        statusText = statusObj.GetComponent<TMP_Text>();
        id = int.Parse(idObj.GetComponent<TMP_Text>().text);

        acEnum = statusEnum.activated.ToString();
        susEnum = statusEnum.suspended.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cambiarEstado()
    {
        if(statusText.text == acEnum)
        {
            if(this.GetComponent<bdMananger>().cambiarEstadoPorId(id, susEnum))
            {
                statusText.text = statusEnum.suspended.ToString();
                statusText.color = Color.red;
            }
        } 
        else if (statusText.text == statusEnum.suspended.ToString())
        {
            if (this.GetComponent<bdMananger>().cambiarEstadoPorId(id, acEnum))
            {
                statusText.text = statusEnum.activated.ToString();
                statusText.color = Color.green;
            }
        }
    }

}
