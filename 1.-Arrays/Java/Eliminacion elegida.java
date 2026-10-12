import java.util.Arrays;

public class EliminacionElegida {

    public static Integer eliminarPorIndice(int[] lista, int[] tamano, int indice) {
        if (indice >= 0 && indice < tamano[0]) {
            int elemento = lista[indice];
            for (int i = indice; i < tamano[0] - 1; i++) {
                lista[i] = lista[i + 1];
            }
            tamano[0]--;
            return elemento;
        }
        return null;
    }

    public static void imprimirLista(int[] lista, int tamano) {
        System.out.println(Arrays.toString(Arrays.copyOf(lista, tamano)));
    }

    public static void main(String[] args) {
        int[] datos = new int[100];
        int[] iniciales = {102, 58, 14, 87, 93, 26, 41, 75};
        System.arraycopy(iniciales, 0, datos, 0, iniciales.length);
        
        int[] tamano = {iniciales.length};
        int posicion = 3;

        System.out.print("Lista original: ");
        imprimirLista(datos, tamano[0]);

        Integer eliminado = eliminarPorIndice(datos, tamano, posicion);

        System.out.println("Elemento eliminado en el índice " + posicion + ": " + (eliminado != null ? eliminado : "None"));
        System.out.print("Lista después de la eliminación: ");
        imprimirLista(datos, tamano[0]);
    }
}