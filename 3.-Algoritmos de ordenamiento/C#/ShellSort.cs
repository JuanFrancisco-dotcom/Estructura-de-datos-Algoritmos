using System;

class ShellSort
{
    static void DisplayArr(int[] arr)
    {
        foreach (int k in arr)
        {
            Console.Write(k + " ");
        }
        Console.WriteLine();
    }

    void Sort(int[] arr)
    {
        int size = arr.Length;
        int gapSize = size / 2;

        while (gapSize > 0)
        {
            for (int j = gapSize; j < size; j++)
            {
                int val = arr[j];
                int k = j;
                while (k >= gapSize && arr[k - gapSize] > val)
                {
                    arr[k] = arr[k - gapSize];
                    k -= gapSize;
                }
                arr[k] = val;
            }
            gapSize /= 2;
        }
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int[] inputArr = { 36, 34, 43, 11, 15, 20, 28, 45 };

        Console.WriteLine("Arreglo antes de ser ordenado:");
        DisplayArr(inputArr);

        ShellSort obj = new ShellSort();
        obj.Sort(inputArr);

        Console.WriteLine("\nArreglo después de ser ordenado:");
        DisplayArr(inputArr);
    }
}
