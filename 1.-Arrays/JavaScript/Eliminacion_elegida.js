function eliminarPorIndice(lista, indice) {
  if (indice >= 0 && indice < lista.length) {
    return lista.splice(indice, 1)[0];
  }
  return null;
}

if (require.main === module) {
  const datos = [102, 58, 14, 87, 93, 26, 41, 75];
  const posicion = 3;

  console.log(`Lista original: [${datos.join(", ")}]`);
  const eliminado = eliminarPorIndice(datos, posicion);
  console.log(`Elemento eliminado en el índice ${posicion}: ${eliminado}`);
  console.log(`Lista después de la eliminación: [${datos.join(", ")}]`);
}

module.exports = { eliminarPorIndice };
