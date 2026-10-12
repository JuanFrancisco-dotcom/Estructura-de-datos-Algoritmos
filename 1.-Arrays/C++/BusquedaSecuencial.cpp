#include <iostream>

using namespace std;

int busquedaSecuencial(int lista[], int tamano, int elementoBuscado) {
    for (int i = 0; i < tamano; ++i) {
        if (lista[i] == elementoBuscado) {
            return i;
        }
    }
    return -1;
}

int main() {
    int datos[] = {102, 58, 14, 87, 93, 26, 41, 75};
    int tamano = sizeof(datos) / sizeof(datos[0]);
    int objetivo = 87;

    int posicion = busquedaSecuencial(datos, tamano, objetivo);

    if (posicion != -1) {
        cout << "El elemento " << objetivo << " se encontro en el indice " << posicion << ".\n";
    } else {
        cout << "El elemento " << objetivo << " no se encuentra en la lista.\n";
    }

    return 0;
}