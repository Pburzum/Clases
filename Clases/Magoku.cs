using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Threading;

[Serializable]
public class Magoku : Heroe
{
    public int velocidad;
    [SerializeField] GameObject esferaMago;
    public bool trampaActiva = false;
    int contador;
    public Timer t;
    public Magoku()
    {
        /*
        this.fuerza = 6;
        this.agilidad = 8;
        this.inteligencia = 14;
        this.aguante = 7;
        this.armaduraBase = 1;
        this.nivel = 1;
        this.expActual = 0;
        this.velocidad = 10;
        this.cabeza = new IArmadura(1007, 0, Casilla.CABEZA, "Sombrero de paja", Rareza.COMUN,"cabeza", 0, 100, 1);
        this.pecho = new IArmadura(1008, 0, Casilla.PECHO, "Tunica de tela", Rareza.COMUN, "pecho", 0, 100, 1);
        this.piernas = new IArmadura(1009, 0, Casilla.PIERNAS, "Pantalones de tela", Rareza.COMUN,"piernas", 0, 100, 1);
        this.pies = new IArmadura(1010, 0, Casilla.PIES, "Chanclas", Rareza.COMUN,"pies", 0, 100, 3); ;
        this.manoIzquierda = null;
        this.manoDerecha = new IArma(1015, 0, Casilla.MANO_DERECHA, "Baston de madera", Rareza.COMUN,"baston", 0, FamiliaArma.BASTON, 2, 4);
        if (this.manoDerecha.DosManos())
        {
            this.dosManos = true;
        }
        calcularVida();
        calcularArmadura();
        calcularEsquiva();
        */
    }

    public Magoku(int fuerza, int agilidad, int inteligencia, int aguante, int armaduraBase, int nivel, int expActual,
        IArmadura cabeza, IArmadura pecho, IArmadura piernas, IArmadura pies, IArma manoIzquierda, IArma manoDerecha) : base(
            fuerza, agilidad, inteligencia, aguante, armaduraBase, nivel, expActual, cabeza, pecho, piernas, pies, manoIzquierda, manoDerecha)
    {
        this.velocidad = 10;
        calcularVida();
        calcularArmadura();
        calcularEsquiva();
    }

    public void crearMago()
    {
        this.fuerza = 6;
        this.agilidad = 8;
        this.inteligencia = 14;
        this.aguante = 7;
        this.armaduraBase = 1;
        this.nivel = 1;
        this.expActual = 0;
        this.velocidad = 10;
        this.cabeza = new IArmadura(288, 0, Casilla.CABEZA, "Sombrero de paja", Rareza.COMUN, "cabeza", 0, 100, 1);
        this.pecho = new IArmadura(289, 0, Casilla.PECHO, "Tunica de tela", Rareza.COMUN, "pecho", 0, 100, 1);
        this.piernas = new IArmadura(290, 0, Casilla.PIERNAS, "Pantalones de tela", Rareza.COMUN, "piernas", 0, 100, 1);
        this.pies = new IArmadura(291, 0, Casilla.PIES, "Chanclas", Rareza.COMUN, "pies", 0, 100, 3); ;
        this.manoIzquierda = null;
        this.manoDerecha = new IArma(98, 0, Casilla.MANO_DERECHA, "Baston de madera", Rareza.COMUN, "baston", 0, FamiliaArma.BASTON, 2, 4);
        if (this.manoDerecha.DosManos())
        {
            this.dosManos = true;
        }
        calcularVida();
        calcularArmadura();
        calcularEsquiva();

    }

    public void calculoExperiencia()
    {
        switch (this.nivel)
        {
            case 1:
            case 2:
            case 3:
                this.expNivel = this.nivel * 100;
                break;
            case 4:
            case 5:
            case 6:
                this.expNivel = this.nivel * 200;
                break;
            case 7:
            case 8:
            case 9:
                this.expNivel = this.nivel * 400;
                break;
            case 10:
            case 11:
            case 12:
                this.expNivel = this.nivel * 600;
                break;
            case 13:
            case 14:
            case 15:
                this.expNivel = this.nivel * 900;
                break;
            case 16:
            case 17:
            case 18:
                this.expNivel = this.nivel * 1000;
                break;
            case 19:
            case 20:
                this.expNivel = this.nivel * 1500;
                break;

        }
    }

    public void ganarExperiencia(int exp)
    {
        this.expActual += exp;
        if (this.expActual >= this.expNivel)
        {
            this.subirNivel();
            this.expActual = 0;
        }
    }

    public void subirNivel()
    {
        this.nivel += 1;
        this.fuerza += 1;
        this.agilidad += 1;
        this.inteligencia += 4;
        this.aguante += 1;
        this.calculoExperiencia();
        this.calcularEsquiva();
        this.calcularVida();
        Debug.Log("Has subido al nivel " + this.nivel);
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager1>().setText("Has subido al nivel " + this.nivel);
    }
    //Metodo para realizar el ataque a un enemigo concreto
    public void realizarAtaque(Enemigo e) { }//NO IMPLEMENTADO


    //Metodo para calcular el daño realizado de armas mas estadisticas
    public override int ataqueBasico()
    {
        System.Random r = new System.Random();
        if (r.Next(1, 20) >= 20)
        {
            //Golpe crítico
            return (this.manoDerecha.generarDaño() + (this.inteligencia / 2)) * 2;
        }
        else
        {
            return this.manoDerecha.generarDaño() + (this.inteligencia / 2);
        }
        //movimiento del enemigo hacia atras 15 metros --> Insertar codigo

    }

    public override float dañoReducido(float dañoInicial)
    {
        return dañoInicial - this.armaduraTotal/2;
    }

    //1a Habilidad
    public void trampaRayo()
    {
        if (this.nivel < 3)
        {
            Debug.Log("Esta habilidad se desbloquea al alcanzar el nivel 3");
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager1>().setText("Esta habilidad se desbloquea al alcanzar el nivel 3");
            return;
        }
        if (this.trampaActiva)
        {
            Debug.Log("No puedes colocar otra trampa aún");
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager1>().setText("No puedes colocar otra trampa aún (" + contador + "s)");
            return;
        }

        Debug.Log("Trampa de rayos colocada");
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager1>().setText("Trampa de rayos colocada");
        //GameObject.FindGameObjectWithTag("Text").setText();
        trampaActiva = true;
        contador = 9;
        t = new Timer(Tick, "", 0, 1000);
        GameObject esfera = Instantiate(esferaMago, transform.position, Quaternion.identity);
    }
    //2a Habilidad
    public void bolaEnergia()
    {
        Debug.Log("Habilidad no disponible aún");
    }
    //3a Habilidad
    public void lluviaTruenos()
    {
        Debug.Log("Habilidad no disponible aún");
    }
    //4a Habilidad
    public void superSaiyan()
    {
        Debug.Log("Habilidad no disponible aún");
    }
    private void Tick(object state)
    {
        contador--;
        if (contador <= 0)
        {
            trampaActiva = false;
            t.Dispose();
        }
    }

    // TRATAMIENTO DE DATOS

    public void guardarMago(string name)
    {
        string partida = JsonUtility.ToJson(this);
        string nombreFichero = "/Resources/partida" + name + ".json";
        File.WriteAllText(Application.dataPath + nombreFichero, partida);
    }

    public void cargarMago(string nombre)
    {
        string nombreFichero = "/Resources/partida" + nombre + ".json";
        if (File.Exists(Application.dataPath + nombreFichero))
        {
            string datos = File.ReadAllText(Application.dataPath + nombreFichero);
            JsonUtility.FromJsonOverwrite(datos, this);
        }
        trampaActiva = false;
}

    public int equiparMago(int id)
    {
        Item i2 = new Item();
        Item antiguoItem = new Item();
        int idAnt = 0;

        if (id >= 0 && id <= 100)
        {
            i2 = GameManager1.instancia.GetComponent<Manejador>().buscarArmaId(id);

        }
        else if (id > 100 && id <= 200)
        {
            i2 = GameManager1.instancia.GetComponent<Manejador>().buscarPocionId(id);

        }
        else if (id > 200 && id <= 300)
        {
            i2 = GameManager1.instancia.GetComponent<Manejador>().buscarArmaduraId(id);
        }
        switch (i2.casilla)
        {
            case Casilla.MANO_DERECHA:
                antiguoItem = this.manoDerecha;
                this.manoDerecha = (IArma)i2;
                break;
            case Casilla.MANO_IZQUIERDA:
                antiguoItem = this.manoIzquierda;
                this.manoDerecha = (IArma)i2;
                break;
            case Casilla.DOS_MANOS:
                antiguoItem = this.manoDerecha;
                this.manoDerecha = (IArma)i2;
                break;

            case Casilla.CABEZA:
                antiguoItem = this.cabeza;
                this.cabeza = (IArmadura)i2;
                break;
            case Casilla.PECHO:
                antiguoItem = this.pecho;
                this.pecho = (IArmadura)i2;
                break;
            case Casilla.PIERNAS:
                antiguoItem = this.piernas;
                this.piernas = (IArmadura)i2;
                break;
            case Casilla.PIES:
                antiguoItem = this.pies;
                this.pies = (IArmadura)i2;
                break;

        }
        idAnt = antiguoItem.id;
        return idAnt;
    }
}

