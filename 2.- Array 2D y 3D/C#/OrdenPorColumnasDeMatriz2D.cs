using System;

class OrdenPorColumnasDeMatriz2D
{
    static void OrdenarPorColumnas(int[][] matriz)
    {
        int filas = matriz.Length;
        int columnas = matriz[0].Length;

        for (int j = 0; j < columnas; j++)
        {
            // Extraemos la columna j
            int[] col = new int[filas];
            for (int i = 0; i < filas; i++)
            {
                col[i] = matriz[i][j];
            }
            Array.Sort(col);
            // Reasignamos los valores ordenados de vuelta a la matriz
            for (int i = 0; i < filas; i++)
            {
                matriz[i][j] = col[i];
            }
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

        OrdenarPorColumnas(matriz2d);

        Console.WriteLine("\nMatriz con cada columna ordenada:");
        foreach (int[] fila in matriz2d) ImprimirFila(fila);
    }
}
