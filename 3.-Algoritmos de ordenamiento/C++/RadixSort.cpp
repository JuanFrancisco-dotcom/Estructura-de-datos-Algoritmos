#include <iostream>
using namespace std;

void countingsort(int arr[], int s, int exp) {
    int* outputArray = new int[s];
    int countArray[10] = {0};
    for (int j = 0; j < s; j++) {
        int idx = arr[j] / exp;
        countArray[idx % 10] += 1;
    }
    for (int j = 1; j < 10; j++) {
        countArray[j] += countArray[j - 1];
    }
    int j = s - 1;
    while (j >= 0) {
        int idx = arr[j] / exp;
        outputArray[countArray[idx % 10] - 1] = arr[j];
        countArray[idx % 10] -= 1;
        j -= 1;
    }
    for (int k = 0; k < s; k++) {
        arr[k] = outputArray[k];
    }
    delete[] outputArray;
}

void radixSort(int arr[], int s) {
    int max1 = arr[0];
    for (int i = 1; i < s; i++) {
        if (arr[i] > max1) max1 = arr[i];
    }
    int exp = 1;
    while (max1 / exp >= 1) {
        countingsort(arr, s, exp);
        exp *= 10;
    }
}

int main() {
    int arr[] = {171, 46, 76, 91, 803, 25, 3, 67};
    int s = 8;
    cout << "Arreglo antes de ordenar: " << endl;
    for (int j = 0; j < s; j++) cout << arr[j] << " ";
    radixSort(arr, s);
    cout << "\nDespués de ordenar el arreglo: " << endl;
    for (int j = 0; j < s; j++) cout << arr[j];
    return 0;
}
