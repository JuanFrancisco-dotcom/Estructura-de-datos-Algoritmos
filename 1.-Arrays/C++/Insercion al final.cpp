#include <iostream>

using namespace std;

void insertarAlFinal(int lista[], int &tamano, int nuevoElemento) {
    lista[tamano] = nuevoElemento;
    tamano++;
}

void imprimirLista(int lista[], int tamano) {
    for (int i = 0; i < tamano; ++i) {
        cout << lista[i] << (i + 1 < tamano ? ", " : "");
    }
    cout << "\n";
}

int main() {
    int datos[100] = {36, 34, 43, 11, 15, 20, 28, 45};
    int tamano = 8;
    int nuevo = 99;

    cout << "Lista original: ";
    imprimirLista(datos, tamano);

    insertarAlFinal(datos, tamano, nuevo);

    cout << "Lista con insercion al final: ";
    imprimirLista(datos, tamano);

    return 0;
}