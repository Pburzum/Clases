using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

[Serializable]
public class Cazador : Heroe
{
    public int velocidad;
    public Cazador()
    {
        /*
        this.fuerza = 7;
        this.agilidad = 12;
        this.inteligencia = 8;
        this.aguante = 8;
        this.armaduraBase = 2;
        this.nivel = 1;
        this.expActual = 0;
        this.velocidad = 10;
        this.cabeza = new IArmadura(999, 0, Casilla.CABEZA, "Sombrero", Rareza.COMUN,"cabeza", 0, 100, 1);
        this.pecho = new IArmadura(1000, 0, Casilla.PECHO, "Jubón de cuero", Rareza.COMUN,"pecho", 0, 100, 1);
        this.piernas = new IArmadura(1001, 0, Casilla.PIERNAS, "Pantalón de cuero", Rareza.COMUN,"piernas", 0, 100, 1);
        this.pies = new IArmadura(1002, 0, Casilla.PIES, "Chanclas", Rareza.COMUN,"pies", 0, 100, 1); ;
        this.manoIzquierda = null;
        this.manoDerecha = new IArma(1014, 0, Casilla.MANO_DERECHA, "Arco Cutre", Rareza.COMUN,"arco", 0, FamiliaArma.ARCO, 2, 4);
        if (this.manoDerecha.DosManos())
        {
            this.dosManos = true;
        }
        calcularVida();
        calcularArmadura();
        calcularEsquiva();
        */
    }

    public Cazador(int fuerza, int agilidad, int inteligencia, int aguante, int armaduraBase, int nivel, int expActual,
        IArmadura cabeza, IArmadura pecho, IArmadura piernas, IArmadura pies, IArma manoIzquierda, IArma manoDerecha) : base(
            fuerza, agilidad, inteligencia, aguante, armaduraBase, nivel, expActual, cabeza, pecho, piernas, pies, manoIzquierda, manoDerecha)
    {
        this.velocidad = 10;
        calcularVida();
        calcularArmadura();
        calcularEsquiva();
    }

    public void crearCazador()
    {

        this.fuerza = 7;
        this.agilidad = 12;
        this.inteligencia = 8;
        this.aguante = 8;
        this.armaduraBase = 2;
        this.nivel = 1;
        this.expActual = 0;
        this.velocidad = 10;
        this.cabeza = new IArmadura(280, 0, Casilla.CABEZA, "Sombrero", Rareza.COMUN, "cabeza", 0, 100, 1);
        this.pecho = new IArmadura(281, 0, Casilla.PECHO, "Jubón de cuero", Rareza.COMUN, "pecho", 0, 100, 1);
        this.piernas = new IArmadura(282, 0, Casilla.PIERNAS, "Pantalón de cuero", Rareza.COMUN, "piernas", 0, 100, 1);
        this.pies = new IArmadura(283, 0, Casilla.PIES, "Chanclas", Rareza.COMUN, "pies", 0, 100, 1); ;
        this.manoIzquierda = null;
        this.manoDerecha = new IArma(95, 0, Casilla.MANO_DERECHA, "Arco Cutre", Rareza.COMUN, "arco", 0, FamiliaArma.ARCO, 2, 4);
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
        this.agilidad += 3;
        this.inteligencia += 1;
        this.aguante += 2;
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
        if (r.Next(1, 20) == 20)
        {
            //Golpe crítico
            return (this.manoDerecha.generarDaño() + (this.agilidad / 3)) * 2;
        }
        else
        {
            return this.manoDerecha.generarDaño() + (this.agilidad / 3);
        }


    }

    public override float dañoReducido(float dañoInicial)
    {
        return dañoInicial - this.armaduraTotal/2;
    }

    //1a Habilidad
    public void cuchillada()
    {
        if (this.nivel < 3)
        {
            Debug.Log("Esta habilidad se desbloquea al alcanzar el nivel 3");
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager1>().setText("Esta habilidad se desbloquea al alcanzar el nivel 3");
            return;
        }

        Debug.Log("Cuchillada cargada");
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager1>().setText("Cuchillada cargada");
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().habilidadCazador = true;
    }
    //2a Habilidad
    public void disparoRapido()
    {
        Debug.Log("Habilidad no disponible aún");
    }
    //3a Habilidad
    public void sprint()
    {
        Debug.Log("Habilidad no disponible aún");
    }
    //4a Habilidad
    public void disparoMortal()
    {
        Debug.Log("Habilidad no disponible aún");
    }

    //tratamiento de datos
    public void guardarCazador(string name)
    {
        string partida = JsonUtility.ToJson(this);
        string nombreFichero = "/Resources/partida" + name + ".json";
        File.WriteAllText(Application.dataPath + nombreFichero, partida);
    }

    public void cargarCazador(string nombre)
    {
        string nombreFichero = "/Resources/partida" + nombre + ".json";
        if (File.Exists(Application.dataPath + nombreFichero))
        {
            string datos = File.ReadAllText(Application.dataPath + nombreFichero);
            JsonUtility.FromJsonOverwrite(datos, this);
        }
    }

    //Equipar Objetos

    public int equiparCazador(int id)
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
        this.calcularArmadura();
        idAnt = antiguoItem.id;
        return idAnt;
    }

}
