public class RecorridoDeMatriz3D {
    static void recorridoMatriz3D(int[][][] matriz) {
        for (int i = 0; i < matriz.length; i++) {
            System.out.println("Capa " + i + ":");
            for (int j = 0; j < matriz[i].length; j++) {
                for (int k = 0; k < matriz[i][j].length; k++) {
                    System.out.print(matriz[i][j][k] + " ");
                }
                System.out.println();
            }
            System.out.println();
        }
    }

    public static void main(String[] args) {
        int[][][] matriz3d = {
            {
                {12, 45, 78},
                {34, 89, 23}
            },
            {
                {67, 90, 11},
                {55, 82, 44}
            }
        };

        System.out.println("Recorrido de la matriz 3D:\n");
        recorridoMatriz3D(matriz3d);
    }
}
