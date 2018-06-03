using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


[System.Serializable]
public class IArmadura:IEquipo
    {
        public int durabilidad;
        public int durabilidadMaxima;
        public int armadura;
        public bool roto;

        public IArmadura(int id,double precio, Casilla c, String nombre, Rareza rareza,string nombreSprite, int bonificador, int durabilidad, int armadura) : base(id, precio, c,nombre, rareza, nombreSprite, bonificador)
        {
            this.durabilidad = durabilidad;
            this.durabilidadMaxima = durabilidad;
            this.armadura = armadura + this.bonificador;
            this.roto = false;
        }

        public void romper()
        {
            roto = true;
        }

        public void reparar()
        {
            roto = false;
        }

        public void desgastar(int puntos)
        {
            this.durabilidad -= puntos;
            if (this.durabilidad <= 0)
            {
                this.durabilidad = 0;
                romper();
            }
        }

        public void arreglar(int puntos)
        {
            this.durabilidad += puntos;

            if (this.durabilidad > 0 && this.roto == true)
            {
                reparar();
            }

            if (this.durabilidad > this.durabilidadMaxima)
            {
                this.durabilidad = this.durabilidadMaxima;
            }
        }

        public int Armadura
        {
            get { return this.armadura; }
            set { this.armadura = value; }
        }
    }

