using System;

class InsertionSort
{
    static void Ordenar(int[] a)
    {
        for (int i = 1; i < a.Length; i++)
        {
            int temp = a[i];
            int j = i - 1;
            while (j >= 0 && temp < a[j])
            {
                a[j + 1] = a[j];
                j = j - 1;
            }
            a[j + 1] = temp;
        }
    }

    static void PrintArr(int[] a)
    {
        for (int i = 0; i < a.Length; i++)
        {
            Console.Write(a[i] + " ");
        }
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int[] a = { 70, 15, 2, 51, 60 };
        Console.WriteLine("Antes de ordenar los elementos del arreglo: ");
        PrintArr(a);
        Ordenar(a);
        Console.WriteLine("\nDespués de arreglos los elementos del arreglo: ");
        PrintArr(a);
    }
}
