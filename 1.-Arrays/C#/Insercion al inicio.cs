using System;
using System.Collections.Generic;

class Program
{
    static void InsertarAlInicio(List<int> lista, int nuevoElemento)
    {
        lista.Insert(0, nuevoElemento);
    }

    static void Main()
    {
        List<int> datos = new List<int> { 36, 34, 43, 11, 15, 20, 28, 45 };
        int nuevo = 99;

        Console.WriteLine("Lista original: " + string.Join(", ", datos));
        InsertarAlInicio(datos, nuevo);
        Console.WriteLine("Lista con inserción al inicio: " + string.Join(", ", datos));
    }
}