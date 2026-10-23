public class RadixSort {
    static void countingsort(int[] arr, int exp) {
        int s = arr.length;
        int[] outputArray = new int[s];
        int[] countArray = new int[10];
        for (int j = 0; j < s; j++) {
            int idx = arr[j] / exp;
            countArray[idx % 10] += 1;
        }
        for (int j = 1; j < 10; j++) {
            countArray[j] += countArray[j - 1];
        }
        int j = s - 1;
        while (j >= 0) {
            int idx = arr[j] / exp;
            outputArray[countArray[idx % 10] - 1] = arr[j];
            countArray[idx % 10] -= 1;
            j -= 1;
        }
        for (int k = 0; k < arr.length; k++) {
            arr[k] = outputArray[k];
        }
    }

    static void radixSort(int[] arr) {
        int max1 = arr[0];
        for (int v : arr) {
            if (v > max1) max1 = v;
        }
        int exp = 1;
        while (max1 / exp >= 1) {
            countingsort(arr, exp);
            exp *= 10;
        }
    }

    public static void main(String[] args) {
        int[] arr = {171, 46, 76, 91, 803, 25, 3, 67};
        System.out.println("Arreglo antes de ordenar: ");
        for (int j = 0; j < arr.length; j++) System.out.print(arr[j] + " ");
        radixSort(arr);
        System.out.println("\nDespués de ordenar el arreglo: ");
        for (int j = 0; j < arr.length; j++) System.out.print(arr[j]);
    }
}
