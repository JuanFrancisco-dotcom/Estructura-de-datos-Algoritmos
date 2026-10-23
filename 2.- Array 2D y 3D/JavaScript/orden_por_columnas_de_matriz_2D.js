function ordenarPorColumnas(matriz) {
  const filas = matriz.length;
  const columnas = matriz[0].length;

  for (let j = 0; j < columnas; j++) {
    // Extraemos la columna j
    const col = [];
    for (let i = 0; i < filas; i++) {
      col.push(matriz[i][j]);
    }
    col.sort((a, b) => a - b);
    // Reasignamos los valores ordenados de vuelta a la matriz
    for (let i = 0; i < filas; i++) {
      matriz[i][j] = col[i];
    }
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

  ordenarPorColumnas(matriz2d);

  console.log("\nMatriz con cada columna ordenada:");
  for (const fila of matriz2d) {
    console.log(`[${fila.join(", ")}]`);
  }
}

module.exports = { ordenarPorColumnas };
