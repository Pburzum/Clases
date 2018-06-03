using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenas : MonoBehaviour {


    public void cambioMainStart()
    {
        SceneManager.LoadScene("Eleccion Personaje");
    }
    public void cambioMainLoad()
    {
        SceneManager.LoadScene("CargaPartidas");
    }

    public void salir()
    {
        Application.Quit();
    }
}
