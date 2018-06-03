using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int opcion = 0;
    public string name = "Default";
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void cambiarOpcion(int i)
    {
        this.opcion = i;
    }

    public void cogerNombre()
    {
        this.name = GameObject.FindGameObjectWithTag("Nombre").GetComponent<InputField>().text;
    }

    public void enterGame()
    {
        cogerNombre();
        if (this.opcion > 0 && this.opcion < 4 && this.name != "Default")
        {
            SceneManager.LoadScene("Juego");
        }
    }

    public void cargarPartida()
    {
        cogerNombre();
        string nombreFichero = "/Resources/partida" + this.name + ".json";
        if (File.Exists(Application.dataPath + nombreFichero))
        {
            SceneManager.LoadScene("Juego");
        }
        else
        {
            GameObject tmp = GameObject.Find("Aviso");
            tmp.GetComponent<Text>().enabled = true;
        }
    }

    public void atras()
    {
        Destroy(GameObject.FindGameObjectWithTag("GameController"));
        SceneManager.LoadScene("MenuPrincipal");
    }



}
