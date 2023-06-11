using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class personajeSeleccionado : MonoBehaviour
{
    public void getPersonajeSeleccionado(int a)
    {
        if (a.Equals(1))
        {
            PlayerPrefs.SetInt("personajeSeleccionado", a);
        } 
        else if(a.Equals(2)) 
        {
            PlayerPrefs.SetInt("personajeSeleccionado", a);
        }
        else if (a.Equals(3))
        {
            PlayerPrefs.SetInt("personajeSeleccionado", a);
        }
        else if (a.Equals(4))
        {
            PlayerPrefs.SetInt("personajeSeleccionado", a);
        }
    }

}
