using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

[Serializable]
public class Inventario : MonoBehaviour
{

    public static Inventario inv = null;
    public List<Item> listaObjetos;
    public int limiteInventario = 21;
    public GameObject menuObjeto;
    public Manejador handler;


    private void Awake()
    {
        if (inv == null)
        {
            inv = this;
        }
        else if (inv != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (GameManager1.instancia != null)
        {
            handler = GameManager1.instancia.GetComponent<Manejador>();
        }
    }

    private void cargarInventario()
    {
        listaObjetos = new List<Item>();

    }

    public void agregarObjeto(int id)
    {
        if (handler.existeArma(id) && canAdd(id))
        {
            IArma temp = handler.buscarArmaId(id);
            listaObjetos.Add(temp);

        }
        else if (handler.existeArmadura(id) && canAdd(id))
        {
            IArmadura temp = handler.buscarArmaduraId(id);
            listaObjetos.Add(temp);
        }
        else
        {
            //agregar pociones
        }
    }

    public bool enInventario(int id)
    {
        return listaObjetos.Exists(obj => obj.id == id);
    }

    public void borrarObjeto(int id)
    {
        if (enInventario(id))
        {
            listaObjetos.Remove(listaObjetos.Find(obj => obj.id == id));
        }
    }

    public void guardarEstado()
    {
        string nombre = personaje.pj.nombre;
        string inventarioString = JsonUtility.ToJson(this);
        File.WriteAllText(Application.dataPath + "/Resources/inv" + nombre + ".json", inventarioString);
    }

    public void cargarEstado(string nombre)
    {
        if (File.Exists(Application.dataPath + "/Resources/inv" + nombre + ".json"))
        {
            string datos = File.ReadAllText(Application.dataPath + "/Resources/inv" + nombre + ".json");
            JsonUtility.FromJsonOverwrite(datos, this);
        }

    }

    public bool canAdd(int id)
    {
        if (listaObjetos.Count > 21)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void activarMenuObjeto(int id, int posicion, RectTransform rectT, Vector2 eventPos, GameObject objeto)
    {
        if (menuObjeto == null)
        {
            menuObjeto = GameManager1.instancia.inventarioUI.transform.GetChild(0).Find("MenuObjeto").gameObject;
        }
        menuObjetoInfo menu = menuObjeto.GetComponent<menuObjetoInfo>();
        menu.id = id;
        menu.posicion = posicion;
        menu.objetoUI = objeto;
        //Saber donde estamos dentro del inventario
        Rect rec = RectTransformUtility.PixelAdjustRect(rectT, GameManager1.instancia.inventarioUI.GetComponent<Canvas>());
        //Calcular offset --> Cambiar el centro del panel que sale respecto al click del raton
        float offSetX = this.menuObjeto.GetComponent<RectTransform>().rect.width / 2;
        float offSetY = this.menuObjeto.GetComponent<RectTransform>().rect.height / 2;
        Vector3 pos = new Vector3(eventPos.x + offSetX, eventPos.y - offSetY);
        this.menuObjeto.GetComponent<RectTransform>().position = pos;
        this.menuObjeto.SetActive(true);

    }

    public void borraObjetoPosicion(int posicion)
    {
        if (posicion < listaObjetos.Count)
        {
            listaObjetos.Remove(listaObjetos[posicion]); //acceso directo
        }
    }


}
