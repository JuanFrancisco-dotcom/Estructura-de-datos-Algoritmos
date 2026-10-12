#include <iostream>

using namespace std;

bool eliminarAlInicio(int lista[], int &tamano, int &elementoEliminado) {
    if (tamano > 0) {
        elementoEliminado = lista[0];
        for (int i = 0; i < tamano - 1; ++i) {
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
    int datos[100] = {36, 34, 43, 11, 15, 20, 28, 45};
    int tamano = 8;
    int eliminado;

    cout << "Lista original: ";
    imprimirLista(datos, tamano);

    if (eliminarAlInicio(datos, tamano, eliminado)) {
        cout << "Elemento eliminado: " << eliminado << "\n";
    } else {
        cout << "None\n";
    }

    cout << "Lista despues de eliminar al inicio: ";
    imprimirLista(datos, tamano);

    return 0;
}