#include <iostream>
using namespace std;

const int FILAS = 3;
const int COLUMNAS = 3;

void recorridoMatriz2D(int matriz[FILAS][COLUMNAS]) {
    for (int i = 0; i < FILAS; i++) {
        for (int j = 0; j < COLUMNAS; j++) {
            cout << matriz[i][j] << " ";
        }
        cout << endl;
    }
}

int main() {
    int matriz2d[FILAS][COLUMNAS] = {
        {12, 45, 78},
        {34, 89, 23},
        {67, 90, 11}
    };

    cout << "Recorrido de la matriz 2D:" << endl;
    recorridoMatriz2D(matriz2d);
    return 0;
}
