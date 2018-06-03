using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Manejador : MonoBehaviour {

    public BaseDatosPrueba bda;
    public BDArmaduras bdar;
    public BDPociones bdpo;

    // Use this for initialization
    void Start()
    {
        string datos = File.ReadAllText(Application.dataPath + "/Resources/armas.json");
        bda = JsonUtility.FromJson<BaseDatosPrueba>(datos);
        foreach (IArma temp in bda.bdArmas)
        {
            temp.generarEnumItem();
            temp.generarEnumEquipo();
            temp.generarEnumArma();
            
        }

        string datos1 = File.ReadAllText(Application.dataPath + "/Resources/armaduras.json");
        bdar = JsonUtility.FromJson<BDArmaduras>(datos1);
        foreach (IArmadura temp in bdar.bdArmaduras)
        {
            temp.generarEnumItem();
            temp.generarEnumEquipo();
        }
    }

    public IArma buscarArmaId(int id)
    {
        return bda.bdArmas.Find(arma => arma.id == id);
    }

    public bool existeArma(int id)
    {
        return bda.bdArmas.Exists(obj => obj.id == id);
    }

    public IArmadura buscarArmaduraId(int id)
    {
        return bdar.bdArmaduras.Find(obj => obj.id == id);
    }

    public bool existeArmadura(int id)
    {
        return bdar.bdArmaduras.Exists(obj => obj.id == id);
    }

    public IPocion buscarPocionId(int id)
    {
        return bdpo.bdPociones.Find(obj => obj.id == id);
    }

    public bool existePocion(int id)
    {
        return bdpo.bdPociones.Exists(obj => obj.id == id);
    }

    public Item busquedaGeneral(int id)
    {
        Item i = null;
        if (id >= 0 && id <= 100)
        {
            i = GameManager1.instancia.GetComponent<Manejador>().buscarArmaId(id);

        }
        else if (id > 100 && id <= 200)
        {
            i = GameManager1.instancia.GetComponent<Manejador>().buscarPocionId(id);
        }
        else if (id > 200 && id <= 300)
        {
            i = GameManager1.instancia.GetComponent<Manejador>().buscarArmaduraId(id);
        }
        return i;
    }

}
