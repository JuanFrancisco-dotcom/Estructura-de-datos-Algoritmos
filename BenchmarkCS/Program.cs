// Ejecutar: dotnet run -c Release   (genera resultados_csharp.csv)
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

class Program
{
    const string HW_CPU = "i5-1035G4";
    const string HW_RAM = "12 GB";
    const string HW_SO = "Windows 11";
    const long MAX_N = 1000000;
    const long LIMITE_N2 = 1000000; // tamaño máximo para casos cuadráticos

    static long cmp, mov;

    delegate void Sorter(int[] a, int n);

    static void Swap(int[] a, int i, int j) { int t = a[i]; a[i] = a[j]; a[j] = t; }

    static void Bubble(int[] a, int n)
    {
        while (true)
        {
            bool s = false;
            for (int i = 1; i < n; i++)
            {
                cmp++;
                if (a[i - 1] > a[i]) { Swap(a, i - 1, i); mov++; s = true; }
            }
            n--;
            if (!s) break;
        }
    }

    static void Insertion(int[] a, int off, int n)
    {
        for (int i = 1; i < n; i++)
        {
            int t = a[off + i];
            int j = i - 1;
            while (j >= 0)
            {
                cmp++;
                if (t < a[off + j]) { a[off + j + 1] = a[off + j]; mov++; j--; }
                else break;
            }
            if (j + 1 != i) { a[off + j + 1] = t; mov++; }
        }
    }

    static void InsertionSort(int[] a, int n) { Insertion(a, 0, n); }

    static void Selection(int[] a, int n)
    {
        for (int i = 0; i < n; i++)
        {
            int small = i;
            for (int j = i + 1; j < n; j++)
            {
                cmp++;
                if (a[small] > a[j]) small = j;
            }
            if (small != i) { Swap(a, i, small); mov++; }
        }
    }

    static void Shell(int[] a, int n)
    {
        for (int gap = n / 2; gap > 0; gap /= 2)
        {
            for (int j = gap; j < n; j++)
            {
                int v = a[j];
                int k = j;
                while (k >= gap)
                {
                    cmp++;
                    if (a[k - gap] > v) { a[k] = a[k - gap]; mov++; k -= gap; }
                    else break;
                }
                if (k != j) { a[k] = v; mov++; }
            }
        }
    }

    static void Merge(int[] a, int l, int m, int r)
    {
        int n1 = m - l + 1, n2 = r - m;
        int[] L = new int[n1];
        int[] R = new int[n2];
        for (int j = 0; j < n1; j++) L[j] = a[l + j];
        for (int k = 0; k < n2; k++) R[k] = a[m + 1 + k];
        int i = 0, jj = 0, kk = l;
        while (i < n1 && jj < n2)
        {
            cmp++;
            if (L[i] <= R[jj]) a[kk++] = L[i++];
            else a[kk++] = R[jj++];
            mov++;
        }
        while (i < n1) { a[kk++] = L[i++]; mov++; }
        while (jj < n2) { a[kk++] = R[jj++]; mov++; }
    }

    static void Msort(int[] a, int l, int r)
    {
        if (l < r)
        {
            int m = l + (r - l) / 2;
            Msort(a, l, m);
            Msort(a, m + 1, r);
            Merge(a, l, m, r);
        }
    }

    static void MergeSort(int[] a, int n) { Msort(a, 0, n - 1); }

    static int Partition(int[] a, int l, int h)
    {
        int p = a[h];
        int j = l - 1;
        for (int k = l; k < h; k++)
        {
            cmp++;
            if (a[k] < p) { j++; Swap(a, j, k); mov++; }
        }
        Swap(a, j + 1, h); mov++;
        return j + 1;
    }

    static void Qs(int[] a, int l, int h)
    {
        if (l < h)
        {
            int pi = Partition(a, l, h);
            Qs(a, l, pi - 1);
            Qs(a, pi + 1, h);
        }
    }

    static void Quick(int[] a, int n) { Qs(a, 0, n - 1); }

    static void Radix(int[] a, int n)
    {
        int mx = a[0];
        for (int i = 1; i < n; i++) if (a[i] > mx) mx = a[i];
        int[] outA = new int[n];
        for (long exp = 1; mx / exp >= 1; exp *= 10)
        {
            int[] cnt = new int[10];
            for (int j = 0; j < n; j++) cnt[(int)((a[j] / exp) % 10)]++;
            for (int j = 1; j < 10; j++) cnt[j] += cnt[j - 1];
            for (int j = n - 1; j >= 0; j--)
            {
                int d = (int)((a[j] / exp) % 10);
                outA[--cnt[d]] = a[j];
            }
            for (int j = 0; j < n; j++) a[j] = outA[j];
            mov += n;
        }
    }

    static int BucketIdx(int x, int n, int mx)
    {
        return (int)((long)n * x / ((long)mx + 1));
    }

    static void Bucket(int[] a, int n)
    {
        int mx = a[0];
        for (int i = 1; i < n; i++) if (a[i] > mx) mx = a[i];
        int[] st = new int[n + 1];
        int[] pos = new int[n];
        int[] outA = new int[n];
        for (int i = 0; i < n; i++) st[BucketIdx(a[i], n, mx) + 1]++;
        for (int i = 0; i < n; i++) st[i + 1] += st[i];
        for (int i = 0; i < n; i++) pos[i] = st[i];
        for (int i = 0; i < n; i++) { outA[pos[BucketIdx(a[i], n, mx)]++] = a[i]; mov++; }
        for (int i = 0; i < n; i++) Insertion(outA, st[i], st[i + 1] - st[i]);
        for (int i = 0; i < n; i++) { a[i] = outA[i]; mov++; }
    }

    static void Heapify(int[] a, int n, int i)
    {
        while (true)
        {
            int largest = i, l = 2 * i + 1, r = l + 1;
            if (l < n) { cmp++; if (a[l] > a[largest]) largest = l; }
            if (r < n) { cmp++; if (a[r] > a[largest]) largest = r; }
            if (largest == i) break;
            Swap(a, i, largest); mov++;
            i = largest;
        }
    }

    static void HeapSort(int[] a, int n)
    {
        for (int i = n / 2 - 1; i >= 0; i--) Heapify(a, n, i);
        for (int i = n - 1; i > 0; i--)
        {
            Swap(a, 0, i); mov++;
            Heapify(a, i, 0);
        }
    }

    // cuad: 0 nunca, 1 si no ordenado, 2 siempre, 3 si no aleatorio
    static bool Omitir(int cuad, long n, int t)
    {
        bool c = false;
        if (cuad == 1) c = (t != 1);
        else if (cuad == 2) c = true;
        else if (cuad == 3) c = (t != 0);
        return c && n > LIMITE_N2;
    }

    static void Main()
    {
        Thread th = new Thread(Run, 512 * 1024 * 1024);
        th.Start();
        th.Join();
    }

    static void Run()
    {
        string[] nombres = { "Bubble", "Insertion", "Selection", "Shell", "Merge", "Quick", "Radix", "Bucket", "Heap" };
        Sorter[] fns = { Bubble, InsertionSort, Selection, Shell, MergeSort, Quick, Radix, Bucket, HeapSort };
        int[] cuads = { 1, 1, 2, 0, 0, 3, 0, 0, 0 };
        string[] tipos = { "aleatorio", "ordenado", "inverso" };
        int[] tamanos = { 100, 1000, 10000, 100000, 1000000 };
        CultureInfo inv = CultureInfo.InvariantCulture;
        string compilador = ".NET " + Environment.Version;

        using (StreamWriter w = new StreamWriter("resultados_csharp.csv", false, new UTF8Encoding(false)))
        {
            w.NewLine = "\n";
            w.WriteLine("# lenguaje: C#");
            w.WriteLine("# cpu: " + HW_CPU);
            w.WriteLine("# ram: " + HW_RAM);
            w.WriteLine("# so: " + HW_SO);
            w.WriteLine("# compilador: " + compilador);
            w.WriteLine("lenguaje,algoritmo,n,tipo,tiempo_ms,comparaciones,intercambios,estado");

            foreach (int n in tamanos)
            {
                if (n > MAX_N) break;
                int[] rnd = new int[n];
                uint s = 12345;
                for (int i = 0; i < n; i++)
                {
                    s = unchecked(s * 1664525u + 1013904223u);
                    rnd[i] = (int)(s % 1000000u);
                }
                int[] asc = (int[])rnd.Clone();
                Array.Sort(asc);
                int[] desc = new int[n];
                for (int i = 0; i < n; i++) desc[i] = asc[n - 1 - i];
                int[][] bases = { rnd, asc, desc };
                int[] a = new int[n];

                for (int t = 0; t < 3; t++)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        if (Omitir(cuads[k], n, t))
                        {
                            w.WriteLine("C#," + nombres[k] + "," + n + "," + tipos[t] + ",,,,omitido");
                            continue;
                        }
                        Array.Copy(bases[t], a, n);
                        cmp = 0; mov = 0;
                        Stopwatch sw = Stopwatch.StartNew();
                        fns[k](a, n);
                        sw.Stop();
                        double ms = sw.Elapsed.TotalMilliseconds;
                        bool ok = true;
                        for (int i = 1; i < n; i++) if (a[i - 1] > a[i]) { ok = false; break; }
                        string estado = ok ? "ok" : "ERROR";
                        string tiempo = ms.ToString("F4", inv);
                        w.WriteLine("C#," + nombres[k] + "," + n + "," + tipos[t] + "," + tiempo + "," + cmp + "," + mov + "," + estado);
                        w.Flush();
                        Console.WriteLine(nombres[k] + " n=" + n + " " + tipos[t] + " " + tiempo + " ms");
                    }
                }
            }
        }
        Console.WriteLine("Listo: resultados_csharp.csv");
    }
}
