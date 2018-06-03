using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DropObject
{

    static System.Random dado = new System.Random();
    static List<int> listaComunes = new List<int>() { 1, 5, 9, 13, 17, 21, 96, 97, 98, 99 };
    static List<int> listaRaros = new List<int>() { 2, 6, 10, 14, 18, 22 };
    static List<int> listaEpicos = new List<int>() { 3, 7, 11, 15, 19, 23 };
    static List<int> listaLegendarios = new List<int>() { 4,8, 12, 16, 20, 24 };
    static List<int> listaArmComunes = new List<int>() { 201 };
    static List<int> listaArmRaros = new List<int>() { 202 };
    static List<int> listaArmEpicos = new List<int>() { 203 };
    static List<int> listaArmLegendarios = new List<int>() { 204 };

    public static int dropItem(Categoria cat)
    {
        int retorno = 0;

        int resultado = lanzarDado();
        Debug.Log("Primer dado" +resultado);
        switch (cat)
        {
            case Categoria.BAJA:
                if (resultado <= 20)
                {
                    retorno = generarItem(cat);
                }
                else
                {
                    retorno = 0;
                }
                break;
            case Categoria.MEDIA:
                if (resultado <= 30)
                {
                    retorno = generarItem(cat);
                }
                else
                {
                    retorno = 0;
                }
                break;
            case Categoria.ALTA:
                if (resultado <= 50)
                {
                    retorno = generarItem(cat);
                }
                else
                {
                    retorno = 0;
                }
                break;
            case Categoria.ELITE:
                if (resultado <= 75)
                {
                    retorno = generarItem(cat);
                }
                else
                {
                    retorno = 0;
                }
                break;

            case Categoria.JEFE:

                retorno = generarItem(cat);

                break;
        }
        return retorno;
    }

    static int lanzarDado()
    {
        return dado.Next(0, 100);
    }

    static int generarItem(Categoria cat)
    {
        int retorno = 0;
        int resultado = lanzarDado();
        Debug.Log("Segundo dado" +resultado);
        if (resultado <= 100) // -->Cambiar!
        {
            retorno= generarArma(cat);
        }
        else
        {
            retorno = generarArmadura(cat);
        }
        return retorno;
    }

    static int generarArma(Categoria cat)
    {
        int opcion=0;
        int arma = 0;
        int resultado = lanzarDado();
        Debug.Log("tercer dado"+resultado);
        switch (cat)
        {
            case Categoria.BAJA:

                if (resultado <= 80)
                {
                    opcion = dado.Next(0, listaComunes.Count - 1);
                    arma = listaComunes[opcion];
                }
                else
                {
                    opcion = dado.Next(0, listaRaros.Count - 1);
                    arma = listaRaros[opcion];
                }
                break;
            case Categoria.MEDIA:
                if (resultado <= 60)
                {
                    opcion = dado.Next(0, listaComunes.Count - 1);
                    arma = listaComunes[opcion];
                }
                else if (resultado > 60 && resultado <= 90)
                {
                    opcion = dado.Next(0, listaRaros.Count - 1);
                    arma = listaRaros[opcion];
                }
                else
                {
                    opcion = dado.Next(0, listaEpicos.Count - 1);
                    arma = listaRaros[opcion];
                }
                break;
            case Categoria.ALTA:
                if (resultado <= 40)
                {
                    arma = listaComunes[dado.Next(0, listaComunes.Count - 1)];
                }
                else if (resultado > 40 && resultado <= 80)
                {
                    arma = listaRaros[dado.Next(0, listaRaros.Count - 1)];
                }
                else
                {
                    arma = listaEpicos[dado.Next(0, listaEpicos.Count - 1)];
                }
                break;
            case Categoria.ELITE:
                if (resultado <= 20)
                {
                    arma = listaRaros[dado.Next(0, listaRaros.Count - 1)];
                }
                else if (resultado > 20 && resultado < 90)
                {
                    arma = listaEpicos[dado.Next(0, listaEpicos.Count - 1)];
                }
                else
                {
                    arma = listaLegendarios[dado.Next(0, listaLegendarios.Count - 1)];
                }
                break;
            case Categoria.JEFE:
                opcion = dado.Next(0, listaLegendarios.Count - 1);
                Debug.Log("lista " + opcion);
                arma = (listaLegendarios[opcion]);
                
                Debug.Log("arma "+arma);
                break;

        }
        Debug.Log("lista " + opcion);
        Debug.Log("arma " + arma);
        return arma;
        
    }

    static int generarArmadura(Categoria cat)
    {
        int armadura = 0;
        int resultado = lanzarDado();
        Debug.Log("tercer dado" + resultado);
        switch (cat)
        {
            case Categoria.BAJA:
                if (resultado <= 80)
                {
                    armadura = listaComunes[dado.Next(0, listaComunes.Count - 1)];
                }
                else
                {
                    armadura = listaRaros[dado.Next(0, listaRaros.Count - 1)];
                }
                break;
            case Categoria.MEDIA:
                if (resultado <= 60)
                {
                    armadura = listaComunes[dado.Next(0, listaComunes.Count - 1)];
                }
                else if (resultado > 60 && resultado <= 90)
                {
                    armadura = listaRaros[dado.Next(0, listaRaros.Count - 1)];
                }
                else
                {
                    armadura = listaEpicos[dado.Next(0, listaEpicos.Count - 1)];
                }
                break;
            case Categoria.ALTA:
                if (resultado <= 40)
                {
                    armadura = listaComunes[dado.Next(0, listaComunes.Count - 1)];
                }
                else if (resultado > 40 && resultado <= 80)
                {
                    armadura = listaRaros[dado.Next(0, listaRaros.Count - 1)];
                }
                else
                {
                    armadura = listaEpicos[dado.Next(0, listaEpicos.Count - 1)];
                }
                break;
            case Categoria.ELITE:
                if (resultado <= 20)
                {
                    armadura = listaRaros[dado.Next(0, listaRaros.Count - 1)];
                }
                else if (resultado > 20 && resultado < 90)
                {
                    armadura = listaEpicos[dado.Next(0, listaEpicos.Count - 1)];
                }
                else
                {
                    armadura = listaLegendarios[dado.Next(0, listaLegendarios.Count - 1)];
                }
                break;
            case Categoria.JEFE:
                int opcion = dado.Next(0, listaLegendarios.Count - 1);
                Debug.Log("lista " + opcion);
                armadura = (listaLegendarios[opcion]);

                Debug.Log("arma " + armadura);
                break;

        }
        
        Debug.Log("arma " + armadura);
        return armadura;
    }
}
