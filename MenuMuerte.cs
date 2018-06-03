using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMuerte : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Time.timeScale = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void regresar()
    {
        GameManager1.instancia.GetComponent<GameManager1>().regresarMuerte();
        Time.timeScale = 1.0f;
    }
}
