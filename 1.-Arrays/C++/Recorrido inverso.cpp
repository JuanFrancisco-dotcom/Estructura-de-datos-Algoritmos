#include <iostream>

using namespace std;

int busquedaSecuencialInversa(int lista[], int tamano, int elementoBuscado) {
    for (int i = tamano - 1; i >= 0; --i) {
        if (lista[i] == elementoBuscado) {
            return i;
        }
    }
    return -1;
}

int main() {
    int datos[] = {36, 34, 43, 11, 15, 20, 28, 45};
    int tamano = sizeof(datos) / sizeof(datos[0]);
    int objetivo = 20;

    int posicion = busquedaSecuencialInversa(datos, tamano, objetivo);

    if (posicion != -1) {
        cout << "El elemento " << objetivo << " se encontro en el indice " << posicion << ".\n";
    } else {
        cout << "El elemento " << objetivo << " no se encuentra en la lista.\n";
    }

    return 0;
}