import java.util.Arrays;

public class EliminacionAlFinal {

    public static Integer eliminarAlFinal(int[] lista, int[] tamano) {
        if (tamano[0] > 0) {
            int elemento = lista[tamano[0] - 1];
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
        int[] iniciales = {36, 34, 43, 11, 15, 20, 28, 45};
        System.arraycopy(iniciales, 0, datos, 0, iniciales.length);
        
        int[] tamano = {iniciales.length};

        System.out.print("Lista original: ");
        imprimirLista(datos, tamano[0]);

        Integer eliminado = eliminarAlFinal(datos, tamano);

        System.out.println("Elemento eliminado: " + (eliminado != null ? eliminado : "None"));
        System.out.print("Lista después de eliminar al final: ");
        imprimirLista(datos, tamano[0]);
    }
}