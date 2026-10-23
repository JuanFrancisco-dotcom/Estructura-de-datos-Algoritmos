#include <iostream>
using namespace std;

class ShellSort {
public:
    static void displayArr(int arr[], int n) {
        for (int k = 0; k < n; k++) cout << arr[k] << " ";
        cout << endl;
    }

    void sort(int arr[], int size) {
        int gapSize = size / 2;
        while (gapSize > 0) {
            for (int j = gapSize; j < size; j++) {
                int val = arr[j];
                int k = j;
                while (k >= gapSize && arr[k - gapSize] > val) {
                    arr[k] = arr[k - gapSize];
                    k -= gapSize;
                }
                arr[k] = val;
            }
            gapSize /= 2;
        }
    }
};

int main() {
    int inputArr[] = {36, 34, 43, 11, 15, 20, 28, 45};
    int n = 8;

    cout << "Arreglo antes de ser ordenado:" << endl;
    ShellSort::displayArr(inputArr, n);

    ShellSort obj;
    obj.sort(inputArr, n);

    cout << "\nArreglo después de ser ordenado:" << endl;
    ShellSort::displayArr(inputArr, n);
    return 0;
}
