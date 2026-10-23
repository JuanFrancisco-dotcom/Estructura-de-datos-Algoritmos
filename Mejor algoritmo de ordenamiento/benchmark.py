# Ejecutar: python benchmark.py   (genera resultados_python.csv)
import sys
import time
import threading

HW_CPU = "i5-1035G4"
HW_RAM = "12 GB"
HW_SO = "Windows 11"
HW_COMPILER = "Python " + sys.version.split()[0]
MAX_N = 1000000
LIMITE_N2 = 10000  # tamaño máximo para casos cuadráticos


def bubble(a):
    n = len(a)
    c = m = 0
    while True:
        sw = False
        for i in range(1, n):
            c += 1
            if a[i - 1] > a[i]:
                a[i - 1], a[i] = a[i], a[i - 1]
                m += 1
                sw = True
        n -= 1
        if not sw:
            break
    return c, m


def insertion(a):
    c = m = 0
    for i in range(1, len(a)):
        t = a[i]
        j = i - 1
        while j >= 0:
            c += 1
            if t < a[j]:
                a[j + 1] = a[j]
                m += 1
                j -= 1
            else:
                break
        if j + 1 != i:
            a[j + 1] = t
            m += 1
    return c, m


def selection(a):
    n = len(a)
    c = m = 0
    for i in range(n):
        small = i
        for j in range(i + 1, n):
            c += 1
            if a[small] > a[j]:
                small = j
        if small != i:
            a[i], a[small] = a[small], a[i]
            m += 1
    return c, m


def shell(a):
    n = len(a)
    c = m = 0
    gap = n // 2
    while gap > 0:
        for j in range(gap, n):
            v = a[j]
            k = j
            while k >= gap:
                c += 1
                if a[k - gap] > v:
                    a[k] = a[k - gap]
                    m += 1
                    k -= gap
                else:
                    break
            if k != j:
                a[k] = v
                m += 1
        gap //= 2
    return c, m


def merge_sort(a):
    c = m = 0

    def merge(l, mid, r):
        nonlocal c, m
        L = a[l:mid + 1]
        R = a[mid + 1:r + 1]
        n1, n2 = len(L), len(R)
        i = j = 0
        k = l
        while i < n1 and j < n2:
            c += 1
            if L[i] <= R[j]:
                a[k] = L[i]
                i += 1
            else:
                a[k] = R[j]
                j += 1
            k += 1
            m += 1
        while i < n1:
            a[k] = L[i]
            i += 1
            k += 1
            m += 1
        while j < n2:
            a[k] = R[j]
            j += 1
            k += 1
            m += 1

    def sort(l, r):
        if l < r:
            mid = l + (r - l) // 2
            sort(l, mid)
            sort(mid + 1, r)
            merge(l, mid, r)

    sort(0, len(a) - 1)
    return c, m


def quick(a):
    c = m = 0

    def partition(l, h):
        nonlocal c, m
        p = a[h]
        j = l - 1
        for k in range(l, h):
            c += 1
            if a[k] < p:
                j += 1
                a[j], a[k] = a[k], a[j]
                m += 1
        a[j + 1], a[h] = a[h], a[j + 1]
        m += 1
        return j + 1

    def sort(l, h):
        if l < h:
            pi = partition(l, h)
            sort(l, pi - 1)
            sort(pi + 1, h)

    sort(0, len(a) - 1)
    return c, m


def radix(a):
    n = len(a)
    m = 0
    if n == 0:
        return 0, 0
    mx = max(a)
    exp = 1
    while mx // exp >= 1:
        cnt = [0] * 10
        for x in a:
            cnt[(x // exp) % 10] += 1
        for j in range(1, 10):
            cnt[j] += cnt[j - 1]
        out = [0] * n
        for j in range(n - 1, -1, -1):
            d = (a[j] // exp) % 10
            cnt[d] -= 1
            out[cnt[d]] = a[j]
        a[:] = out
        m += n
        exp *= 10
    return 0, m


def bucket(a):
    n = len(a)
    c = m = 0
    if n == 0:
        return 0, 0
    mx = max(a)
    b = [[] for _ in range(n)]
    for x in a:
        b[n * x // (mx + 1)].append(x)
        m += 1
    for bk in b:
        ci, mi = insertion(bk)
        c += ci
        m += mi
    idx = 0
    for bk in b:
        for x in bk:
            a[idx] = x
            idx += 1
            m += 1
    return c, m


def heapsort(a):
    c = m = 0

    def heapify(n, i):
        nonlocal c, m
        while True:
            largest = i
            l = 2 * i + 1
            r = l + 1
            if l < n:
                c += 1
                if a[l] > a[largest]:
                    largest = l
            if r < n:
                c += 1
                if a[r] > a[largest]:
                    largest = r
            if largest == i:
                break
            a[i], a[largest] = a[largest], a[i]
            m += 1
            i = largest

    n = len(a)
    for i in range(n // 2 - 1, -1, -1):
        heapify(n, i)
    for i in range(n - 1, 0, -1):
        a[0], a[i] = a[i], a[0]
        m += 1
        heapify(i, 0)
    return c, m


# nombre, función, cuad (0 nunca, 1 si no ordenado, 2 siempre, 3 si no aleatorio)
ALGS = [
    ("Bubble", bubble, 1),
    ("Insertion", insertion, 1),
    ("Selection", selection, 2),
    ("Shell", shell, 0),
    ("Merge", merge_sort, 0),
    ("Quick", quick, 3),
    ("Radix", radix, 0),
    ("Bucket", bucket, 0),
    ("Heap", heapsort, 0),
]
TIPOS = ["aleatorio", "ordenado", "inverso"]


def omitir(cuad, n, t):
    c = False
    if cuad == 1:
        c = t != 1
    elif cuad == 2:
        c = True
    elif cuad == 3:
        c = t != 0
    return c and n > LIMITE_N2


def principal():
    with open("resultados_python.csv", "w", newline="", encoding="utf-8") as f:
        f.write("# lenguaje: Python\n# cpu: %s\n# ram: %s\n# so: %s\n# compilador: %s\n"
                % (HW_CPU, HW_RAM, HW_SO, HW_COMPILER))
        f.write("lenguaje,algoritmo,n,tipo,tiempo_ms,comparaciones,intercambios,estado\n")
        for n in [100, 1000, 10000, 100000, 1000000]:
            if n > MAX_N:
                break
            rnd = []
            s = 12345
            for _ in range(n):
                s = (s * 1664525 + 1013904223) & 0xFFFFFFFF
                rnd.append(s % 1000000)
            asc = sorted(rnd)
            base = [rnd, asc, asc[::-1]]
            for t in range(3):
                for nombre, fn, cuad in ALGS:
                    if omitir(cuad, n, t):
                        f.write("Python,%s,%d,%s,,,,omitido\n" % (nombre, n, TIPOS[t]))
                        continue
                    a = base[t][:]
                    t0 = time.perf_counter()
                    c, m = fn(a)
                    t1 = time.perf_counter()
                    ms = (t1 - t0) * 1000
                    ok = a == asc
                    f.write("Python,%s,%d,%s,%.4f,%d,%d,%s\n"
                            % (nombre, n, TIPOS[t], ms, c, m, "ok" if ok else "ERROR"))
                    f.flush()
                    print(nombre, "n=%d" % n, TIPOS[t], "%.1f ms" % ms, flush=True)
    print("Listo: resultados_python.csv")


if __name__ == "__main__":
    sys.setrecursionlimit(1000000)
    try:
        threading.stack_size(256 * 1024 * 1024)
    except Exception:
        pass
    th = threading.Thread(target=principal)
    th.start()
    th.join()
