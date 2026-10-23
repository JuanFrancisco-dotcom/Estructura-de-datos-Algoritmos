function recorridoMatriz2D(matriz) {
  for (let i = 0; i < matriz.length; i++) {
    let linea = "";
    for (let j = 0; j < matriz[i].length; j++) {
      linea += `${matriz[i][j]} `;
    }
    console.log(linea);
  }
}

if (require.main === module) {
  const matriz2d = [
    [12, 45, 78],
    [34, 89, 23],
    [67, 90, 11],
  ];

  console.log("Recorrido de la matriz 2D:");
  recorridoMatriz2D(matriz2d);
}

module.exports = { recorridoMatriz2D };
