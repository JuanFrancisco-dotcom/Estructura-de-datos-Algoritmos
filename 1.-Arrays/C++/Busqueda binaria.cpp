#include <iostream>

using namespace std;

int busquedaBinaria(int lista[], int tamano, int elementoBuscado) {
    int inicio = 0;
    int fin = tamano - 1;

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

int main() {
    int datos[] = {14, 26, 41, 58, 75, 87, 93, 102};
    int tamano = sizeof(datos) / sizeof(datos[0]);
    int objetivo = 87;

    int posicion = busquedaBinaria(datos, tamano, objetivo);

    if (posicion != -1) {
        cout << "El elemento " << objetivo << " se encontro en el indice " << posicion << ".\n";
    } else {
        cout << "El elemento " << objetivo << " no se encuentra en la lista.\n";
    }

    return 0;
}