// Ejecutar: node benchmark.js   (genera resultados_javascript.csv)
const fs = require("fs");

const HW_CPU = "i5-1035G4";
const HW_RAM = "12 GB";
const HW_SO = "Windows 11";
const MAX_N = 1000000;
const LIMITE_N2 = 100000; // tamaño máximo para casos cuadráticos

let cmp = 0, mov = 0;

function swap(a, i, j) { const t = a[i]; a[i] = a[j]; a[j] = t; }

function bubble(a, n) {
  while (true) {
    let s = false;
    for (let i = 1; i < n; i++) {
      cmp++;
      if (a[i - 1] > a[i]) { swap(a, i - 1, i); mov++; s = true; }
    }
    n--;
    if (!s) break;
  }
}

function insertion(a, off, n) {
  for (let i = 1; i < n; i++) {
    const t = a[off + i];
    let j = i - 1;
    while (j >= 0) {
      cmp++;
      if (t < a[off + j]) { a[off + j + 1] = a[off + j]; mov++; j--; }
      else break;
    }
    if (j + 1 !== i) { a[off + j + 1] = t; mov++; }
  }
}

function insertionSort(a, n) { insertion(a, 0, n); }

function selection(a, n) {
  for (let i = 0; i < n; i++) {
    let small = i;
    for (let j = i + 1; j < n; j++) {
      cmp++;
      if (a[small] > a[j]) small = j;
    }
    if (small !== i) { swap(a, i, small); mov++; }
  }
}

function shell(a, n) {
  for (let gap = Math.floor(n / 2); gap > 0; gap = Math.floor(gap / 2)) {
    for (let j = gap; j < n; j++) {
      const v = a[j];
      let k = j;
      while (k >= gap) {
        cmp++;
        if (a[k - gap] > v) { a[k] = a[k - gap]; mov++; k -= gap; }
        else break;
      }
      if (k !== j) { a[k] = v; mov++; }
    }
  }
}

function merge(a, l, m, r) {
  const L = a.slice(l, m + 1);
  const R = a.slice(m + 1, r + 1);
  const n1 = L.length, n2 = R.length;
  let i = 0, j = 0, k = l;
  while (i < n1 && j < n2) {
    cmp++;
    if (L[i] <= R[j]) a[k++] = L[i++];
    else a[k++] = R[j++];
    mov++;
  }
  while (i < n1) { a[k++] = L[i++]; mov++; }
  while (j < n2) { a[k++] = R[j++]; mov++; }
}

function msort(a, l, r) {
  if (l < r) {
    const m = l + Math.floor((r - l) / 2);
    msort(a, l, m);
    msort(a, m + 1, r);
    merge(a, l, m, r);
  }
}

function mergeSort(a, n) { msort(a, 0, n - 1); }

function partition(a, l, h) {
  const p = a[h];
  let j = l - 1;
  for (let k = l; k < h; k++) {
    cmp++;
    if (a[k] < p) { j++; swap(a, j, k); mov++; }
  }
  swap(a, j + 1, h); mov++;
  return j + 1;
}

// Iterativo con pila propia: Node tiene un límite de recursión bajo
function quick(a, n) {
  const stack = new Int32Array(2 * n + 4);
  let top = 0;
  stack[top++] = 0;
  stack[top++] = n - 1;
  while (top > 0) {
    const h = stack[--top];
    const l = stack[--top];
    if (l < h) {
      const pi = partition(a, l, h);
      if (l < pi - 1) { stack[top++] = l; stack[top++] = pi - 1; }
      if (pi + 1 < h) { stack[top++] = pi + 1; stack[top++] = h; }
    }
  }
}

function radix(a, n) {
  let mx = a[0];
  for (let i = 1; i < n; i++) if (a[i] > mx) mx = a[i];
  const out = new Int32Array(n);
  for (let exp = 1; mx >= exp; exp *= 10) {
    const cnt = new Int32Array(10);
    for (let j = 0; j < n; j++) cnt[Math.floor(a[j] / exp) % 10]++;
    for (let j = 1; j < 10; j++) cnt[j] += cnt[j - 1];
    for (let j = n - 1; j >= 0; j--) {
      const d = Math.floor(a[j] / exp) % 10;
      out[--cnt[d]] = a[j];
    }
    for (let j = 0; j < n; j++) a[j] = out[j];
    mov += n;
  }
}

function bucketIdx(x, n, mx) { return Math.floor(n * x / (mx + 1)); }

function bucket(a, n) {
  let mx = a[0];
  for (let i = 1; i < n; i++) if (a[i] > mx) mx = a[i];
  const st = new Int32Array(n + 1);
  const pos = new Int32Array(n);
  const out = new Int32Array(n);
  for (let i = 0; i < n; i++) st[bucketIdx(a[i], n, mx) + 1]++;
  for (let i = 0; i < n; i++) st[i + 1] += st[i];
  for (let i = 0; i < n; i++) pos[i] = st[i];
  for (let i = 0; i < n; i++) { out[pos[bucketIdx(a[i], n, mx)]++] = a[i]; mov++; }
  for (let i = 0; i < n; i++) insertion(out, st[i], st[i + 1] - st[i]);
  for (let i = 0; i < n; i++) { a[i] = out[i]; mov++; }
}

function heapify(a, n, i) {
  while (true) {
    let largest = i;
    const l = 2 * i + 1, r = l + 1;
    if (l < n) { cmp++; if (a[l] > a[largest]) largest = l; }
    if (r < n) { cmp++; if (a[r] > a[largest]) largest = r; }
    if (largest === i) break;
    swap(a, i, largest); mov++;
    i = largest;
  }
}

function heapSort(a, n) {
  for (let i = Math.floor(n / 2) - 1; i >= 0; i--) heapify(a, n, i);
  for (let i = n - 1; i > 0; i--) {
    swap(a, 0, i); mov++;
    heapify(a, i, 0);
  }
}

// cuad: 0 nunca, 1 si no ordenado, 2 siempre, 3 si no aleatorio
const ALGS = [
  ["Bubble", bubble, 1],
  ["Insertion", insertionSort, 1],
  ["Selection", selection, 2],
  ["Shell", shell, 0],
  ["Merge", mergeSort, 0],
  ["Quick", quick, 3],
  ["Radix", radix, 0],
  ["Bucket", bucket, 0],
  ["Heap", heapSort, 0],
];
const TIPOS = ["aleatorio", "ordenado", "inverso"];

function omitir(cuad, n, t) {
  let c = false;
  if (cuad === 1) c = t !== 1;
  else if (cuad === 2) c = true;
  else if (cuad === 3) c = t !== 0;
  return c && n > LIMITE_N2;
}

const fd = fs.openSync("resultados_javascript.csv", "w");
const w = (s) => fs.writeSync(fd, s);

w("# lenguaje: JavaScript\n");
w("# cpu: " + HW_CPU + "\n");
w("# ram: " + HW_RAM + "\n");
w("# so: " + HW_SO + "\n");
w("# compilador: Node.js " + process.version + "\n");
w("lenguaje,algoritmo,n,tipo,tiempo_ms,comparaciones,intercambios,estado\n");

for (const n of [100, 1000, 10000, 100000, 1000000]) {
  if (n > MAX_N) break;
  const rnd = new Int32Array(n);
  let s = 12345;
  for (let i = 0; i < n; i++) {
    s = (Math.imul(s, 1664525) + 1013904223) >>> 0;
    rnd[i] = s % 1000000;
  }
  const asc = rnd.slice().sort();
  const desc = new Int32Array(n);
  for (let i = 0; i < n; i++) desc[i] = asc[n - 1 - i];
  const bases = [rnd, asc, desc];
  const a = new Int32Array(n);

  for (let t = 0; t < 3; t++) {
    for (const [nombre, fn, cuad] of ALGS) {
      if (omitir(cuad, n, t)) {
        w("JavaScript," + nombre + "," + n + "," + TIPOS[t] + ",,,,omitido\n");
        continue;
      }
      a.set(bases[t]);
      cmp = 0; mov = 0;
      const t0 = performance.now();
      fn(a, n);
      const t1 = performance.now();
      const ms = t1 - t0;
      let ok = true;
      for (let i = 1; i < n; i++) if (a[i - 1] > a[i]) { ok = false; break; }
      const tiempo = ms.toFixed(4);
      w("JavaScript," + nombre + "," + n + "," + TIPOS[t] + "," + tiempo + "," + cmp + "," + mov + "," + (ok ? "ok" : "ERROR") + "\n");
      console.log(nombre + " n=" + n + " " + TIPOS[t] + " " + tiempo + " ms");
    }
  }
}
fs.closeSync(fd);
console.log("Listo: resultados_javascript.csv");
