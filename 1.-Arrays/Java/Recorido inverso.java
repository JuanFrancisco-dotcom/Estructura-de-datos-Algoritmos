public class RecorridoInverso {

    public static int busquedaSecuencialInversa(int[] lista, int elementoBuscado) {
        for (int i = lista.length - 1; i >= 0; i--) {
            if (lista[i] == elementoBuscado) {
                return i;
            }
        }
        return -1;
    }

    public static void main(String[] args) {
        int[] datos = {36, 34, 43, 11, 15, 20, 28, 45};
        int objetivo = 20;

        int posicion = busquedaSecuencialInversa(datos, objetivo);

        if (posicion != -1) {
            System.out.println("El elemento " + objetivo + " se encontró en el índice " + posicion + ".");
        } else {
            System.out.println("El elemento " + objetivo + " no se encuentra en la lista.");
        }
    }
}