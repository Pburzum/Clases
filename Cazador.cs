using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Consola
{
    class Cazador:Heroe
    {
        private int velocidad;
        public Cazador()
        {
            this.fuerza = 7;
            this.agilidad = 12;
            this.inteligencia = 8;
            this.aguante = 8;
            this.armaduraBase = 2;
            this.nivel = 1;
            this.expActual = 0;
            this.velocidad = 10;
            this.cabeza = new IArmadura(1,Casilla.CABEZA,"Sombrero",Rareza.COMUN,0,100,1);
            this.pecho = new IArmadura(1, Casilla.PECHO, "Jubón de cuero", Rareza.COMUN, 0, 100, 1);
            this.piernas = new IArmadura(1, Casilla.PIERNAS, "Pantalón de cuero", Rareza.COMUN, 0, 100, 1); 
            this.pies = new IArmadura(1, Casilla.PIES, "Chanclas", Rareza.COMUN, 0, 100, 1); ;
            this.manoIzquierda = null;
            this.manoDerecha = new IArma(5,Casilla.MANO_DERECHA,"Arco Cutre",Rareza.COMUN,0,FamiliaArma.ARCO,2,4);
            if (this.manoDerecha.DosManos())
            {
                this.dosManos = true;
            }
            calcularVida();
            calcularArmadura();
            calcularEsquiva();
        }

        public Cazador(int fuerza, int agilidad, int inteligencia, int aguante, int armaduraBase, int nivel, int expActual,
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
            if(r.Next(1,20) == 20)
            {
                //Golpe crítico
                return (this.manoDerecha.generarDaño() + (this.agilidad / 3))*2;
            }else
            {
                return this.manoDerecha.generarDaño() + (this.agilidad / 3);
            }
            

        }
        //1a Habilidad
        public void repeler(Enemigo e)
        {
            if (!e.esquivarAtaque())
            {
                e.reducirDaño(15 * (this.agilidad / 4));
                //movimiento del enemigo hacia atras 15 metros
            }
        }
        //2a Habilidad
        public void disparoRapido(Enemigo e)
        {
            for(int i = 0; i < 4; i++)
            {
                realizarAtaque(e);
            }
        }
        //3a Habilidad
        public void sprint()
        {
            this.velocidad += agilidad / 3;
        }
        //4a Habilidad
        public void disparoMortal(Enemigo e)
        {
            if (!e.esquivarAtaque())
            {
                if(e.Vida < e.Vida * 0.3)
                {
                    //destroy
                }else
                {
                    Random r = new Random();
                    e.reducirDaño(r.Next(200, 400) + (this.agilidad * 20));
                }
            }
        }


    }
}
