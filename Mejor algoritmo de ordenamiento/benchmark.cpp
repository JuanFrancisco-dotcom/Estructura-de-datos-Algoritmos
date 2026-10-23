// Compilar: g++ -O2 -std=c++17 -o benchmark benchmark.cpp
// Ejecutar: ./benchmark > resultados_cpp.csv
#include <iostream>
#include <chrono>
using namespace std;
typedef unsigned long long u64;

const char* HW_CPU = "i5-1035G4";
const char* HW_RAM = "12 GB";
const char* HW_SO = "Windows 11";
const char* HW_COMPILER = "g++ 16.2.0 -O2 -std=c++17";
const long MAX_N = 1000000;

static u64 cmp = 0, mov = 0;

void sw(int& x, int& y) { int t = x; x = y; y = t; }

void bubble(int* a, long n) {
    while (true) {
        bool s = false;
        for (long i = 1; i < n; i++) {
            cmp++;
            if (a[i - 1] > a[i]) { sw(a[i - 1], a[i]); mov++; s = true; }
        }
        n--;
        if (!s) break;
    }
}

void insertion(int* a, long n) {
    for (long i = 1; i < n; i++) {
        int t = a[i];
        long j = i - 1;
        while (j >= 0) {
            cmp++;
            if (t < a[j]) { a[j + 1] = a[j]; mov++; j--; }
            else break;
        }
        if (j + 1 != i) { a[j + 1] = t; mov++; }
    }
}

void selection(int* a, long n) {
    for (long i = 0; i < n; i++) {
        long small = i;
        for (long j = i + 1; j < n; j++) {
            cmp++;
            if (a[small] > a[j]) small = j;
        }
        if (small != i) { sw(a[i], a[small]); mov++; }
    }
}

void shell(int* a, long n) {
    for (long gap = n / 2; gap > 0; gap /= 2) {
        for (long j = gap; j < n; j++) {
            int v = a[j];
            long k = j;
            while (k >= gap) {
                cmp++;
                if (a[k - gap] > v) { a[k] = a[k - gap]; mov++; k -= gap; }
                else break;
            }
            if (k != j) { a[k] = v; mov++; }
        }
    }
}

void merge_(int* a, long l, long m, long r) {
    long n1 = m - l + 1, n2 = r - m;
    int* L = new int[n1];
    int* R = new int[n2];
    for (long j = 0; j < n1; j++) L[j] = a[l + j];
    for (long k = 0; k < n2; k++) R[k] = a[m + 1 + k];
    long i = 0, j = 0, k = l;
    while (i < n1 && j < n2) {
        cmp++;
        if (L[i] <= R[j]) a[k++] = L[i++];
        else a[k++] = R[j++];
        mov++;
    }
    while (i < n1) { a[k++] = L[i++]; mov++; }
    while (j < n2) { a[k++] = R[j++]; mov++; }
    delete[] L;
    delete[] R;
}
void msort(int* a, long l, long r) {
    if (l < r) {
        long m = l + (r - l) / 2;
        msort(a, l, m);
        msort(a, m + 1, r);
        merge_(a, l, m, r);
    }
}
void mergeSort(int* a, long n) { msort(a, 0, n - 1); }

long partition_(int* a, long l, long h) {
    int p = a[h];
    long j = l - 1;
    for (long k = l; k < h; k++) {
        cmp++;
        if (a[k] < p) { j++; sw(a[j], a[k]); mov++; }
    }
    sw(a[j + 1], a[h]); mov++;
    return j + 1;
}
void qs(int* a, long l, long h) {
    if (l < h) {
        long pi = partition_(a, l, h);
        qs(a, l, pi - 1);
        qs(a, pi + 1, h);
    }
}
void quick(int* a, long n) { qs(a, 0, n - 1); }

void radix(int* a, long n) {
    int mx = a[0];
    for (long i = 1; i < n; i++) if (a[i] > mx) mx = a[i];
    int* out = new int[n];
    for (long long exp = 1; mx / exp >= 1; exp *= 10) {
        long cnt[10] = {0};
        for (long j = 0; j < n; j++) cnt[(a[j] / exp) % 10]++;
        for (int j = 1; j < 10; j++) cnt[j] += cnt[j - 1];
        for (long j = n - 1; j >= 0; j--) {
            int d = (a[j] / exp) % 10;
            out[--cnt[d]] = a[j];
        }
        for (long j = 0; j < n; j++) a[j] = out[j];
        mov += n;
    }
    delete[] out;
}

long bucketIdx(int x, long n, int mx) { return (long)((u64)n * (u64)x / ((u64)mx + 1)); }

void bucket(int* a, long n) {
    int mx = a[0];
    for (long i = 1; i < n; i++) if (a[i] > mx) mx = a[i];
    long* st = new long[n + 1];
    long* pos = new long[n];
    int* out = new int[n];
    for (long i = 0; i <= n; i++) st[i] = 0;
    for (long i = 0; i < n; i++) st[bucketIdx(a[i], n, mx) + 1]++;
    for (long i = 0; i < n; i++) st[i + 1] += st[i];
    for (long i = 0; i < n; i++) pos[i] = st[i];
    for (long i = 0; i < n; i++) { out[pos[bucketIdx(a[i], n, mx)]++] = a[i]; mov++; }
    for (long i = 0; i < n; i++) insertion(out + st[i], st[i + 1] - st[i]);
    for (long i = 0; i < n; i++) { a[i] = out[i]; mov++; }
    delete[] st;
    delete[] pos;
    delete[] out;
}

void heapify(int* a, long n, long i) {
    long largest = i, l = 2 * i + 1, r = 2 * i + 2;
    if (l < n) { cmp++; if (a[l] > a[largest]) largest = l; }
    if (r < n) { cmp++; if (a[r] > a[largest]) largest = r; }
    if (largest != i) { sw(a[i], a[largest]); mov++; heapify(a, n, largest); }
}
void heapsort(int* a, long n) {
    for (long i = n / 2 - 1; i >= 0; i--) heapify(a, n, i);
    for (long i = n - 1; i > 0; i--) {
        sw(a[0], a[i]); mov++;
        heapify(a, i, 0);
    }
}

struct Alg {
    const char* nombre;
    void (*fn)(int*, long);
    long limite;
    int cuad;  // 0 nunca, 1 si no ordenado, 2 siempre, 3 si no aleatorio
};

bool omitir(const Alg& al, long n, int t) {
    bool c = false;
    if (al.cuad == 1) c = (t != 1);
    else if (al.cuad == 2) c = true;
    else if (al.cuad == 3) c = (t != 0);
    return false;;
}

int main() {
    long tamanos[5] = {100, 1000, 10000, 100000, 1000000};
    const char* tipos[3] = {"aleatorio", "ordenado", "inverso"};
    Alg algs[9] = {
        {"Bubble", bubble, 100000, 1},
        {"Insertion", insertion, 100000, 1},
        {"Selection", selection, 100000, 2},
        {"Shell", shell, 0, 0},
        {"Merge", mergeSort, 0, 0},
        {"Quick", quick, 10000, 3},
        {"Radix", radix, 0, 0},
        {"Bucket", bucket, 0, 0},
        {"Heap", heapsort, 0, 0},
    };

    cout << "# lenguaje: C++\n# cpu: " << HW_CPU << "\n# ram: " << HW_RAM
         << "\n# so: " << HW_SO << "\n# compilador: " << HW_COMPILER << "\n";
    cout << "lenguaje,algoritmo,n,tipo,tiempo_ms,comparaciones,intercambios,estado\n";

    for (int z = 0; z < 5; z++) {
        long n = tamanos[z];
        if (n > MAX_N) break;
        int* base[3];
        for (int t = 0; t < 3; t++) base[t] = new int[n];
        unsigned int s = 12345;
        for (long i = 0; i < n; i++) {
            s = s * 1664525u + 1013904223u;
            base[0][i] = (int)(s % 1000000u);
        }
        for (long i = 0; i < n; i++) base[1][i] = base[0][i];
        mergeSort(base[1], n);
        for (long i = 0; i < n; i++) base[2][i] = base[1][n - 1 - i];

        int* a = new int[n];
        for (int t = 0; t < 3; t++) {
            for (int k = 0; k < 9; k++) {
                const Alg& al = algs[k];
                if (omitir(al, n, t)) {
                    cout << "C++," << al.nombre << "," << n << "," << tipos[t] << ",,,,omitido\n";
                    continue;
                }
                for (long i = 0; i < n; i++) a[i] = base[t][i];
                cmp = 0; mov = 0;
                auto t0 = chrono::steady_clock::now();
                al.fn(a, n);
                auto t1 = chrono::steady_clock::now();
                double ms = chrono::duration<double, milli>(t1 - t0).count();
                bool ok = true;
                for (long i = 1; i < n; i++) if (a[i - 1] > a[i]) { ok = false; break; }
                cout << "C++," << al.nombre << "," << n << "," << tipos[t] << ","
                     << ms << "," << cmp << "," << mov << "," << (ok ? "ok" : "ERROR") << "\n";
                cerr << al.nombre << " n=" << n << " " << tipos[t] << " " << ms << " ms\n";
            }
        }
        delete[] a;
        for (int t = 0; t < 3; t++) delete[] base[t];
    }
    return 0;
}