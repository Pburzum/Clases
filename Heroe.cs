using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class Heroe : MonoBehaviour
{

    public static Heroe e;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public int fuerza;
    public int agilidad;
    public int inteligencia;
    public int aguante;
    public int armaduraTotal;
    public int armaduraBase;
    public int esquiva;
    public int nivel;
    public int expNivel;
    public int expActual;
    public int vidaActual;
    public int vidaMaxima;
    public bool dosManos;
    public string clase;

    /// <summary>
    /// Atributos correspodientes al equipamiento del personaje
    /// </summary>

    public IArmadura cabeza;
    public IArmadura pecho;
    public IArmadura piernas;
    public IArmadura pies;
    public IArma manoIzquierda = null;
    public IArma manoDerecha;

    // Para generar un inventario dentro de la clase podemos generar un clase generica de inventario que será un almacen de items.

    public int opcion;

    public Heroe()
    {
        //Constructor para crear un personaje nuevo que se implementará en las clases hijas
    }

    //Constructor para crear el personaje desde un archivo de guardado o base de datos
    public Heroe(int fuerza, int agilidad, int inteligencia, int aguante, int armaduraBase, int nivel, int expActual,
        IArmadura cabeza, IArmadura pecho, IArmadura piernas, IArmadura pies, IArma manoIzquierda, IArma manoDerecha)
    {

        this.fuerza = fuerza;
        this.agilidad = agilidad;
        this.inteligencia = inteligencia;
        this.aguante = aguante;
        this.armaduraBase = armaduraBase;
        this.nivel = nivel;
        this.expActual = expActual;
        this.cabeza = cabeza;
        this.pecho = pecho;
        this.piernas = piernas;
        this.pies = pies;
        this.manoIzquierda = manoIzquierda;
        this.manoDerecha = manoDerecha;
        if (this.manoDerecha.DosManos())
        {
            this.dosManos = true;
        }
        calcularVida();
        calcularArmadura();
        calcularEsquiva();

    }

    public void crearNuevoPersonaje()
    {
        GameObject objTemp = GameObject.FindGameObjectWithTag("GameController");
        this.opcion = objTemp.GetComponent<GameController>().opcion;
        switch (opcion)
        {
            case 1:
                gameObject.GetComponent<Guerrero>().crearGuerrero();
                break;
            case 2:
                gameObject.GetComponent<Cazador>().crearCazador();
                break;
            case 3:
                gameObject.GetComponent<Magoku>().crearMago();
                break;

        }

    }

    //----Propiedades de los atributos , Setter/Getter en Otros lenguajes----
    /*
    public int Fuerza
    {
        get { return fuerza; }
        set { fuerza = value; }
    }
    public int Agilidad
    {
        get { return agilidad; }
        set { agilidad = value; }
    }
    public int Inteligencia
    {
        get { return inteligencia; }
        set { inteligencia = value; }
    }
    public int Aguante
    {
        get { return aguante; }
        set { aguante = value; }
    }
    public int ArmaduraTotal
    {
        get { return armaduraTotal; }
        set { armaduraTotal = value; }
    }
    public int Esquiva
    {
        get { return esquiva; }
        set { esquiva = value; }
    }
    public int Nivel
    {
        get { return nivel; }
        set { nivel = value; }
    }
    public int ExpNivel
    {
        get { return expNivel; }
        set { expNivel = value; }
    }

    public int ExpActual
    {
        get { return expActual; }
        set
        {
            expActual += value;
            if (expActual >= expNivel)
            {
                nivelSubido = true;
                expActual = 0;
            }
        }
    }
    */

    //Metodo para añadir experiencia al jugador con la muerte de los enemigos

    public void addExp(int i)
    {
        Debug.Log("Has obtenido " + i + " exp");
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager1>().setText("Has obtenido " + i + " exp");
        switch (this.opcion)
        {
            case 1:
                gameObject.GetComponent<Guerrero>().ganarExperiencia(i);
                break;
            case 2:
                gameObject.GetComponent<Cazador>().ganarExperiencia(i);
                break;
            case 3:
                gameObject.GetComponent<Magoku>().ganarExperiencia(i);
                break;
        }
    }



    //--Metodos de clase a nivel de acciones

    public virtual int ataqueBasico()
    {
        int daño = 0;
        switch (this.opcion)
        {
            case 1:
                daño = gameObject.GetComponent<Guerrero>().ataqueBasico();
                break;
            case 2:
                daño = gameObject.GetComponent<Cazador>().ataqueBasico();
                break;
            case 3:
                daño = gameObject.GetComponent<Magoku>().ataqueBasico();
                break;
        }
        return daño;
    }

    //

    public void calcularVida()
    {
        this.vidaMaxima = this.aguante * 10;
        this.vidaActual = this.vidaMaxima;
    }

    public int retornarVida()
    {
        int vida = 0;
        switch (this.opcion)
        {
            case 1:
                vida = gameObject.GetComponent<Guerrero>().vidaMaxima;
                break;
            case 2:
                vida = gameObject.GetComponent<Cazador>().vidaMaxima;
                break;
            case 3:
                vida = gameObject.GetComponent<Magoku>().vidaMaxima;
                break;
        }
        return vida;

    }

    public void calcularArmadura()
    {
        this.armaduraTotal = this.armaduraBase + this.cabeza.Armadura
            + this.pecho.Armadura + this.piernas.Armadura + this.pies.Armadura;
        /*if (this.manoIzquierda.Familia == FamiliaArma.ESCUDO)
        {
            this.armaduraTotal += manoIzquierda.armadura;
        }
       */
    }

    public virtual void calcularEsquiva()
    {
        this.esquiva = this.agilidad + this.inteligencia;
    }

    //Nota parche 17/04 añadidos metodos de esquiva y reduccion

    public bool esquivarAtaque()
    {
        System.Random r = new System.Random();
        int hit = r.Next(0, 100);
        if (hit > this.esquiva)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public virtual float dañoReducido(float dañoInicial)//--> Acceder a la especilización
    {
        switch (this.opcion)
        {
            case 1:
                return gameObject.GetComponent<Guerrero>().dañoReducido(dañoInicial);
            case 2:
                return gameObject.GetComponent<Cazador>().dañoReducido(dañoInicial);
            case 3:
                return gameObject.GetComponent<Magoku>().dañoReducido(dañoInicial);
            default:
                return 0;
        }
    }

    //


    public int equiparHijo(int id)
    {
        int idAnt = 0;
        if (gameObject.GetComponent<Cazador>().enabled == true)
        {
            idAnt = gameObject.GetComponent<Cazador>().equiparCazador(id);

        }
        else if (gameObject.GetComponent<Guerrero>().enabled == true)
        {
            idAnt = gameObject.GetComponent<Guerrero>().equiparGuerrero(id);

        }
        else if (gameObject.GetComponent<Magoku>().enabled == true)
        {
            idAnt = gameObject.GetComponent<Magoku>().equiparMago(id);
        }
        return idAnt;
    }
    /*
     * Accederemos al metodo de guardar partida del heroe, donde crearemos un primer fichero donde guardaremos una cadena con la clase
     * para que posteriormente en la carga tan solo con leer ese fichero y comparar la variable sepamos a que clase hija acceder y a su metodo
     * 
     */

    public void guardarPartida(string nombre)
    {
        switch (this.clase)
        {
            case "guerrero":
                generarFicheroClase(nombre);
                gameObject.GetComponent<Guerrero>().guardarGuerrero(nombre);
                break;
            case "cazador":
                generarFicheroClase(nombre);
                gameObject.GetComponent<Cazador>().guardarCazador(nombre);
                break;
            case "mago":
                generarFicheroClase(nombre);
                gameObject.GetComponent<Magoku>().guardarMago(nombre);
                break;
        }
    }

    public void generarFicheroClase(string nombre)
    {
        string claseString = JsonUtility.ToJson(this);
        string nombreFichero = "/Resources/clase" + nombre + ".json";
        File.WriteAllText(Application.dataPath + nombreFichero, claseString);
    }

    public void cargarPartida(string nombre)
    {
        string nombreFichero = "/Resources/clase" + nombre + ".json";
        if (File.Exists(Application.dataPath + nombreFichero))
        {
            string datos = File.ReadAllText(Application.dataPath + nombreFichero);
            JsonUtility.FromJsonOverwrite(datos, this);
            if (this.clase == "guerrero")
            {
                gameObject.GetComponent<Guerrero>().enabled = true;
                gameObject.GetComponent<Cazador>().enabled = false;
                gameObject.GetComponent<Magoku>().enabled = false;
                gameObject.GetComponent<Guerrero>().cargarGuerrero(nombre);
            }
            else if (this.clase == "cazador")
            {
                gameObject.GetComponent<Guerrero>().enabled = false;
                gameObject.GetComponent<Cazador>().enabled = true;
                gameObject.GetComponent<Magoku>().enabled = false;
                gameObject.GetComponent<Cazador>().cargarCazador(nombre);
            }
            else if (this.clase == "mago")
            {
                gameObject.GetComponent<Guerrero>().enabled = false;
                gameObject.GetComponent<Cazador>().enabled = false;
                gameObject.GetComponent<Magoku>().enabled = true;
                gameObject.GetComponent<Magoku>().cargarMago(nombre);
            }
        }
    }

    //28-05

    private void LateUpdate()
    {
        if (Input.GetButtonDown("Hab1"))
        {
            primeraHabilidad();
        }
        if (Input.GetButtonDown("Hab2"))
        {
            segundaHabilidad();
        }
        if (Input.GetButtonDown("Hab3"))
        {
            terceraHabilidad();
        }
        if (Input.GetButtonDown("Hab4"))
        {
            cuartaHabilidad();
        }
    }
    public void primeraHabilidad()
    {
        switch (this.opcion)
        {
            case 1:
                gameObject.GetComponent<Guerrero>().furia();
                break;
            case 2:
                gameObject.GetComponent<Cazador>().cuchillada();
                break;
            case 3:
                gameObject.GetComponent<Magoku>().trampaRayo();
                break;
        }
    }

    public void segundaHabilidad()
    {
        switch (this.opcion)
        {
            case 1:
                gameObject.GetComponent<Guerrero>().escudo();
                break;
            case 2:
                gameObject.GetComponent<Cazador>().disparoRapido();
                break;
            case 3:
                gameObject.GetComponent<Magoku>().bolaEnergia();
                break;
        }
    }

    public void terceraHabilidad()
    {
        switch (this.opcion)
        {
            case 1:
                gameObject.GetComponent<Guerrero>().torbellino();
                break;
            case 2:
                gameObject.GetComponent<Cazador>().sprint();
                break;
            case 3:
                gameObject.GetComponent<Magoku>().lluviaTruenos();
                break;
        }
    }

    public void cuartaHabilidad()
    {
        switch (this.opcion)
        {
            case 1:
                gameObject.GetComponent<Guerrero>().berserker();
                break;
            case 2:
                gameObject.GetComponent<Cazador>().disparoMortal();
                break;
            case 3:
                gameObject.GetComponent<Magoku>().superSaiyan();
                break;
        }
    }


}
