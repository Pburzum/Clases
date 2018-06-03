using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ManejadorBD : MonoBehaviour {

    public BaseDatosArmas bda;
	// Use this for initialization
	void Start () {
        string datos = File.ReadAllText(Application.dataPath + "/Recursos/armas.json");
        bda = JsonUtility.FromJson<BaseDatosArmas>(datos);
        
	}
	
	public Arma buscarObjId(int id)
    {
        return bda.baseDatos.Find(arma => arma.id == id);
    }
}
