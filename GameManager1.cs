using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;


public class GameManager1 : MonoBehaviour
{

    public static GameManager1 instancia = null;
    public GameObject instanciaPersonaje;
    public GameObject instanciaInventario;
    public GameObject prefabInvUI;
    public GameObject inventarioUI;

    public GameObject prefabMenuUI;
    public GameObject menuJuegoUI;
    public GameObject prefabMenuJugador;
    public GameObject menuJugadorUI;

    public GameObject prefabMenuMuerte;
    public GameObject menuMuerteUI;
    public GameObject prefabMenuFin;
    public GameObject menuFinUI;

    public GameObject prefabMenuPagina;
    public GameObject menuPaginaUI;

    public Dictionary<int, Sprite> spritesObjeto;

    public Text texto;
    public Text texto2;
    public Text texto3;
    public Text texto4;

    public void setText(string s) {
        texto4.text = texto3.text;
        texto3.text = texto2.text;
        texto2.text = texto.text;
        texto.text = s;
    }
    private void Start()
    {
        cargarSpritesObjetos();
    }

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else if (instancia != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);//No destruir nuestro GameObject entre escenas
        iniciaPersonaje();
        iniciaInventario();
    }

    void iniciaPersonaje()
    {
        if (personaje.pj == null)
        {
            Instantiate(instanciaPersonaje);
        }

        cargarClaseInicio();

    }

    void cargarClaseInicio()
    {
        GameObject pjtemp = GameObject.FindGameObjectWithTag("Player");
        GameObject objTemp = GameObject.FindGameObjectWithTag("GameController");
        string n = objTemp.GetComponent<GameController>().name;
        pjtemp.GetComponent<personaje>().nombre = n;//objTemp.GetComponent<GameController>().name;
        pjtemp.transform.position = new Vector3(0, 3, 0);
        int opcion = objTemp.GetComponent<GameController>().opcion;
        switch (opcion)
        {
            case 1:
                pjtemp.GetComponent<Heroe>().clase = "guerrero";
                pjtemp.GetComponent<Guerrero>().enabled = true;
                pjtemp.GetComponent<Cazador>().enabled = false;
                pjtemp.GetComponent<Magoku>().enabled = false;
                break;
            case 2:
                pjtemp.GetComponent<Heroe>().clase = "cazador";
                pjtemp.GetComponent<Guerrero>().enabled = false;
                pjtemp.GetComponent<Cazador>().enabled = true;
                pjtemp.GetComponent<Magoku>().enabled = false;
                break;
            case 3:
                pjtemp.GetComponent<Heroe>().clase = "mago";
                pjtemp.GetComponent<Guerrero>().enabled = false;
                pjtemp.GetComponent<Cazador>().enabled = false;
                pjtemp.GetComponent<Magoku>().enabled = true;
                break;
        }
        personaje.pj.cargarPartida(n);

    }

    void iniciaInventario()
    {
        if (Inventario.inv == null)
        {
            Instantiate(instanciaInventario);
        }
        GameObject pjtemp = GameObject.FindGameObjectWithTag("Player");
        Inventario.inv.cargarEstado(pjtemp.GetComponent<personaje>().nombre);
    }

    public void toogleInventario()
    {
        if (Inventario.inv == null)
        {
            iniciaInventario();
        }
        if (inventarioUI == null)
        {
            Time.timeScale = 0.0f; //parar tiempo en juego;
            inventarioUI = Instantiate(prefabInvUI);
        }
        else
        {
            Destroy(inventarioUI);
            Time.timeScale = 1.0f;
        }

    }

    void cargarSpritesObjetos()
    {
        spritesObjeto = new Dictionary<int, Sprite>();
        foreach (Item obj in GameManager1.instancia.GetComponent<Manejador>().bda.bdArmas)
        {
            string ruta = Application.dataPath + "/Resources/" + obj.rutaSprite + ".png";
            if (File.Exists(ruta))
            {
                Sprite sprite = Resources.Load<Sprite>(obj.rutaSprite);
                spritesObjeto.Add(obj.id, sprite);
            }
        }

        foreach (Item obj in GameManager1.instancia.GetComponent<Manejador>().bdar.bdArmaduras)
        {
            string ruta = Application.dataPath + "/Resources/" + obj.rutaSprite + ".png";
            if (File.Exists(ruta))
            {
                Sprite sprite = Resources.Load<Sprite>(obj.rutaSprite);
                spritesObjeto.Add(obj.id, sprite);
            }
        }

        //Cargar sprites de pociones.

    }

    private void LateUpdate()
    {
        if (Input.GetButtonDown("Inventario"))
        {
            toogleInventario();
        }
        if (Input.GetButtonDown("Menu"))
        {
            toogleMenu();
        }
        if (Input.GetButtonDown("Personaje"))
        {
            tooglePersonaje();
        }

    }

    public void tooglePersonaje()
    {

        if (menuJugadorUI == null)
        {
            Time.timeScale = 0.0f; //parar tiempo en juego;
            menuJugadorUI = Instantiate(prefabMenuJugador);
        }
        else
        {
            Destroy(menuJugadorUI);
            Time.timeScale = 1.0f;
        }

    }

    public void toogleMenu()
    {

        if (menuJuegoUI == null)
        {
            Time.timeScale = 0.0f; //parar tiempo en juego;
            menuJuegoUI = Instantiate(prefabMenuUI);
        }
        else
        {
            Destroy(menuJuegoUI);
            Time.timeScale = 1.0f;
        }
    }

    public void toogleMuerte()
    {
        menuMuerteUI = Instantiate(prefabMenuMuerte);
    }
    public void regresarMuerte()
    {
        Destroy(menuMuerteUI);
    }

    public void toogleFin()
    {
        menuFinUI = Instantiate(prefabMenuFin);
    }
    public void regresarFin()
    {
        Destroy(menuFinUI);
    }

    public void tooglePagina(int numPagina)
    {
        Time.timeScale = 0.0f; //parar tiempo en juego;
        menuPaginaUI = Instantiate(prefabMenuPagina);
        menuPaginaUI.GetComponent<Escritor>().escribir(numPagina);
    }


    private void OnDestroy()
    {
        Inventario.inv.guardarEstado();
    }
}
