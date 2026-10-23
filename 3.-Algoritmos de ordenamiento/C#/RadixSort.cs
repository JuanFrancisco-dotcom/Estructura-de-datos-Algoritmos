using System;

class RadixSort
{
    static void CountingSort(int[] arr, int exp)
    {
        int s = arr.Length;
        int[] outputArray = new int[s];
        int[] countArray = new int[10];
        for (int j = 0; j < s; j++)
        {
            int idx = arr[j] / exp;
            countArray[idx % 10] += 1;
        }
        for (int j = 1; j < 10; j++)
        {
            countArray[j] += countArray[j - 1];
        }
        int jj = s - 1;
        while (jj >= 0)
        {
            int idx = arr[jj] / exp;
            outputArray[countArray[idx % 10] - 1] = arr[jj];
            countArray[idx % 10] -= 1;
            jj -= 1;
        }
        for (int k = 0; k < arr.Length; k++)
        {
            arr[k] = outputArray[k];
        }
    }

    static void Ordenar(int[] arr)
    {
        int max1 = arr[0];
        foreach (int v in arr)
        {
            if (v > max1) max1 = v;
        }
        int exp = 1;
        while (max1 / exp >= 1)
        {
            CountingSort(arr, exp);
            exp *= 10;
        }
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int[] arr = { 171, 46, 76, 91, 803, 25, 3, 67 };
        Console.WriteLine("Arreglo antes de ordenar: ");
        for (int j = 0; j < arr.Length; j++) Console.Write(arr[j] + " ");
        Ordenar(arr);
        Console.WriteLine("\nDespués de ordenar el arreglo: ");
        for (int j = 0; j < arr.Length; j++) Console.Write(arr[j]);
    }
}
