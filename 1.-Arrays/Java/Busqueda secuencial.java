public class BusquedaSecuencial {

    public static int busquedaSecuencial(int[] lista, int elementoBuscado) {
        for (int i = 0; i < lista.length; i++) {
            if (lista[i] == elementoBuscado) {
                return i;
            }
        }
        return -1;
    }

    public static void main(String[] args) {
        int[] datos = {102, 58, 14, 87, 93, 26, 41, 75};
        int objetivo = 87;

        int posicion = busquedaSecuencial(datos, objetivo);

        if (posicion != -1) {
            System.out.println("El elemento " + objetivo + " se encontró en el índice " + posicion + ".");
        } else {
            System.out.println("El elemento " + objetivo + " no se encuentra en la lista.");
        }
    }
}