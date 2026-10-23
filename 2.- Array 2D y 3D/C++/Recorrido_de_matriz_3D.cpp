#include <iostream>
using namespace std;

const int CAPAS = 2;
const int FILAS = 2;
const int COLUMNAS = 3;

void recorridoMatriz3D(int matriz[CAPAS][FILAS][COLUMNAS]) {
    for (int i = 0; i < CAPAS; i++) {
        cout << "Capa " << i << ":" << endl;
        for (int j = 0; j < FILAS; j++) {
            for (int k = 0; k < COLUMNAS; k++) {
                cout << matriz[i][j][k] << " ";
            }
            cout << endl;
        }
        cout << endl;
    }
}

int main() {
    int matriz3d[CAPAS][FILAS][COLUMNAS] = {
        {
            {12, 45, 78},
            {34, 89, 23}
        },
        {
            {67, 90, 11},
            {55, 82, 44}
        }
    };

    cout << "Recorrido de la matriz 3D:" << endl << endl;
    recorridoMatriz3D(matriz3d);
    return 0;
}
