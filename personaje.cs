using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class personaje : MonoBehaviour
{

    public static personaje pj = null;
    public string nombre = "Prueba";
    public int antItem;

    private void Awake()
    {
        cargarPartida(this.nombre);
        if (pj == null)
        {
            pj = this;
        }
        else if (pj != this)
        {
            Destroy(gameObject);
        }
        cargarPartida(this.nombre);
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void equipaObjeto(int id)
    {
        antItem = gameObject.GetComponent<Heroe>().equiparHijo(id);
    }

    private void OnDestroy()
    {
        guardarPartida(this.nombre);
    }

    public void guardarPartida(string nombre)
    {
        gameObject.GetComponent<Heroe>().guardarPartida(nombre);
    }

    public void cargarPartida(string nombre)
    {
        string nombreFichero = "/Resources/clase" + nombre + ".json";
        if (File.Exists(Application.dataPath + nombreFichero))
        {
            gameObject.GetComponent<Heroe>().cargarPartida(nombre);
        }
        else
        {
            gameObject.GetComponent<Heroe>().crearNuevoPersonaje();
        }
    }
}
