using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpcionesMenu : MonoBehaviour {
    public GameObject prefabControles;
    public GameObject controlesUI;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void abrirOpciones()
    {
        if (controlesUI == null)
        {
            controlesUI = Instantiate(prefabControles);
        }
        
    }

    public void regresarJuego()
    {
        GameManager1.instancia.GetComponent<GameManager1>().toogleMenu();
    }

    public void guardarSalir()
    {
        //Destroy(GameObject.FindGameObjectWithTag("Player"));
        //Destroy(GameObject.FindGameObjectWithTag("Inventario"));
        //Destroy(GameObject.FindGameObjectWithTag("GameController"));
        //Destroy(GameObject.FindGameObjectWithTag("GameManager"));
        //SceneManager.LoadScene("MenuPrincipal");
        Application.Quit();
    }
}
