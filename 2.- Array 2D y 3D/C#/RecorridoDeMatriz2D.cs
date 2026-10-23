using System;

class RecorridoDeMatriz2D
{
    static void RecorridoMatriz2D(int[][] matriz)
    {
        for (int i = 0; i < matriz.Length; i++)
        {
            for (int j = 0; j < matriz[i].Length; j++)
            {
                Console.Write(matriz[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        int[][] matriz2d = new int[][]
        {
            new int[] { 12, 45, 78 },
            new int[] { 34, 89, 23 },
            new int[] { 67, 90, 11 }
        };

        Console.WriteLine("Recorrido de la matriz 2D:");
        RecorridoMatriz2D(matriz2d);
    }
}
