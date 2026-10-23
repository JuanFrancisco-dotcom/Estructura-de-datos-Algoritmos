function bubbleSort(arr) {
  let n = arr.length;

  while (true) {
    let swapped = false;
    for (let i = 1; i < n; i++) {
      if (arr[i - 1] > arr[i]) {
        [arr[i - 1], arr[i]] = [arr[i], arr[i - 1]];
        swapped = true;
      }
    }
    n -= 1;
    if (!swapped) break;
  }
}

if (require.main === module) {
  const lista = [12, 11, 13, 5, 6, 7];
  console.log(`Antes de ordenar los elementos del array son:  [${lista.join(", ")}]`);
  bubbleSort(lista);
  console.log(`\nDespués de ordenar el arreglo:  [${lista.join(", ")}]`);
}

module.exports = { bubbleSort };
