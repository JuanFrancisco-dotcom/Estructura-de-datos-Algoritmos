public class ShellSort {
    static void displayArr(int[] arr) {
        for (int k : arr) {
            System.out.print(k + " ");
        }
        System.out.println();
    }

    void sort(int[] arr) {
        int size = arr.length;
        int gapSize = size / 2;

        while (gapSize > 0) {
            for (int j = gapSize; j < size; j++) {
                int val = arr[j];
                int k = j;
                while (k >= gapSize && arr[k - gapSize] > val) {
                    arr[k] = arr[k - gapSize];
                    k -= gapSize;
                }
                arr[k] = val;
            }
            gapSize /= 2;
        }
    }

    public static void main(String[] args) {
        int[] inputArr = {36, 34, 43, 11, 15, 20, 28, 45};

        System.out.println("Arreglo antes de ser ordenado:");
        displayArr(inputArr);

        ShellSort obj = new ShellSort();
        obj.sort(inputArr);

        System.out.println("\nArreglo después de ser ordenado:");
        displayArr(inputArr);
    }
}
