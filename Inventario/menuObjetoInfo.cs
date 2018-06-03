using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuObjetoInfo : MonoBehaviour
{
    public int id;
    public int posicion;
    public GameObject objetoUI;
    public GameObject objetoEscena;
    private Transform equipoUI = null;

    public void soltarObjeto()
    {
        Inventario.inv.borraObjetoPosicion(posicion);
        GameObject obj = Instantiate(objetoEscena);
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        obj.transform.position = new Vector3(jugador.transform.position.x + 0.5f, jugador.transform.position.y, jugador.transform.position.z + 0.5f);
        obj.name = "objeto_" + id.ToString();
        obj.GetComponent<ObjetoEscena>().id = id;

        Destroy(objetoUI);
        this.gameObject.SetActive(false);
    }

    public void destruirObjeto()
    {
        Inventario.inv.borraObjetoPosicion(posicion);
        Destroy(objetoUI);
        this.gameObject.SetActive(false);
    }

    public void equiparObjeto()
    {
        if (personaje.pj != null)
        {
            personaje.pj.equipaObjeto(this.id);
            if (this.equipoUI != null)
            {
                Sprite sprite = null;
                GameManager1.instancia.spritesObjeto.TryGetValue(id, out sprite);
                Item objeto = GameManager1.instancia.GetComponent<Manejador>().busquedaGeneral(id);
                int numeroHijo = sacarNumeroHijo(objeto);
                GameObject armaObjeto = equipoUI.GetChild(numeroHijo).gameObject;
                armaObjeto.transform.GetChild(0).GetComponent<Image>().color = new Color(256f, 256f, 256f, 256f);
                armaObjeto.transform.GetChild(0).GetComponent<Image>().sprite = sprite;
                //GameManager1.instancia.instanciaInventario.GetComponent<Inventario>().borrarObjeto(id);

                Inventario.inv.borrarObjeto(id);
                Inventario.inv.agregarObjeto(personaje.pj.antItem);
                GameManager1.instancia.inventarioUI.GetComponentInChildren<CargaObjetos>().addObjeto(personaje.pj.antItem);

            }
            Destroy(objetoUI);
        }
        this.gameObject.SetActive(false);
    }
    void Awake()
    {
        Transform child = GameManager1.instancia.inventarioUI.transform.GetChild(0);
        equipoUI = getChild(child, "Equipo");

    }

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

    public Transform getChild(Transform padre, string nombre)
    {
        Transform ret = null;
        foreach (Transform t in padre)
        {
            if (t.name == "Equipo")
            {
                ret = t;
            }

        }
        return ret;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
