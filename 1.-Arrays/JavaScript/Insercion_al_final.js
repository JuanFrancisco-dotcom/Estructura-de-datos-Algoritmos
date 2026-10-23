function insertarAlFinal(lista, nuevoElemento) {
  lista.push(nuevoElemento);
}

if (require.main === module) {
  const datos = [36, 34, 43, 11, 15, 20, 28, 45];
  const nuevo = 99;

  console.log(`Lista original: [${datos.join(", ")}]`);
  insertarAlFinal(datos, nuevo);
  console.log(`Lista con inserción al final: [${datos.join(", ")}]`);
}

module.exports = { insertarAlFinal };
