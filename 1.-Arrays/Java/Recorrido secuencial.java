public class RecorridoSecuencial {

    public static int busquedaSecuencial(int[] lista, int elementoBuscado) {
        for (int i = 0; i < lista.length; i++) {
            if (lista[i] == elementoBuscado) {
                return i;
            }
        }
        return -1;
    }

    public static void main(String[] args) {
        int[] datos = {36, 34, 43, 11, 15, 20, 28, 45};
        int objetivo = 20;

        int posicion = busquedaSecuencial(datos, objetivo);

        if (posicion != -1) {
            System.out.println("El elemento " + objetivo + " se encontró en el índice " + posicion + ".");
        } else {
            System.out.println("El elemento " + objetivo + " no se encuentra en la lista.");
        }
    }
}