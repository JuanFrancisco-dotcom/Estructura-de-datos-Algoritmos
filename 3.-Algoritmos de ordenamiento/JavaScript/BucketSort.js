function insertionSort(bukt) {
  for (let j = 1; j < bukt.length; j++) {
    const val = bukt[j];
    let k = j - 1;
    while (k >= 0 && bukt[k] > val) {
      bukt[k + 1] = bukt[k];
      k -= 1;
    }
    bukt[k + 1] = val;
  }
}

function bucketSort(inputArr) {
  const s = inputArr.length;
  const bucketArr = Array.from({ length: s }, () => []);
  for (const j of inputArr) {
    const bi = Math.floor(s * j);
    bucketArr[bi].push(j);
  }
  for (const bukt of bucketArr) {
    insertionSort(bukt);
  }
  let idx = 0;
  for (const bukt of bucketArr) {
    for (const j of bukt) {
      inputArr[idx] = j;
      idx += 1;
    }
  }
}

if (require.main === module) {
  const inputArr = [0.77, 0.16, 0.38, 0.25, 0.71, 0.93, 0.22, 0.11, 0.24, 0.67];
  console.log("Arreglo antes de ordenar:");
  console.log(inputArr.join(" "));
  bucketSort(inputArr);
  console.log("Arreglo después de ordenar:");
  console.log(inputArr.join(" "));
}

module.exports = { bucketSort };
