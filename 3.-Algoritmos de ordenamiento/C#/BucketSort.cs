using System;
using System.Collections.Generic;
using System.Globalization;

class BucketSort
{
    static void InsertionSort(List<double> bukt)
    {
        for (int j = 1; j < bukt.Count; j++)
        {
            double val = bukt[j];
            int k = j - 1;
            while (k >= 0 && bukt[k] > val)
            {
                bukt[k + 1] = bukt[k];
                k -= 1;
            }
            bukt[k + 1] = val;
        }
    }

    static void Ordenar(double[] inputArr)
    {
        int s = inputArr.Length;
        List<List<double>> bucketArr = new List<List<double>>();
        for (int i = 0; i < s; i++) bucketArr.Add(new List<double>());
        foreach (double j in inputArr)
        {
            int bi = (int)(s * j);
            bucketArr[bi].Add(j);
        }
        foreach (List<double> bukt in bucketArr)
        {
            InsertionSort(bukt);
        }
        int idx = 0;
        foreach (List<double> bukt in bucketArr)
        {
            foreach (double j in bukt)
            {
                inputArr[idx] = j;
                idx += 1;
            }
        }
    }

    static string Unir(double[] a)
    {
        string[] partes = new string[a.Length];
        for (int i = 0; i < a.Length; i++) partes[i] = a[i].ToString(CultureInfo.InvariantCulture);
        return string.Join(" ", partes);
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        double[] inputArr = { 0.77, 0.16, 0.38, 0.25, 0.71, 0.93, 0.22, 0.11, 0.24, 0.67 };
        Console.WriteLine("Arreglo antes de ordenar:");
        Console.WriteLine(Unir(inputArr));
        Ordenar(inputArr);
        Console.WriteLine("Arreglo después de ordenar:");
        Console.WriteLine(Unir(inputArr));
    }
}
