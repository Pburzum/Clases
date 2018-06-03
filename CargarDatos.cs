using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargarDatos : MonoBehaviour
{

    void Start()
    {
        this.cargarDatos();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void cargarDatos()
    {
        foreach (Transform children in this.transform)
        {
            if (children.name == "Ficha")
            {
                children.GetChild(3).GetComponent<Text>().text = personaje.pj.GetComponent<personaje>().nombre;
                switch (personaje.pj.GetComponent<Heroe>().opcion)
                {
                    case 1:
                        children.GetChild(4).GetComponent<Text>().text = personaje.pj.GetComponent<Guerrero>().nivel.ToString();
                        break;
                    case 2:
                        children.GetChild(4).GetComponent<Text>().text = personaje.pj.GetComponent<Cazador>().nivel.ToString();
                        break;
                    case 3:
                        children.GetChild(4).GetComponent<Text>().text = personaje.pj.GetComponent<Magoku>().nivel.ToString();
                        break;
                }
                children.GetChild(5).GetComponent<Text>().text = personaje.pj.GetComponent<Heroe>().clase;
            }
            else if (children.name == "Stats")
            {
                switch (personaje.pj.GetComponent<Heroe>().opcion)
                {
                    case 1:
                        children.GetChild(7).GetComponent<Text>().text = personaje.pj.GetComponent<Guerrero>().expActual.ToString();
                        children.GetChild(8).GetComponent<Text>().text = personaje.pj.GetComponent<Guerrero>().expNivel.ToString();
                        children.GetChild(9).GetComponent<Text>().text = personaje.pj.GetComponent<Guerrero>().fuerza.ToString();
                        children.GetChild(10).GetComponent<Text>().text = personaje.pj.GetComponent<Guerrero>().agilidad.ToString();
                        children.GetChild(11).GetComponent<Text>().text = personaje.pj.GetComponent<Guerrero>().inteligencia.ToString();
                        children.GetChild(12).GetComponent<Text>().text = personaje.pj.GetComponent<Guerrero>().aguante.ToString();
                        children.GetChild(13).GetComponent<Text>().text = personaje.pj.GetComponent<Guerrero>().vidaMaxima.ToString();
                        children.GetChild(14).GetComponent<Text>().text = personaje.pj.GetComponent<Guerrero>().armaduraTotal.ToString();
                        break;
                    case 2:
                        children.GetChild(7).GetComponent<Text>().text = personaje.pj.GetComponent<Cazador>().expActual.ToString();
                        children.GetChild(8).GetComponent<Text>().text = personaje.pj.GetComponent<Cazador>().expNivel.ToString();
                        children.GetChild(9).GetComponent<Text>().text = personaje.pj.GetComponent<Cazador>().fuerza.ToString();
                        children.GetChild(10).GetComponent<Text>().text = personaje.pj.GetComponent<Cazador>().agilidad.ToString();
                        children.GetChild(11).GetComponent<Text>().text = personaje.pj.GetComponent<Cazador>().inteligencia.ToString();
                        children.GetChild(12).GetComponent<Text>().text = personaje.pj.GetComponent<Cazador>().aguante.ToString();
                        children.GetChild(13).GetComponent<Text>().text = personaje.pj.GetComponent<Cazador>().vidaMaxima.ToString();
                        children.GetChild(14).GetComponent<Text>().text = personaje.pj.GetComponent<Cazador>().armaduraTotal.ToString();
                        break;
                    case 3:
                        children.GetChild(7).GetComponent<Text>().text = personaje.pj.GetComponent<Magoku>().expActual.ToString();
                        children.GetChild(8).GetComponent<Text>().text = personaje.pj.GetComponent<Magoku>().expNivel.ToString();
                        children.GetChild(9).GetComponent<Text>().text = personaje.pj.GetComponent<Magoku>().fuerza.ToString();
                        children.GetChild(10).GetComponent<Text>().text = personaje.pj.GetComponent<Magoku>().agilidad.ToString();
                        children.GetChild(11).GetComponent<Text>().text = personaje.pj.GetComponent<Magoku>().inteligencia.ToString();
                        children.GetChild(12).GetComponent<Text>().text = personaje.pj.GetComponent<Magoku>().aguante.ToString();
                        children.GetChild(13).GetComponent<Text>().text = personaje.pj.GetComponent<Magoku>().vidaMaxima.ToString();
                        children.GetChild(14).GetComponent<Text>().text = personaje.pj.GetComponent<Magoku>().armaduraTotal.ToString();
                        break;
                }

            }
        }
    }
}
