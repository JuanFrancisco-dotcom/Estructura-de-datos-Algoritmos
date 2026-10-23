function countingsort(arr, exp) {
  const s = arr.length;
  const outputArray = new Array(s).fill(0);
  const countArray = new Array(10).fill(0);
  for (let j = 0; j < s; j++) {
    const idx = Math.floor(arr[j] / exp);
    countArray[idx % 10] += 1;
  }
  for (let j = 1; j < 10; j++) {
    countArray[j] += countArray[j - 1];
  }
  let j = s - 1;
  while (j >= 0) {
    const idx = Math.floor(arr[j] / exp);
    outputArray[countArray[idx % 10] - 1] = arr[j];
    countArray[idx % 10] -= 1;
    j -= 1;
  }
  for (let k = 0; k < arr.length; k++) {
    arr[k] = outputArray[k];
  }
}

function radixSort(arr) {
  const max1 = Math.max(...arr);
  let exp = 1;
  while (max1 / exp >= 1) {
    countingsort(arr, exp);
    exp *= 10;
  }
}

if (require.main === module) {
  const arr = [171, 46, 76, 91, 803, 25, 3, 67];
  console.log("Arreglo antes de ordenar: ");
  for (let j = 0; j < arr.length; j++) process.stdout.write(arr[j] + " ");
  radixSort(arr);
  console.log("\nDespués de ordenar el arreglo: ");
  for (let j = 0; j < arr.length; j++) process.stdout.write(String(arr[j]));
}

module.exports = { radixSort };
