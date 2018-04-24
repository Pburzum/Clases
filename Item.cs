using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Consola
{
    class Item
    {
        protected String nombre;
        protected double precio { get; set; }
        protected Casilla casilla { get; set; }
        //Constructor
        public Item(double precio, Casilla c,String nombre)
        {
            this.precio = precio;
            this.casilla = c;
            this.nombre = nombre;
        }
        //Propiedades son los getter y setter de Java
        public Casilla Casilla
        {
            get { return this.casilla; }
            set { this.casilla = value; }
        }
        public double Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }

    }
}
