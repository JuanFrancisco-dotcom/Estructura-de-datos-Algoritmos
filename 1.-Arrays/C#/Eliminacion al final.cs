using System;
using System.Collections.Generic;

class Program
{
    static int? EliminarAlFinal(List<int> lista)
    {
        if (lista.Count > 0)
        {
            int elemento = lista[lista.Count - 1];
            lista.RemoveAt(lista.Count - 1);
            return elemento;
        }
        return null;
    }

    static void Main()
    {
        List<int> datos = new List<int> { 36, 34, 43, 11, 15, 20, 28, 45 };

        Console.WriteLine("Lista original: " + string.Join(", ", datos));
        int? eliminado = EliminarAlFinal(datos);
        Console.WriteLine("Elemento eliminado: " + (eliminado.HasValue ? eliminado.ToString() : "None"));
        Console.WriteLine("Lista después de eliminar al final: " + string.Join(", ", datos));
    }
}