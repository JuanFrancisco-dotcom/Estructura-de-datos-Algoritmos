using System;

class HeapSort
{
    static void Heapify(int[] arr, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && arr[left] > arr[largest])
        {
            largest = left;
        }
        if (right < n && arr[right] > arr[largest])
        {
            largest = right;
        }
        if (largest != i)
        {
            int t = arr[i];
            arr[i] = arr[largest];
            arr[largest] = t;
            Heapify(arr, n, largest);
        }
    }

    static void Ordenar(int[] arr)
    {
        int n = arr.Length;

        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(arr, n, i);
        }
        for (int i = n - 1; i > 0; i--)
        {
            int t = arr[0];
            arr[0] = arr[i];
            arr[i] = t;
            Heapify(arr, i, 0);
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
