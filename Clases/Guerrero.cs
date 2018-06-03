using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;

[Serializable]
public class Guerrero : Heroe
{
    public int velocidad;
    public int contadorB;
    public bool beerserkerActivo = false;
    private Timer t;
    public Guerrero()
    {
        /*
        this.fuerza = 10;
        this.agilidad = 8;
        this.inteligencia = 7;
        this.aguante = 10;
        this.armaduraBase = 3;
        this.nivel = 1;
        this.expActual = 0;
        this.velocidad = 10;
        this.cabeza = new IArmadura(1003, 0, Casilla.CABEZA, "Casco de cobre", Rareza.COMUN,"cabeza", 0, 100, 3);
        this.pecho = new IArmadura(1004, 0, Casilla.PECHO, "Peto de cobre", Rareza.COMUN,"pecho", 0, 100, 3);
        this.piernas = new IArmadura(1005, 0, Casilla.PIERNAS, "Malla de cobre", Rareza.COMUN,"piernas", 0, 100, 3);
        this.pies = new IArmadura(1006, 0, Casilla.PIES, "Chanclas", Rareza.COMUN,"pies", 0, 100, 3); ;
        this.manoIzquierda = new IArma(1, 0, Casilla.MANO_IZQUIERDA, "Escudo roto", Rareza.COMUN,"escudo", 0, FamiliaArma.ESCUDO, 0, 1);
        this.manoIzquierda.armadura = 1;
        this.manoDerecha = new IArma(1011, 0, Casilla.MANO_DERECHA, "Espada de cobre", Rareza.COMUN,"espada", 0, FamiliaArma.ESPADA, 2, 4);
        if (this.manoDerecha.DosManos())
        {
            this.dosManos = true;
        }
        calcularVida();
        calcularArmadura();
        calcularEsquiva();
        */
    }

    public Guerrero(int fuerza, int agilidad, int inteligencia, int aguante, int armaduraBase, int nivel, int expActual,
        IArmadura cabeza, IArmadura pecho, IArmadura piernas, IArmadura pies, IArma manoIzquierda, IArma manoDerecha) : base(
            fuerza, agilidad, inteligencia, aguante, armaduraBase, nivel, expActual, cabeza, pecho, piernas, pies, manoIzquierda, manoDerecha)
    {
        this.velocidad = 10;
        calcularVida();
        calcularArmadura();
        calcularEsquiva();
    }

    public void crearGuerrero()
    {
        this.fuerza = 10;
        this.agilidad = 8;
        this.inteligencia = 7;
        this.aguante = 10;
        this.armaduraBase = 3;
        this.nivel = 1;
        this.expActual = 0;
        this.velocidad = 10;
        this.cabeza = new IArmadura(284, 0, Casilla.CABEZA, "Casco de cobre", Rareza.COMUN, "cabeza", 0, 100, 3);
        this.pecho = new IArmadura(285, 0, Casilla.PECHO, "Peto de cobre", Rareza.COMUN, "pecho", 0, 100, 3);
        this.piernas = new IArmadura(286, 0, Casilla.PIERNAS, "Malla de cobre", Rareza.COMUN, "piernas", 0, 100, 3);
        this.pies = new IArmadura(287, 0, Casilla.PIES, "Chanclas", Rareza.COMUN, "pies", 0, 100, 3); ;
        this.manoIzquierda = new IArma(96, 0, Casilla.MANO_IZQUIERDA, "0", Rareza.COMUN, "escudo", 0, FamiliaArma.ESCUDO, 0, 1);
        this.manoIzquierda.armadura = 1;
        this.manoDerecha = new IArma(97, 0, Casilla.MANO_DERECHA, "Espada de cobre", Rareza.COMUN, "espada", 0, FamiliaArma.ESPADA, 2, 4);
        if (this.manoDerecha.DosManos())
        {
            this.dosManos = true;
        }
        calcularVida();
        calcularArmadura();
        calcularEsquiva();
        calculoExperiencia();

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
        this.fuerza += 3;
        this.agilidad += 1;
        this.inteligencia += 1;
        this.aguante += 2;
        this.calculoExperiencia();
        this.calcularEsquiva();
        this.calcularVida();
        Debug.Log("Has subido al nivel " + this.nivel);
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager1>().setText("Has subido al nivel " + this.nivel);
    }

    //Metodo para realizar el ataque a un enemigo concreto
    public void realizarAtaque(Enemigo e){}//NO IMPLEMENTADO


    //Metodo para calcular el daño realizado de armas mas estadisticas
    public override int ataqueBasico()
    {
        System.Random r = new System.Random();
        if (r.Next(1, 20) >= 18)
        {
            //Golpe crítico
            return (this.manoDerecha.generarDaño() + (this.fuerza / 3)) * 2;
        }
        else
        {
            return this.manoDerecha.generarDaño() + (this.fuerza / 3);
        }
        //movimiento del enemigo hacia atras 15 metros --> Insertar codigo

    }

    public override float dañoReducido(float dañoInicial)
    {
        return dañoInicial - this.armaduraTotal/2;
    }

    //1a Habilidad
    public void furia()
    {
        if (this.nivel < 3) {
            Debug.Log("Esta habilidad se desbloquea al alcanzar el nivel 3");
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager1>().setText("Esta habilidad se desbloquea al alcanzar el nivel 3");
            return;
        }
        if (this.beerserkerActivo) {
            Debug.Log("El modo beerserker ya está activado");
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager1>().setText("El modo beerserker ya está activado (" + contadorB + "s)");
            return;
        }

        Debug.Log("El personaje ha entrado en modo berserker");
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager1>().setText("El personaje ha entrado en modo berserker");

        beerserkerActivo = true;
        this.armaduraTotal *= 2;
        this.fuerza *= 2;
        contadorB = 5;
        t = new Timer(Tick4, "", 0, 1000);
    }
    //2a Habilidad
    public void escudo()
    {
        Debug.Log("Habilidad no disponible aún");
    }
    //3a Habilidad
    public void torbellino()
    {
        Debug.Log("Habilidad no disponible aún");
    }
    //4a Habilidad
    public void berserker()
    {
        Debug.Log("Habilidad no disponible aún");
    }

    private void Tick4(object state)
    {
        contadorB--;
        if (contadorB <= 0)
        {
            finBerserker();
        }
    }
    private void finBerserker()
    {

        this.armaduraTotal /= 2;
        this.fuerza /= 2;
        beerserkerActivo = false;
        Debug.Log("El personaje ha vuelto a la normalidad");
        t.Dispose();
    }


    // TRATAMIENTO DE DATOS

    public void guardarGuerrero(string name)
    {
        string partida = JsonUtility.ToJson(this);
        string nombreFichero = "/Resources/partida" + name + ".json";
        File.WriteAllText(Application.dataPath + nombreFichero, partida);
    }

    public void cargarGuerrero(string nombre)
    {
        string nombreFichero = "/Resources/partida" + nombre + ".json";
        if (File.Exists(Application.dataPath + nombreFichero))
        {
            string datos = File.ReadAllText(Application.dataPath + nombreFichero);
            JsonUtility.FromJsonOverwrite(datos, this);
        }
    }

    public int equiparGuerrero(int id)
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

