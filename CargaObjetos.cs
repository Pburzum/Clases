using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargaObjetos : MonoBehaviour {

    public GameObject objeto;
    public Inventario inventario;
    public Manejador manejador;
    private Transform equipoUI=null;

    void Start () {
        inventario = Inventario.inv;
        manejador = GameManager1.instancia.GetComponent<Manejador>();
        this.pintaObjetos();
        this.pintaEquipo();
	}

    private void Awake()
    {
        Transform child = this.transform.parent.parent;
        equipoUI = child.Find("Equipo");
    }

    public void pintaObjetos()
    {
        int posicion = 0;
        foreach (Item i in inventario.listaObjetos)
        {
             
            GameObject instanciaObj = Instantiate(objeto);
            eventosObjeto ev = instanciaObj.GetComponent<eventosObjeto>();
            instanciaObj.transform.localScale = new Vector3(1f, 1f, 1f);
            ev.id = i.id;
            ev.posicion = posicion;
            if (i.Casilla == Casilla.MANO_DERECHA || i.Casilla == Casilla.MANO_IZQUIERDA || i.Casilla == Casilla.DOS_MANOS)
            {
                Item detalle = manejador.buscarArmaId(i.id);
                instanciaObj.transform.GetComponentInChildren<Text>().text = detalle.nombre;
                instanciaObj.transform.SetParent(this.transform);
            }
            else
            {
                Item detalle = manejador.buscarArmaduraId(i.id);
                string prueba= detalle.nombre;
                instanciaObj.transform.GetComponentInChildren<Text>().text = prueba;
            }
            posicion++;
            
        }
    }

    public void addObjeto(int id)
    {
        if (id > 0)
        {
            GameObject instanciaOb = Instantiate(objeto);
            eventosObjeto ev = instanciaOb.GetComponent<eventosObjeto>();
            instanciaOb.transform.localScale = new Vector3(1f, 1f, 1f);
            ev.id = id;
            if (id >= 0 && id <= 100)
            {
                ev.posicion = inventario.handler.bda.bdArmas.Count == 0 ? 0 : inventario.handler.bda.bdArmas.Count - 1;

            }
            else if (id > 100 && id <= 200)
            {
                ev.posicion = inventario.handler.bdpo.bdPociones.Count == 0 ? 0 : inventario.handler.bdpo.bdPociones.Count - 1;

            }
            else if (id > 200 && id <= 300)
            {
                ev.posicion = inventario.handler.bdar.bdArmaduras.Count == 0 ? 0 : inventario.handler.bdar.bdArmaduras.Count - 1;

            }
            Item detalleItem = manejador.busquedaGeneral(id);
            instanciaOb.transform.GetComponentInChildren<Text>().text = detalleItem.nombre;
            instanciaOb.transform.SetParent(this.transform);

        }
    }

    //Metodo que busca que Script esta activado en el jugador para poder acceder al inventario de la clase correspondiente
    private void pintaEquipo()
    {
        if (personaje.pj.GetComponent<Cazador>().enabled == true)
        {
            pintarCazador();

        }
        else if (personaje.pj.GetComponent<Guerrero>().enabled == true)
        {
            pintarGuerrero();

        }
        else if (personaje.pj.GetComponent<Magoku>().enabled == true)
        {
            pintarMago();
        }

    }

    private void pintarCazador()
    {
        if (personaje.pj != null && personaje.pj.GetComponent<Cazador>().manoDerecha != null)
        {
            Item objeto = personaje.pj.GetComponent<Cazador>().manoDerecha;
            pintar(objeto);
        }
        if (personaje.pj != null && personaje.pj.GetComponent<Cazador>().manoIzquierda != null)
        {
            Item objeto = personaje.pj.GetComponent<Cazador>().manoIzquierda;
            pintar(objeto);
        }
        if (personaje.pj != null && personaje.pj.GetComponent<Cazador>().cabeza != null)
        {
            Item objeto = personaje.pj.GetComponent<Cazador>().cabeza;
            pintar(objeto);
        }
        if (personaje.pj != null && personaje.pj.GetComponent<Cazador>().pecho != null)
        {
            Item objeto = personaje.pj.GetComponent<Cazador>().pecho;
            pintar(objeto);
        }
        if (personaje.pj != null && personaje.pj.GetComponent<Cazador>().piernas != null)
        {
            Item objeto = personaje.pj.GetComponent<Cazador>().piernas;
            pintar(objeto);
        }
        if (personaje.pj != null && personaje.pj.GetComponent<Cazador>().pies != null)
        {
            Item objeto = personaje.pj.GetComponent<Cazador>().pies;
            pintar(objeto);
        }

    }

    private void pintarGuerrero()
    {
        if (personaje.pj != null && personaje.pj.GetComponent<Guerrero>().manoDerecha != null)
        {
            Item objeto = personaje.pj.GetComponent<Guerrero>().manoDerecha;
            pintar(objeto);
        }
        if (personaje.pj != null && personaje.pj.GetComponent<Guerrero>().manoIzquierda != null)
        {
            Item objeto = personaje.pj.GetComponent<Guerrero>().manoIzquierda;
            pintar(objeto);
        }
        if (personaje.pj != null && personaje.pj.GetComponent<Guerrero>().cabeza != null)
        {
            Item objeto = personaje.pj.GetComponent<Guerrero>().cabeza;
            pintar(objeto);
        }
        if (personaje.pj != null && personaje.pj.GetComponent<Guerrero>().pecho != null)
        {
            Item objeto = personaje.pj.GetComponent<Guerrero>().pecho;
            pintar(objeto);
        }
        if (personaje.pj != null && personaje.pj.GetComponent<Guerrero>().piernas != null)
        {
            Item objeto = personaje.pj.GetComponent<Guerrero>().piernas;
            pintar(objeto);
        }
        if (personaje.pj != null && personaje.pj.GetComponent<Guerrero>().pies != null)
        {
            Item objeto = personaje.pj.GetComponent<Guerrero>().pies;
            pintar(objeto);
        }
    }

    private void pintarMago()
    {
        if (personaje.pj != null && personaje.pj.GetComponent<Magoku>().manoDerecha != null)
        {
            Item objeto = personaje.pj.GetComponent<Magoku>().manoDerecha;
            pintar(objeto);
        }
        if (personaje.pj != null && personaje.pj.GetComponent<Magoku>().manoIzquierda != null)
        {
            Item objeto = personaje.pj.GetComponent<Magoku>().manoIzquierda;
            pintar(objeto);
        }
        if (personaje.pj != null && personaje.pj.GetComponent<Magoku>().cabeza != null)
        {
            Item objeto = personaje.pj.GetComponent<Magoku>().cabeza;
            pintar(objeto);
        }
        if (personaje.pj != null && personaje.pj.GetComponent<Magoku>().pecho != null)
        {
            Item objeto = personaje.pj.GetComponent<Magoku>().pecho;
            pintar(objeto);
        }
        if (personaje.pj != null && personaje.pj.GetComponent<Magoku>().piernas != null)
        {
            Item objeto = personaje.pj.GetComponent<Magoku>().piernas;
            pintar(objeto);
        }
        if (personaje.pj != null && personaje.pj.GetComponent<Magoku>().pies != null)
        {
            Item objeto = personaje.pj.GetComponent<Magoku>().pies;
            pintar(objeto);
        }

    }

    private void pintar(Item i)
    {
        int id = i.id;
        Sprite sprite = null;
        GameManager1.instancia.spritesObjeto.TryGetValue(id, out sprite);
        int numeroHijo = sacarNumeroHijo(i);
        GameObject armaObjeto = equipoUI.GetChild(numeroHijo).gameObject;
        armaObjeto.transform.GetChild(0).GetComponent<Image>().color = new Color(256f, 256f, 256f, 256f);
        armaObjeto.transform.GetChild(0).GetComponent<Image>().sprite = sprite;

    }

    //Metodo que se utiliza para buscar a través de la casilla del objeto, a que hijo de la interfaz va a acceder para poner el sprite

    private int sacarNumeroHijo(Item obj)
    {
        int opcion = 0;
        switch (obj.casilla)
        {

            case Casilla.MANO_DERECHA:
                opcion = 0;
                break;
            case Casilla.MANO_IZQUIERDA:
                opcion = 1;
                break;
            case Casilla.DOS_MANOS:
                opcion = 0;
                break;
            case Casilla.CABEZA:
                opcion = 2;
                break;
            case Casilla.PECHO:
                opcion = 3;
                break;
            case Casilla.PIERNAS:
                opcion = 4;
                break;
            case Casilla.PIES:
                opcion = 5;
                break;

        }
        return opcion;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
