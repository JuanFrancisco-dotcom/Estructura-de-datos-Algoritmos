function ordenarPorFilas(matriz) {
  for (let i = 0; i < matriz.length; i++) {
    matriz[i].sort((a, b) => a - b);
  }
}

if (require.main === module) {
  const matriz2d = [
    [78, 12, 45],
    [89, 23, 34],
    [67, 11, 90],
  ];

  console.log("Matriz original:");
  for (const fila of matriz2d) {
    console.log(`[${fila.join(", ")}]`);
  }

  ordenarPorFilas(matriz2d);

  console.log("\nMatriz con cada fila ordenada:");
  for (const fila of matriz2d) {
    console.log(`[${fila.join(", ")}]`);
  }
}

module.exports = { ordenarPorFilas };
