using System;

class SelectionSort
{
    static void Selection(int[] a)
    {
        for (int i = 0; i < a.Length; i++)
        {
            int small = i;
            for (int j = i + 1; j < a.Length; j++)
            {
                if (a[small] > a[j])
                {
                    small = j;
                }
            }
            int t = a[i];
            a[i] = a[small];
            a[small] = t;
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
        int[] a = { 65, 26, 13, 23, 12 };
        Console.WriteLine("Arrelo antes de ser ordenado: ");
        PrintArr(a);
        Selection(a);
        Console.WriteLine("\nnArreglo después de ser ordenado: ");
        Selection(a);
        PrintArr(a);
    }
}
