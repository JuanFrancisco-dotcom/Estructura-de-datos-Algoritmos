function recorridoMatriz3D(matriz) {
  for (let i = 0; i < matriz.length; i++) {
    console.log(`Capa ${i}:`);
    for (let j = 0; j < matriz[i].length; j++) {
      let linea = "";
      for (let k = 0; k < matriz[i][j].length; k++) {
        linea += `${matriz[i][j][k]} `;
      }
      console.log(linea);
    }
    console.log();
  }
}

if (require.main === module) {
  const matriz3d = [
    [
      [12, 45, 78],
      [34, 89, 23],
    ],
    [
      [67, 90, 11],
      [55, 82, 44],
    ],
  ];

  console.log("Recorrido de la matriz 3D:\n");
  recorridoMatriz3D(matriz3d);
}

module.exports = { recorridoMatriz3D };
