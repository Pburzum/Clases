using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Consola
{
    class Inventario
    {
        Dictionary<int, Item> mochila;
        public Inventario()
        {
            mochila = new Dictionary<int, Item>();
        }

        public void añadir(Item nuevo)
        {
            int ultimoIndice=0;
            if (!mochila.ContainsKey(0))
            {
                mochila.Add(0, nuevo);
            } else {

                foreach (int i in this.mochila.Keys)
                {
                    ultimoIndice = i;
                }
                if (ultimoIndice + 1 > 21)
                {
                    //inventario lleno
                }
                else
                {
                    mochila.Add(ultimoIndice + 1, nuevo);
                }
                
            }
                
        }
        public void intercambiar(ref Item a, ref Item b)
        {
            //metodo para intercambiar los objetos del 
            Item temp = a;
            a = b;
            b = temp;
        }

        public void destruir(int posicion)
        {
            mochila.Remove(posicion);
            //aqui destruimos el objeto
        }
    }
}
