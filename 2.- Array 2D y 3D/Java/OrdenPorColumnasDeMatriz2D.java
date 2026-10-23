import java.util.Arrays;

public class OrdenPorColumnasDeMatriz2D {
    static void ordenarPorColumnas(int[][] matriz) {
        int filas = matriz.length;
        int columnas = matriz[0].length;

        for (int j = 0; j < columnas; j++) {
            // Extraemos la columna j
            int[] col = new int[filas];
            for (int i = 0; i < filas; i++) {
                col[i] = matriz[i][j];
            }
            Arrays.sort(col);
            // Reasignamos los valores ordenados de vuelta a la matriz
            for (int i = 0; i < filas; i++) {
                matriz[i][j] = col[i];
            }
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

        ordenarPorColumnas(matriz2d);

        System.out.println("\nMatriz con cada columna ordenada:");
        for (int[] fila : matriz2d) {
            System.out.println(Arrays.toString(fila));
        }
    }
}
