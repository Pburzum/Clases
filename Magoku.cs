using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Consola
{
    class Magoku:Heroe
    {
        private int velocidad;
        public Magoku()
        {
            this.fuerza = 6;
            this.agilidad = 8;
            this.inteligencia = 14;
            this.aguante = 7;
            this.armaduraBase = 1;
            this.nivel = 1;
            this.expActual = 0;
            this.velocidad = 10;
            this.cabeza = new IArmadura(1, Casilla.CABEZA, "Sombrero de paja", Rareza.COMUN, 0, 100, 1);
            this.pecho = new IArmadura(1, Casilla.PECHO, "Tunica de tela", Rareza.COMUN, 0, 100, 1);
            this.piernas = new IArmadura(1, Casilla.PIERNAS, "Pantalones de tela", Rareza.COMUN, 0, 100, 1);
            this.pies = new IArmadura(1, Casilla.PIES, "Chanclas", Rareza.COMUN, 0, 100, 3); ;
            this.manoIzquierda = null;
            this.manoDerecha = new IArma(5, Casilla.MANO_DERECHA, "Baston de madera", Rareza.COMUN, 0, FamiliaArma.BASTON, 2, 4);
            if (this.manoDerecha.DosManos())
            {
                this.dosManos = true;
            }
            calcularVida();
            calcularArmadura();
            calcularEsquiva();
        }

        public Magoku(int fuerza, int agilidad, int inteligencia, int aguante, int armaduraBase, int nivel, int expActual,
            IArmadura cabeza, IArmadura pecho, IArmadura piernas, IArmadura pies, IArma manoIzquierda, IArma manoDerecha):base(
                fuerza,agilidad,inteligencia,aguante,armaduraBase,nivel,expActual,cabeza,pecho,piernas,pies,manoIzquierda,manoDerecha)
        {
            this.velocidad = 10;
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
        //Metodo para realizar el ataque a un enemigo concreto
        public void realizarAtaque(Enemigo e)
        {
            if (!e.esquivarAtaque())
            {
                e.reducirDaño(this.ataqueBasico());
            }
        }
        //Metodo para calcular el daño realizado de armas mas estadisticas
        public override int ataqueBasico()
        {
            Random r = new Random();
            if (r.Next(1, 20) >= 20)
            {
                //Golpe crítico
                return (this.manoDerecha.generarDaño() + (this.inteligencia / 2)) * 2;
            }
            else
            {
                return this.manoDerecha.generarDaño() + (this.inteligencia / 2);
            }
            //movimiento del enemigo hacia atras 15 metros --> Insertar codigo

        }
        //1a Habilidad
        public void repeler(Enemigo e)
        {
            if (!e.esquivarAtaque())
            {
                e.reducirDaño(15 * (this.inteligencia / 4));
                //movimiento del enemigo hacia atras 15 metros
            }
        }
        //2a Habilidad
        public void bolaEnergia(Enemigo e)
        {
            if (!e.esquivarAtaque())
            {
                e.reducirDaño(15 * (this.inteligencia / 2)*2);
                //movimiento del enemigo hacia atras 15 metros
            }
        }
        //3a Habilidad
        public void lluviaTruenos(Queue<Enemigo> listadoEnemigos)
        {
            foreach (Enemigo e in listadoEnemigos)
            {
                e.reducirDaño(this.ataqueBasico()/2);
                //implementar estado en enemigos, y paralizarlos.
            }
        }
        //4a Habilidad
        public void superSaiyan()
        {
            this.aguante *= 4;
            this.inteligencia *= 2;
            //paso de un tiempo por hilo
            this.aguante /= 4;
            this.inteligencia /= 2;
        }
    }
}
