using System;

class OrdenPorFilasDeMatriz2D
{
    static void OrdenarPorFilas(int[][] matriz)
    {
        for (int i = 0; i < matriz.Length; i++)
        {
            Array.Sort(matriz[i]);
        }
    }

    static void ImprimirFila(int[] fila)
    {
        Console.WriteLine("[" + string.Join(", ", fila) + "]");
    }

    static void Main()
    {
        int[][] matriz2d = new int[][]
        {
            new int[] { 78, 12, 45 },
            new int[] { 89, 23, 34 },
            new int[] { 67, 11, 90 }
        };

        Console.WriteLine("Matriz original:");
        foreach (int[] fila in matriz2d) ImprimirFila(fila);

        OrdenarPorFilas(matriz2d);

        Console.WriteLine("\nMatriz con cada fila ordenada:");
        foreach (int[] fila in matriz2d) ImprimirFila(fila);
    }
}
