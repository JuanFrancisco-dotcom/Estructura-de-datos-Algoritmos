#include <iostream>
using namespace std;

const int FILAS = 3;
const int COLUMNAS = 3;

void ordenarArreglo(int arr[], int n) {
    for (int i = 1; i < n; i++) {
        int temp = arr[i];
        int j = i - 1;
        while (j >= 0 && arr[j] > temp) {
            arr[j + 1] = arr[j];
            j--;
        }
        arr[j + 1] = temp;
    }
}

void ordenarPorFilas(int matriz[FILAS][COLUMNAS]) {
    for (int i = 0; i < FILAS; i++) {
        ordenarArreglo(matriz[i], COLUMNAS);
    }
}

void imprimirFila(int fila[], int n) {
    cout << "[";
    for (int j = 0; j < n; j++) {
        if (j > 0) cout << ", ";
        cout << fila[j];
    }
    cout << "]" << endl;
}

int main() {
    int matriz2d[FILAS][COLUMNAS] = {
        {78, 12, 45},
        {89, 23, 34},
        {67, 11, 90}
    };

    cout << "Matriz original:" << endl;
    for (int i = 0; i < FILAS; i++) imprimirFila(matriz2d[i], COLUMNAS);

    ordenarPorFilas(matriz2d);

    cout << endl << "Matriz con cada fila ordenada:" << endl;
    for (int i = 0; i < FILAS; i++) imprimirFila(matriz2d[i], COLUMNAS);
    return 0;
}
