using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Consola
{
    class IArma:IEquipo
    {
        private bool dosManos;
        private int dañoMinimo;
        private int dañoMaximo;
        private EstadoPerjudicial estado;
        private int probEstado;
        private FamiliaArma familia;
        private int armadura;

        public IArma(double precio, Casilla c, String nombre, Rareza rareza, int bonificador, FamiliaArma familia, int dañoMinimo, int dañoMaximo) : base(precio, c,nombre, rareza, bonificador)
        {
            this.dañoMinimo = dañoMinimo;
            this.dañoMaximo = dañoMaximo;
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
            return r.Next(this.dañoMinimo, this.dañoMaximo) + this.bonificador;
        }

        public int Armadura
        {
            get { return this.Armadura; }
            set { this.armadura = value; }
        }

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
}

enum FamiliaArma
{
    ESPADA,
    ESPADON,
    ARCO,
    BALLESTA,
    BASTON,
    VARITA,
    ESCUDO,
}

enum EstadoPerjudicial
{
    QUEMADO,
    ENVENENADO,
    PARALIZADO,
    NULO,
}

