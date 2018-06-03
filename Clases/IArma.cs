using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


[System.Serializable]

public class IArma : IEquipo
{
    public bool dosManos;
    public int danoMinimo;
    public int danoMaximo;
    public string estadoString;
    public EstadoPerjudicial estado = EstadoPerjudicial.NULO;
    //private int probEstado;
    public string familiaString;
    public FamiliaArma familia = FamiliaArma.NULO;
    public int armadura;

    public void generarEnumArma()
    {
        switch (this.estadoString)
        {
            case "quemado":
                this.estado = EstadoPerjudicial.QUEMADO;
                break;
            case "envenenado":
                this.estado = EstadoPerjudicial.ENVENENADO;
                break;
            case "paralizado":
                this.estado = EstadoPerjudicial.PARALIZADO;
                break;
            
        }

        switch (this.familiaString)
        {
            case "espada":
                this.familia = FamiliaArma.ESPADA;
                break;
            case "espadon":
                this.familia = FamiliaArma.ESPADON;
                break;
            case "arco":
                this.familia = FamiliaArma.ARCO;
                break;
            case "ballesta":
                this.familia = FamiliaArma.BALLESTA;
                break;
            case "varita":
                this.familia = FamiliaArma.VARITA;
                break;
            case "baston":
                this.familia = FamiliaArma.BASTON;
                break;
            case "escudo":
                this.familia = FamiliaArma.ESCUDO;
                break;
        }

    }

    public IArma(int id, double precio, Casilla c, String nombre, Rareza rareza,string nombreSprite, int bonificador, FamiliaArma familia, int danoMinimo, int danoMaximo) : base(id, precio, c, nombre, rareza, nombreSprite, bonificador)
    {
        this.danoMinimo = danoMinimo;
        this.danoMaximo = danoMaximo;
        this.familia = familia;
        this.dosManos = numManos(familia);

        crearEstado();

    }

    public FamiliaArma Familia
    {
        get { return this.familia; }
    }

    private bool numManos(FamiliaArma f)
    {
        bool retorno = false;
        switch (f)
        {
            case FamiliaArma.ESPADA:
                retorno = false;
                break;
            case FamiliaArma.ESPADON:
                retorno = true;
                break;
            case FamiliaArma.ARCO:
                retorno = true;
                break;
            case FamiliaArma.BALLESTA:
                retorno = true;
                break;
            case FamiliaArma.BASTON:
                retorno = true;
                break;
            case FamiliaArma.VARITA:
                retorno = false;
                break;
            case FamiliaArma.ESCUDO:
                retorno = false;
                break;
        }
        return retorno;
    }

    public bool DosManos()
    {
        return this.dosManos;
    }

    public int generarDaño()
    {
        Random r = new Random();
        return r.Next(this.danoMinimo, this.danoMaximo) + this.bonificador;
    }
    /*
    public int Armadura
    {
        get { return this.Armadura; }
set { this.armadura = value; }
    }*/
    

    public void crearEstado()
    {
        Random r = new Random();
        switch (this.rareza)
        {

            case Rareza.COMUN:
                this.estado = EstadoPerjudicial.NULO;
                break;
            case Rareza.RARO:
                if (r.Next(1, 100) <= 15)
                {
                    this.estado = elegirEstado();
                }
                break;
            case Rareza.EPICO:
                if (r.Next(1, 100) <= 30)
                {
                    this.estado = elegirEstado();
                }
                break;
            case Rareza.LEGENDARIO:
                if (r.Next(1, 100) <= 45)
                {
                    this.estado = elegirEstado();
                }
                break;
        }
        r = null;
    }

    private EstadoPerjudicial elegirEstado()
    {
        Random r1 = new Random();
        EstadoPerjudicial e = EstadoPerjudicial.NULO;
        switch (r1.Next(1, 3))
        {

            case 1:
                e = EstadoPerjudicial.QUEMADO;
                break;
            case 2:
                e = EstadoPerjudicial.ENVENENADO;
                break;
            case 3:
                e = EstadoPerjudicial.PARALIZADO;
                break;
        }
        r1 = null;
        return e;
    }

}



public enum FamiliaArma
{
    ESPADA,
    ESPADON,
    ARCO,
    BALLESTA,
    BASTON,
    VARITA,
    ESCUDO,
    NULO,
}

public enum EstadoPerjudicial
{
    QUEMADO,
    ENVENENADO,
    PARALIZADO,
    NULO,
}

