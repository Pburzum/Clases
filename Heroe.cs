using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Consola
{
    class Heroe
    {
        protected int fuerza;
        protected int agilidad;
        protected int inteligencia;
        protected int aguante;
        protected int armaduraTotal;
        protected int armaduraBase;
        protected int esquiva;
        protected int nivel;
        protected int expNivel;
        protected int expActual;
        protected int vidaActual;
        protected int vidaMaxima;
        protected bool nivelSubido;
        protected bool dosManos;
        public Inventario mochila;
        /// <summary>
        /// Atributos correspodientes al equipamiento del personaje
        /// </summary>

        protected IArmadura cabeza;
        protected IArmadura pecho;
        protected IArmadura piernas;
        protected IArmadura pies;
        protected IArma manoIzquierda;
        protected IArma manoDerecha;
        //public IArmadura pocion;
        // Para generar un inventario dentro de la clase podemos generar un clase generica de inventario que será un almacen de items.

        
        public Heroe()
        {
            //Constructor para crear un personaje nuevo que se implementará en las clases hijas
        }

        //Constructor para crear el personaje desde un archivo de guardado o base de datos
        public Heroe(int fuerza, int agilidad, int inteligencia, int aguante, int armaduraBase,int nivel,int expActual,
            IArmadura cabeza, IArmadura pecho, IArmadura piernas, IArmadura pies,IArma manoIzquierda, IArma manoDerecha)
        {
            this.mochila = new Inventario();
            this.fuerza = fuerza;
            this.agilidad = agilidad;
            this.inteligencia = inteligencia;
            this.aguante = aguante;
            this.armaduraBase = armaduraBase;
            this.nivel = nivel;
            this.expActual = expActual;
            this.cabeza = cabeza;
            this.pecho = pecho;
            this.piernas = piernas;
            this.pies = pies;
            this.manoIzquierda = manoIzquierda;
            this.manoDerecha = manoDerecha;
            if (this.manoDerecha.DosManos())
            {
                this.dosManos = true;
            }
            calcularVida();
            calcularArmadura();
            calcularEsquiva();
            

        }
        //----Propiedades de los atributos , Setter/Getter en Otros lenguajes----
        public int Fuerza
        {
            get { return fuerza; }
            set { fuerza = value; }
        }
        public int Agilidad
        {
            get { return agilidad; }
            set { agilidad = value; }
        }
        public int Inteligencia
        {
            get { return inteligencia; }
            set { inteligencia = value; }
        }
        public int Aguante
        {
            get { return aguante; }
            set { aguante = value; }
        }
        public int ArmaduraTotal
        {
            get { return armaduraTotal; }
            set { armaduraTotal = value; }
        }
        public int Esquiva
        {
            get { return esquiva; }
            set { esquiva = value; }
        }
        public int Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }
        public int ExpNivel
        {
            get { return expNivel; }
            set { expNivel = value; }
        }
        public int ExpActual
        {
            get { return expActual; }
            set { expActual += value;
                if (expActual >= expNivel)
                {
                    nivelSubido = true;
                }
            }
        }

        //--Metodos de clase a nivel de acciones

        //--Metodos para equipar armaduras y armas
        public IArmadura cambioArmadura(IArmadura original, IArmadura nuevo)
        {
            if (original.Casilla == nuevo.Casilla)
            {
                IArmadura viejo = original;
                original = nuevo;
                equiparArmadura(original);
                return viejo;
            }
            else
            {
                //Mensaje de error de ranura
                return nuevo;
            }

        }
         
        public void equiparArmadura(IArmadura objeto)
        {
            switch (objeto.Casilla)
            {
                case Casilla.CABEZA:
                    this.cabeza = objeto;
                    break;
                case Casilla.PECHO:
                    this.pecho = objeto;
                    break;
                case Casilla.PIERNAS:
                    this.piernas = objeto;
                    break;
                case Casilla.PIES:
                    this.pies = objeto;
                    break;
            }
        }

        public IArma cambioArma(IArma original, IArma nuevo)
        {
            if (original.Casilla == nuevo.Casilla)
            {
                IArma viejo = original;
                original = nuevo;
                equiparArma(original);
                return viejo;
            }
            else
            {
                //Mensaje de error de ranura
                return nuevo;
            }

        }

        public void equiparArma(IArma objeto)
        {
            switch (objeto.Casilla)
            {
                
                case Casilla.MANO_IZQUIERDA:
                    if (!dosManos) { this.manoIzquierda = objeto; }
                    else { }
                    break;
                case Casilla.MANO_DERECHA:
                    this.manoDerecha = objeto;
                    break;
                case Casilla.DOS_MANOS:
                    this.manoDerecha = objeto;
                    this.dosManos = true;
                    break;
                case Casilla.POCION:
                    //this.pocion = objeto;
                    break;
            }
        }
        public virtual int ataqueBasico()
        {
            return 0;
        }

        public void calcularVida()
        {
            this.vidaMaxima = this.aguante * 10;
            this.vidaActual = this.vidaMaxima;
        }

        public void calcularArmadura()
        {
            this.armaduraTotal = this.armaduraBase + this.cabeza.Armadura
                + this.pecho.Armadura + this.piernas.Armadura + this.pies.Armadura;
            if(this.manoIzquierda.Familia == FamiliaArma.ESCUDO)
            {
                this.armaduraTotal += manoIzquierda.Armadura;
            }else if(this.manoDerecha.Familia == FamiliaArma.ESCUDO)
            {
                this.armaduraTotal += manoDerecha.Armadura;
            }
        }

        public virtual void calcularEsquiva()
        {
            this.esquiva = this.agilidad + this.inteligencia;
        }
        //Nota parche 17/04 añadidos metodos de esquiva y reduccion
        public bool esquivarAtaque()
        {
            Random r = new Random();
            int hit = r.Next(0, 100);
            if (hit > this.esquiva)
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
            this.vidaActual -= (dañoInicial - this.armaduraTotal);
        }

        //Nota Parche 23/04 Añadido el inventario
        public void recogerObjeto(Item i)
        {
            mochila.añadir(i);
        }

        public void soltarObjeto(int casilla)
        {
            mochila.destruir(casilla);
        }

        public void intecambiarItem(Item iViejo, Item iNuevo)
        {
            mochila.intercambiar(ref iViejo,ref iNuevo);
        }
    }   
    
    enum Casilla
    {
        CABEZA,
        PECHO,
        PIERNAS,
        PIES,
        MANO_IZQUIERDA,
        MANO_DERECHA,
        DOS_MANOS,
        POCION,
    }
}



