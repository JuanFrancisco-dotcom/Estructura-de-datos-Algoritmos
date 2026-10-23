import java.util.Arrays;

public class OrdenPorFilasDeMatriz2D {
    static void ordenarPorFilas(int[][] matriz) {
        for (int i = 0; i < matriz.length; i++) {
            Arrays.sort(matriz[i]);
        }
    }

    public static void main(String[] args) {
        int[][] matriz2d = {
            {78, 12, 45},
            {89, 23, 34},
            {67, 11, 90}
        };

        System.out.println("Matriz original:");
        for (int[] fila : matriz2d) {
            System.out.println(Arrays.toString(fila));
        }

        ordenarPorFilas(matriz2d);

        System.out.println("\nMatriz con cada fila ordenada:");
        for (int[] fila : matriz2d) {
            System.out.println(Arrays.toString(fila));
        }
    }
}
