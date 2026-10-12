using System;
using System.Collections.Generic;

class Program
{
    static int? EliminarPorIndice(List<int> lista, int indice)
    {
        if (indice >= 0 && indice < lista.Count)
        {
            int elemento = lista[indice];
            lista.RemoveAt(indice);
            return elemento;
        }
        return null;
    }

    static void Main()
    {
        List<int> datos = new List<int> { 102, 58, 14, 87, 93, 26, 41, 75 };
        int posicion = 3;

        Console.WriteLine("Lista original: " + string.Join(", ", datos));
        int? eliminado = EliminarPorIndice(datos, posicion);
        Console.WriteLine($"Elemento eliminado en el índice {posicion}: " + (eliminado.HasValue ? eliminado.ToString() : "None"));
        Console.WriteLine("Lista después de la eliminación: " + string.Join(", ", datos));
    }
}