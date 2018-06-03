using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IPocion : Item {

    
    public string efectoString;
    public Efecto efecto;
    public int aumento;
    public bool acumulable;

    public IPocion(int id, double precio, Casilla c, string nombre, Rareza rareza,string nombreSprite) : base(id,precio,c,nombre,rareza, nombreSprite)
    {
    }

    public void generarEnumPocion()
    {
        switch (this.efectoString)
        {
            case "fuerza":
                this.efecto = Efecto.FUERZA;
                break;
            case "destreza":
                this.efecto = Efecto.DESTREZA;
                break;
            case "inteligencia":
                this.efecto = Efecto.INTELIGENCIA;
                break;
            case "vida":
                this.efecto = Efecto.VIDA;
                break;
        }
    }

    public void generarAumento()
    {
        if (efecto == Efecto.VIDA)
        {
            switch (rareza)
            {
                case Rareza.COMUN:
                    this.aumento = 20;
                    break;
                case Rareza.RARO:
                    this.aumento = 50;
                    break;
                case Rareza.EPICO:
                    this.aumento = 150;
                    break;

            }
        }
        else
        {
            switch (rareza)
            {
                case Rareza.COMUN:
                    this.aumento = 10;
                    break;
                case Rareza.RARO:
                    this.aumento = 25;
                    break;
                case Rareza.EPICO:
                    this.aumento = 50;
                    break;
            }
        }
    }

    public int usarPocion()
    {
        return this.aumento;
    }//metodo de usarpocion que retorno el aumento y luego se llame con el uso del boton


   
}
public enum Efecto
{
    FUERZA,
    DESTREZA,
    INTELIGENCIA,
    VIDA,
}

