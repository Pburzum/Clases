using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


[System.Serializable]
public class IEquipo : Item
{
    
    public int bonificador;

    public IEquipo(int id, double precio, Casilla c, String nombre, Rareza rareza,string nombreSprite, int bonificador) : base(id, precio, c, nombre, rareza, nombreSprite)
    {
        
        this.bonificador = bonificador;
    }
    
    public int getBonificador()
    {
        return this.bonificador;
    }
    
}


public enum Rareza
{
    COMUN,
    RARO,
    EPICO,
    LEGENDARIO,
}

