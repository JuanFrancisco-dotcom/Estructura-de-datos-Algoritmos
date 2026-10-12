using System;
using System.Collections.Generic;

class Program
{
    static int BusquedaBinaria(List<int> lista, int elementoBuscado)
    {
        int inicio = 0;
        int fin = lista.Count - 1;

        while (inicio <= fin)
        {
            int medio = (inicio + fin) / 2;

            if (lista[medio] == elementoBuscado)
                return medio;
            else if (lista[medio] < elementoBuscado)
                inicio = medio + 1;
            else
                fin = medio - 1;
        }

        return -1;
    }

    static void Main()
    {
        List<int> datos = new List<int> { 14, 26, 41, 58, 75, 87, 93, 102 };
        int objetivo = 87;

        int posicion = BusquedaBinaria(datos, objetivo);

        if (posicion != -1)
            Console.WriteLine($"El elemento {objetivo} se encontró en el índice {posicion}.");
        else
            Console.WriteLine($"El elemento {objetivo} no se encuentra en la lista.");
    }
}