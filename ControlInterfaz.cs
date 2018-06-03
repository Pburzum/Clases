using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlInterfaz : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void abrirInventario()
    {
        GameManager1.instancia.GetComponent<GameManager1>().toogleInventario();
    }

    public void abrirPersonaje()
    {
        GameManager1.instancia.GetComponent<GameManager1>().tooglePersonaje();
    }

    public void abrirMenu()
    {
        GameManager1.instancia.GetComponent<GameManager1>().toogleMenu();
    }

    public void usarHabilidad()
    {
        personaje.pj.GetComponent<Heroe>().primeraHabilidad();
    }
}
