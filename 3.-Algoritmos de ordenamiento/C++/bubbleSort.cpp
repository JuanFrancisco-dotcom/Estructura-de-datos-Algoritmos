#include <iostream>
using namespace std;

void bubbleSort(int arr[], int n) {
    while (true) {
        bool swapped = false;
        for (int i = 1; i < n; i++) {
            if (arr[i - 1] > arr[i]) {
                int t = arr[i - 1];
                arr[i - 1] = arr[i];
                arr[i] = t;
                swapped = true;
            }
        }
        n -= 1;
        if (!swapped) break;
    }
}

void imprimirLista(int a[], int n) {
    cout << "[";
    for (int i = 0; i < n; i++) {
        if (i > 0) cout << ", ";
        cout << a[i];
    }
    cout << "]" << endl;
}

int main() {
    int lista[] = {12, 11, 13, 5, 6, 7};
    int n = 6;
    cout << "Antes de ordenar los elementos del array son:  ";
    imprimirLista(lista, n);
    bubbleSort(lista, n);
    cout << "\nDespués de ordenar el arreglo:  ";
    imprimirLista(lista, n);
    return 0;
}
