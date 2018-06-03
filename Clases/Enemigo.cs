using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Enemigo
{
    public int ataqueMinimo;
    public int ataqueMaximo;
    public int vida;
    public int armadura;
    public int esquiva;
    public int velocidad;

    public int Vida
    {
        get { return this.vida; }
        set { this.vida = value; }
    }

    public int Armadura
    {
        get { return this.armadura; }
        set { this.armadura = value; }
    }

    //public void realizarAtaque(Heroe h)
    //{
    //    if (!h.esquivarAtaque())
    //    {
    //        Random r = new Random();
    //        h.reducirDaño(r.Next(this.ataqueMinimo, this.ataqueMaximo));
    //    }
    //}

    public bool esquivarAtaque()
    {
        Random r = new Random();
        int hit = r.Next(0, 100);
        if (hit > esquiva)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void reducirDaño(int dañoInicial)
    {
        Vida -= (dañoInicial - this.armadura);
    }
}

