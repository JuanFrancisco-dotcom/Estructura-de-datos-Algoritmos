public class BusquedaBinaria {

    public static int busquedaBinaria(int[] lista, int elementoBuscado) {
        int inicio = 0;
        int fin = lista.length - 1;

        while (inicio <= fin) {
            int medio = inicio + (fin - inicio) / 2;

            if (lista[medio] == elementoBuscado) {
                return medio;
            } else if (lista[medio] < elementoBuscado) {
                inicio = medio + 1;
            } else {
                fin = medio - 1;
            }
        }

        return -1;
    }

    public static void main(String[] args) {
        int[] datos = {14, 26, 41, 58, 75, 87, 93, 102};
        int objetivo = 87;

        int posicion = busquedaBinaria(datos, objetivo);

        if (posicion != -1) {
            System.out.println("El elemento " + objetivo + " se encontró en el índice " + posicion + ".");
        } else {
            System.out.println("El elemento " + objetivo + " no se encuentra en la lista.");
        }
    }
}