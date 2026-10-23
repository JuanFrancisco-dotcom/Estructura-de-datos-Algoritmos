using System;

class BubbleSort
{
    static void Ordenar(int[] arr)
    {
        int n = arr.Length;

        while (true)
        {
            bool swapped = false;
            for (int i = 1; i < n; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    int t = arr[i - 1];
                    arr[i - 1] = arr[i];
                    arr[i] = t;
                    swapped = true;
                }
            }
            n -= 1;
            if (!swapped) break;
        }
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int[] lista = { 12, 11, 13, 5, 6, 7 };
        Console.WriteLine("Antes de ordenar los elementos del array son:  [" + string.Join(", ", lista) + "]");
        Ordenar(lista);
        Console.WriteLine("\nDespués de ordenar el arreglo:  [" + string.Join(", ", lista) + "]");
    }
}
