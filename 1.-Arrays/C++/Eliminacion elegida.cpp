#include <iostream>

using namespace std;

bool eliminarPorIndice(int lista[], int &tamano, int indice, int &elementoEliminado) {
    if (indice >= 0 && indice < tamano) {
        elementoEliminado = lista[indice];
        for (int i = indice; i < tamano - 1; ++i) {
            lista[i] = lista[i + 1];
        }
        tamano--;
        return true;
    }
    return false;
}

void imprimirLista(int lista[], int tamano) {
    for (int i = 0; i < tamano; ++i) {
        cout << lista[i] << (i + 1 < tamano ? ", " : "");
    }
    cout << "\n";
}

int main() {
    int datos[100] = {102, 58, 14, 87, 93, 26, 41, 75};
    int tamano = 8;
    int posicion = 3;
    int eliminado;

    cout << "Lista original: ";
    imprimirLista(datos, tamano);

    if (eliminarPorIndice(datos, tamano, posicion, eliminado)) {
        cout << "Elemento eliminado en el indice " << posicion << ": " << eliminado << "\n";
    } else {
        cout << "None\n";
    }

    cout << "Lista despues de la eliminacion: ";
    imprimirLista(datos, tamano);

    return 0;
}