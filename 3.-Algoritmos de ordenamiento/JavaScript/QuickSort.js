function swap(a, j, k) {
  [a[j], a[k]] = [a[k], a[j]];
}

function partition(a, l, h) {
  const pvt = a[h];
  let j = l - 1;
  for (let k = l; k < h; k++) {
    if (a[k] < pvt) {
      j += 1;
      swap(a, j, k);
    }
  }
  swap(a, j + 1, h);
  return j + 1;
}

function qckSort(a, l, h) {
  if (l < h) {
    const pi = partition(a, l, h);
    qckSort(a, l, pi - 1);
    qckSort(a, pi + 1, h);
  }
}

if (require.main === module) {
  const a = [10, 7, 8, 9, 1, 5];
  const size = a.length;
  console.log("El arreglo antes de ordenarlo: ");
  for (const v of a) process.stdout.write(v + " ");
  console.log();
  qckSort(a, 0, size - 1);
  console.log("El arreglo después de ordenarlo: ");
  for (const v of a) process.stdout.write(v + " ");
}

module.exports = { qckSort };
