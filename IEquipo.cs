using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Consola
{
    class IEquipo:Item
    {
        protected Rareza rareza;
        protected int bonificador;

        public IEquipo(double precio, Casilla c, String nombre, Rareza rareza, int bonificador) : base(precio, c,nombre)
        {
            this.rareza = rareza;
            this.bonificador = bonificador;
        }

        public Rareza getRareza()
        {
            return this.rareza;
        }

        public int getBonificador()
        {
            return this.bonificador;
        }
    }
}

enum Rareza
{
    COMUN,
    RARO,
    EPICO,
    LEGENDARIO,
}

