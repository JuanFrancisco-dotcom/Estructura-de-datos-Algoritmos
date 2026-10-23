using System;

class RecorridoDeMatriz3D
{
    static void RecorridoMatriz3D(int[][][] matriz)
    {
        for (int i = 0; i < matriz.Length; i++)
        {
            Console.WriteLine("Capa " + i + ":");
            for (int j = 0; j < matriz[i].Length; j++)
            {
                for (int k = 0; k < matriz[i][j].Length; k++)
                {
                    Console.Write(matriz[i][j][k] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        int[][][] matriz3d = new int[][][]
        {
            new int[][]
            {
                new int[] { 12, 45, 78 },
                new int[] { 34, 89, 23 }
            },
            new int[][]
            {
                new int[] { 67, 90, 11 },
                new int[] { 55, 82, 44 }
            }
        };

        Console.WriteLine("Recorrido de la matriz 3D:\n");
        RecorridoMatriz3D(matriz3d);
    }
}
