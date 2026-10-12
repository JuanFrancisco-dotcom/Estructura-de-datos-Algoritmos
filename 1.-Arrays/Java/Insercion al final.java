import java.util.Arrays;

public class InsercionAlFinal {

    public static void insertarAlFinal(int[] lista, int[] tamano, int nuevoElemento) {
        lista[tamano[0]] = nuevoElemento;
        tamano[0]++;
    }

    public static void imprimirLista(int[] lista, int tamano) {
        System.out.println(Arrays.toString(Arrays.copyOf(lista, tamano)));
    }

    public static void main(String[] args) {
        int[] datos = new int[100];
        int[] iniciales = {36, 34, 43, 11, 15, 20, 28, 45};
        System.arraycopy(iniciales, 0, datos, 0, iniciales.length);
        
        int[] tamano = {iniciales.length};
        int nuevo = 99;

        System.out.print("Lista original: ");
        imprimirLista(datos, tamano[0]);

        insertarAlFinal(datos, tamano, nuevo);

        System.out.print("Lista con inserción al final: ");
        imprimirLista(datos, tamano[0]);
    }
}