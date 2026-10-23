import java.util.Arrays;

public class BubbleSort {
    static void bubbleSort(int[] arr) {
        int n = arr.length;

        while (true) {
            boolean swapped = false;
            for (int i = 1; i < n; i++) {
                if (arr[i - 1] > arr[i]) {
                    int t = arr[i - 1];
                    arr[i - 1] = arr[i];
                    arr[i] = t;
                    swapped = true;
                }
            }
            n -= 1;
            if (!swapped) break;
        }
    }

    public static void main(String[] args) {
        int[] lista = {12, 11, 13, 5, 6, 7};
        System.out.println("Antes de ordenar los elementos del array son:  " + Arrays.toString(lista));
        bubbleSort(lista);
        System.out.println("\nDespués de ordenar el arreglo:  " + Arrays.toString(lista));
    }
}
