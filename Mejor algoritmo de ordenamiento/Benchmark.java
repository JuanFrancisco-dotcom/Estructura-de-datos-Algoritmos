// Ejecutar: java Benchmark.java   (genera resultados_java.csv)
import java.io.BufferedWriter;
import java.io.FileWriter;
import java.util.Arrays;
import java.util.Locale;

public class Benchmark {
    static final String HW_CPU = "i5-1035G4";
    static final String HW_RAM = "12 GB";
    static final String HW_SO = "Windows 11";
    static final long MAX_N = 1000000;
    static final long LIMITE_N2 = 1000000; // tamaño máximo para casos cuadráticos

    static long cmp, mov;

    interface Sorter { void sort(int[] a, int n); }

    static void swap(int[] a, int i, int j) { int t = a[i]; a[i] = a[j]; a[j] = t; }

    static void bubble(int[] a, int n) {
        while (true) {
            boolean s = false;
            for (int i = 1; i < n; i++) {
                cmp++;
                if (a[i - 1] > a[i]) { swap(a, i - 1, i); mov++; s = true; }
            }
            n--;
            if (!s) break;
        }
    }

    static void insertion(int[] a, int off, int n) {
        for (int i = 1; i < n; i++) {
            int t = a[off + i];
            int j = i - 1;
            while (j >= 0) {
                cmp++;
                if (t < a[off + j]) { a[off + j + 1] = a[off + j]; mov++; j--; }
                else break;
            }
            if (j + 1 != i) { a[off + j + 1] = t; mov++; }
        }
    }

    static void insertionSort(int[] a, int n) { insertion(a, 0, n); }

    static void selection(int[] a, int n) {
        for (int i = 0; i < n; i++) {
            int small = i;
            for (int j = i + 1; j < n; j++) {
                cmp++;
                if (a[small] > a[j]) small = j;
            }
            if (small != i) { swap(a, i, small); mov++; }
        }
    }

    static void shell(int[] a, int n) {
        for (int gap = n / 2; gap > 0; gap /= 2) {
            for (int j = gap; j < n; j++) {
                int v = a[j];
                int k = j;
                while (k >= gap) {
                    cmp++;
                    if (a[k - gap] > v) { a[k] = a[k - gap]; mov++; k -= gap; }
                    else break;
                }
                if (k != j) { a[k] = v; mov++; }
            }
        }
    }

    static void merge(int[] a, int l, int m, int r) {
        int n1 = m - l + 1, n2 = r - m;
        int[] L = new int[n1];
        int[] R = new int[n2];
        for (int j = 0; j < n1; j++) L[j] = a[l + j];
        for (int k = 0; k < n2; k++) R[k] = a[m + 1 + k];
        int i = 0, jj = 0, kk = l;
        while (i < n1 && jj < n2) {
            cmp++;
            if (L[i] <= R[jj]) a[kk++] = L[i++];
            else a[kk++] = R[jj++];
            mov++;
        }
        while (i < n1) { a[kk++] = L[i++]; mov++; }
        while (jj < n2) { a[kk++] = R[jj++]; mov++; }
    }

    static void msort(int[] a, int l, int r) {
        if (l < r) {
            int m = l + (r - l) / 2;
            msort(a, l, m);
            msort(a, m + 1, r);
            merge(a, l, m, r);
        }
    }

    static void mergeSort(int[] a, int n) { msort(a, 0, n - 1); }

    static int partition(int[] a, int l, int h) {
        int p = a[h];
        int j = l - 1;
        for (int k = l; k < h; k++) {
            cmp++;
            if (a[k] < p) { j++; swap(a, j, k); mov++; }
        }
        swap(a, j + 1, h); mov++;
        return j + 1;
    }

    static void qs(int[] a, int l, int h) {
        if (l < h) {
            int pi = partition(a, l, h);
            qs(a, l, pi - 1);
            qs(a, pi + 1, h);
        }
    }

    static void quick(int[] a, int n) { qs(a, 0, n - 1); }

    static void radix(int[] a, int n) {
        int mx = a[0];
        for (int i = 1; i < n; i++) if (a[i] > mx) mx = a[i];
        int[] out = new int[n];
        for (long exp = 1; mx / exp >= 1; exp *= 10) {
            int[] cnt = new int[10];
            for (int j = 0; j < n; j++) cnt[(int) ((a[j] / exp) % 10)]++;
            for (int j = 1; j < 10; j++) cnt[j] += cnt[j - 1];
            for (int j = n - 1; j >= 0; j--) {
                int d = (int) ((a[j] / exp) % 10);
                out[--cnt[d]] = a[j];
            }
            for (int j = 0; j < n; j++) a[j] = out[j];
            mov += n;
        }
    }

    static int bucketIdx(int x, int n, int mx) {
        return (int) ((long) n * x / ((long) mx + 1));
    }

    static void bucket(int[] a, int n) {
        int mx = a[0];
        for (int i = 1; i < n; i++) if (a[i] > mx) mx = a[i];
        int[] st = new int[n + 1];
        int[] pos = new int[n];
        int[] out = new int[n];
        for (int i = 0; i < n; i++) st[bucketIdx(a[i], n, mx) + 1]++;
        for (int i = 0; i < n; i++) st[i + 1] += st[i];
        for (int i = 0; i < n; i++) pos[i] = st[i];
        for (int i = 0; i < n; i++) { out[pos[bucketIdx(a[i], n, mx)]++] = a[i]; mov++; }
        for (int i = 0; i < n; i++) insertion(out, st[i], st[i + 1] - st[i]);
        for (int i = 0; i < n; i++) { a[i] = out[i]; mov++; }
    }

    static void heapify(int[] a, int n, int i) {
        while (true) {
            int largest = i, l = 2 * i + 1, r = l + 1;
            if (l < n) { cmp++; if (a[l] > a[largest]) largest = l; }
            if (r < n) { cmp++; if (a[r] > a[largest]) largest = r; }
            if (largest == i) break;
            swap(a, i, largest); mov++;
            i = largest;
        }
    }

    static void heapSort(int[] a, int n) {
        for (int i = n / 2 - 1; i >= 0; i--) heapify(a, n, i);
        for (int i = n - 1; i > 0; i--) {
            swap(a, 0, i); mov++;
            heapify(a, i, 0);
        }
    }

    // cuad: 0 nunca, 1 si no ordenado, 2 siempre, 3 si no aleatorio
    static boolean omitir(int cuad, long n, int t) {
        boolean c = false;
        if (cuad == 1) c = (t != 1);
        else if (cuad == 2) c = true;
        else if (cuad == 3) c = (t != 0);
        return c && n > LIMITE_N2;
    }

    static void run() throws Exception {
        String[] nombres = {"Bubble", "Insertion", "Selection", "Shell", "Merge", "Quick", "Radix", "Bucket", "Heap"};
        Sorter[] fns = {
            Benchmark::bubble, Benchmark::insertionSort, Benchmark::selection, Benchmark::shell,
            Benchmark::mergeSort, Benchmark::quick, Benchmark::radix, Benchmark::bucket, Benchmark::heapSort
        };
        int[] cuads = {1, 1, 2, 0, 0, 3, 0, 0, 0};
        String[] tipos = {"aleatorio", "ordenado", "inverso"};
        int[] tamanos = {100, 1000, 10000, 100000, 1000000};

        try (BufferedWriter w = new BufferedWriter(new FileWriter("resultados_java.csv"))) {
            w.write("# lenguaje: Java\n");
            w.write("# cpu: " + HW_CPU + "\n");
            w.write("# ram: " + HW_RAM + "\n");
            w.write("# so: " + HW_SO + "\n");
            w.write("# compilador: Java " + System.getProperty("java.version") + "\n");
            w.write("lenguaje,algoritmo,n,tipo,tiempo_ms,comparaciones,intercambios,estado\n");

            for (int n : tamanos) {
                if (n > MAX_N) break;
                int[] rnd = new int[n];
                int s = 12345;
                for (int i = 0; i < n; i++) {
                    s = s * 1664525 + 1013904223;
                    rnd[i] = (int) (Integer.toUnsignedLong(s) % 1000000L);
                }
                int[] asc = rnd.clone();
                Arrays.sort(asc);
                int[] desc = new int[n];
                for (int i = 0; i < n; i++) desc[i] = asc[n - 1 - i];
                int[][] bases = {rnd, asc, desc};
                int[] a = new int[n];

                for (int t = 0; t < 3; t++) {
                    for (int k = 0; k < 9; k++) {
                        if (omitir(cuads[k], n, t)) {
                            w.write("Java," + nombres[k] + "," + n + "," + tipos[t] + ",,,,omitido\n");
                            continue;
                        }
                        System.arraycopy(bases[t], 0, a, 0, n);
                        cmp = 0;
                        mov = 0;
                        long t0 = System.nanoTime();
                        fns[k].sort(a, n);
                        long t1 = System.nanoTime();
                        double ms = (t1 - t0) / 1e6;
                        boolean ok = true;
                        for (int i = 1; i < n; i++) if (a[i - 1] > a[i]) { ok = false; break; }
                        String tiempo = String.format(Locale.US, "%.4f", ms);
                        w.write("Java," + nombres[k] + "," + n + "," + tipos[t] + "," + tiempo + "," + cmp + "," + mov + "," + (ok ? "ok" : "ERROR") + "\n");
                        w.flush();
                        System.out.println(nombres[k] + " n=" + n + " " + tipos[t] + " " + tiempo + " ms");
                    }
                }
            }
        }
        System.out.println("Listo: resultados_java.csv");
    }

    public static void main(String[] args) throws Exception {
        Thread th = new Thread(null, () -> {
            try {
                run();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }, "benchmark", 512L * 1024 * 1024);
        th.start();
        th.join();
    }
}
