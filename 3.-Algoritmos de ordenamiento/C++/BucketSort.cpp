#include <iostream>
using namespace std;

const int N = 10;  // cantidad de elementos y de buckets

void insertionSort(double bukt[], int n) {
    for (int j = 1; j < n; j++) {
        double val = bukt[j];
        int k = j - 1;
        while (k >= 0 && bukt[k] > val) {
            bukt[k + 1] = bukt[k];
            k -= 1;
        }
        bukt[k + 1] = val;
    }
}

void bucketSort(double inputArr[], int s) {
    double bucketArr[N][N];
    int cuenta[N];
    for (int i = 0; i < s; i++) cuenta[i] = 0;
    for (int j = 0; j < s; j++) {
        int bi = (int)(s * inputArr[j]);
        bucketArr[bi][cuenta[bi]] = inputArr[j];
        cuenta[bi]++;
    }
    for (int i = 0; i < s; i++) {
        insertionSort(bucketArr[i], cuenta[i]);
    }
    int idx = 0;
    for (int i = 0; i < s; i++) {
        for (int k = 0; k < cuenta[i]; k++) {
            inputArr[idx] = bucketArr[i][k];
            idx += 1;
        }
    }
}

void imprimir(double a[], int n) {
    for (int i = 0; i < n; i++) {
        if (i > 0) cout << " ";
        cout << a[i];
    }
    cout << endl;
}

int main() {
    double inputArr[N] = {0.77, 0.16, 0.38, 0.25, 0.71, 0.93, 0.22, 0.11, 0.24, 0.67};
    cout << "Arreglo antes de ordenar:" << endl;
    imprimir(inputArr, N);
    bucketSort(inputArr, N);
    cout << "Arreglo después de ordenar:" << endl;
    imprimir(inputArr, N);
    return 0;
}
