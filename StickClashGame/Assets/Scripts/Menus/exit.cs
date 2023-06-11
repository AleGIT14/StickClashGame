using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(cerrarJuego);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void cerrarJuego()
    {
        Application.Quit();
    }

}
