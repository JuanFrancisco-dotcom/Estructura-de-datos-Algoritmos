using System;
using System.Collections.Generic;

class Program
{
    static int? EliminarAlInicio(List<int> lista)
    {
        if (lista.Count > 0)
        {
            int elemento = lista[0];
            lista.RemoveAt(0);
            return elemento;
        }
        return null;
    }

    static void Main()
    {
        List<int> datos = new List<int> { 36, 34, 43, 11, 15, 20, 28, 45 };

        Console.WriteLine("Lista original: " + string.Join(", ", datos));
        int? eliminado = EliminarAlInicio(datos);
        Console.WriteLine("Elemento eliminado: " + (eliminado.HasValue ? eliminado.ToString() : "None"));
        Console.WriteLine("Lista después de eliminar al inicio: " + string.Join(", ", datos));
    }
}