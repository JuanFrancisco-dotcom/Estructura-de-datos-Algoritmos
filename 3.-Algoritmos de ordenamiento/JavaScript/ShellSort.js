class ShellSort {
  static displayArr(arr) {
    for (const k of arr) {
      process.stdout.write(k + " ");
    }
    console.log();
  }

  sort(arr) {
    const size = arr.length;
    let gapSize = Math.floor(size / 2);

    while (gapSize > 0) {
      for (let j = gapSize; j < size; j++) {
        const val = arr[j];
        let k = j;
        while (k >= gapSize && arr[k - gapSize] > val) {
          arr[k] = arr[k - gapSize];
          k -= gapSize;
        }
        arr[k] = val;
      }
      gapSize = Math.floor(gapSize / 2);
    }
  }
}

if (require.main === module) {
  const inputArr = [36, 34, 43, 11, 15, 20, 28, 45];

  console.log("Arreglo antes de ser ordenado:");
  ShellSort.displayArr(inputArr);

  const obj = new ShellSort();
  obj.sort(inputArr);

  console.log("\nArreglo después de ser ordenado:");
  ShellSort.displayArr(inputArr);
}

module.exports = { ShellSort };
