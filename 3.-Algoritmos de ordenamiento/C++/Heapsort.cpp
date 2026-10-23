#include <iostream>
using namespace std;

void heapify(int arr[], int n, int i) {
    int largest = i;
    int left = 2 * i + 1;
    int right = 2 * i + 2;

    if (left < n && arr[left] > arr[largest]) {
        largest = left;
    }
    if (right < n && arr[right] > arr[largest]) {
        largest = right;
    }
    if (largest != i) {
        int t = arr[i];
        arr[i] = arr[largest];
        arr[largest] = t;
        heapify(arr, n, largest);
    }
}

void heapsort(int arr[], int n) {
    for (int i = n / 2 - 1; i >= 0; i--) {
        heapify(arr, n, i);
    }
    for (int i = n - 1; i > 0; i--) {
        int t = arr[0];
        arr[0] = arr[i];
        arr[i] = t;
        heapify(arr, i, 0);
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
    heapsort(lista, n);
    cout << "\nDespués de ordenar el arreglo:  ";
    imprimirLista(lista, n);
    return 0;
}
