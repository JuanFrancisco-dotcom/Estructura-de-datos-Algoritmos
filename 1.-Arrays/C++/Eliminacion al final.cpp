#include <iostream>

using namespace std;

bool eliminarAlFinal(int lista[], int &tamano, int &elementoEliminado) {
    if (tamano > 0) {
        elementoEliminado = lista[tamano - 1];
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

    if (eliminarAlFinal(datos, tamano, eliminado)) {
        cout << "Elemento eliminado: " << eliminado << "\n";
    } else {
        cout << "None\n";
    }

    cout << "Lista despues de eliminar al final: ";
    imprimirLista(datos, tamano);

    return 0;
}