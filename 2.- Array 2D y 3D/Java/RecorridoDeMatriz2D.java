public class RecorridoDeMatriz2D {
    static void recorridoMatriz2D(int[][] matriz) {
        for (int i = 0; i < matriz.length; i++) {
            for (int j = 0; j < matriz[i].length; j++) {
                System.out.print(matriz[i][j] + " ");
            }
            System.out.println();
        }
    }

    public static void main(String[] args) {
        int[][] matriz2d = {
            {12, 45, 78},
            {34, 89, 23},
            {67, 90, 11}
        };

        System.out.println("Recorrido de la matriz 2D:");
        recorridoMatriz2D(matriz2d);
    }
}
