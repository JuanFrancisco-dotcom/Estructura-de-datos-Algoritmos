using System;
using System.Collections.Generic;

class Program
{
    static int BusquedaSecuencial(List<int> lista, int elementoBuscado)
    {
        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i] == elementoBuscado)
                return i;
        }
        return -1;
    }

    static void Main()
    {
        List<int> datos = new List<int> { 36, 34, 43, 11, 15, 20, 28, 45 };
        int objetivo = 20;

        int posicion = BusquedaSecuencial(datos, objetivo);

        if (posicion != -1)
            Console.WriteLine($"El elemento {objetivo} se encontró en el índice {posicion}.");
        else
            Console.WriteLine($"El elemento {objetivo} no se encuentra en la lista.");
    }
}