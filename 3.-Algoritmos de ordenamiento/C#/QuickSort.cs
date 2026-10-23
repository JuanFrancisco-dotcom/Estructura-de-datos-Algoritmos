using System;

class QuickSort
{
    static void Swap(int[] a, int j, int k)
    {
        int t = a[j];
        a[j] = a[k];
        a[k] = t;
    }

    static int Partition(int[] a, int l, int h)
    {
        int pvt = a[h];
        int j = l - 1;
        for (int k = l; k < h; k++)
        {
            if (a[k] < pvt)
            {
                j += 1;
                Swap(a, j, k);
            }
        }
        Swap(a, j + 1, h);
        return j + 1;
    }

    static void QckSort(int[] a, int l, int h)
    {
        if (l < h)
        {
            int pi = Partition(a, l, h);
            QckSort(a, l, pi - 1);
            QckSort(a, pi + 1, h);
        }
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int[] a = { 10, 7, 8, 9, 1, 5 };
        int size = a.Length;
        Console.WriteLine("El arreglo antes de ordenarlo: ");
        foreach (int v in a) Console.Write(v + " ");
        Console.WriteLine();
        QckSort(a, 0, size - 1);
        Console.WriteLine("El arreglo después de ordenarlo: ");
        foreach (int v in a) Console.Write(v + " ");
    }
}
