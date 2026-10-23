#include <iostream>
using namespace std;

void selection(int a[], int n) {
    for (int i = 0; i < n; i++) {
        int small = i;
        for (int j = i + 1; j < n; j++) {
            if (a[small] > a[j]) {
                small = j;
            }
        }
        int t = a[i];
        a[i] = a[small];
        a[small] = t;
    }
}

void printArr(int a[], int n) {
    for (int i = 0; i < n; i++) cout << a[i] << " ";
}

int main() {
    int a[] = {65, 26, 13, 23, 12};
    int n = 5;
    cout << "Arrelo antes de ser ordenado: " << endl;
    printArr(a, n);
    selection(a, n);
    cout << "\nnArreglo después de ser ordenado: " << endl;
    selection(a, n);
    printArr(a, n);
    return 0;
}
