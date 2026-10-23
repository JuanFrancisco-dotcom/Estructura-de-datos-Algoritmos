using System;

class MergeSort
{
    static void Merge(int[] a, int l, int m, int r)
    {
        int a1 = m - l + 1;
        int a2 = r - m;
        int[] L = new int[a1];
        int[] R = new int[a2];
        for (int j = 0; j < a1; j++) L[j] = a[l + j];
        for (int k = 0; k < a2; k++) R[k] = a[m + 1 + k];
        int i = 0, jj = 0, kk = l;
        while (i < a1 && jj < a2)
        {
            if (L[i] <= R[jj])
            {
                a[kk] = L[i];
                i = i + 1;
            }
            else
            {
                a[kk] = R[jj];
                jj = jj + 1;
            }
            kk = kk + 1;
        }
        while (i < a1)
        {
            a[kk] = L[i];
            i = i + 1;
            kk = kk + 1;
        }
        while (jj < a2)
        {
            a[kk] = R[jj];
            jj = jj + 1;
            kk = kk + 1;
        }
    }

    static void Ordenar(int[] a, int l, int r)
    {
        if (l < r)
        {
            int m = l + (r - l) / 2;
            Ordenar(a, l, m);
            Ordenar(a, m + 1, r);
            Merge(a, l, m, r);
        }
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int[] a = { 39, 28, 44, 11 };
        int s = a.Length;
        Console.WriteLine("Antes de ordenar el arreglo: ");
        for (int j = 0; j < s; j++) Console.Write(a[j] + " ");
        Ordenar(a, 0, s - 1);
        Console.WriteLine("\nDespués de ordenar el arreglo: ");
        for (int j = 0; j < s; j++) Console.Write(a[j] + " ");
    }
}
