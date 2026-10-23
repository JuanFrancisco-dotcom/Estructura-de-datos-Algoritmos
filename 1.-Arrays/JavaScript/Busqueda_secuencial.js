function busquedaSecuencial(lista, elementoBuscado) {
  for (let i = 0; i < lista.length; i++) {
    if (lista[i] === elementoBuscado) {
      return i;
    }
  }
  return -1;
}

if (require.main === module) {
  const datos = [102, 58, 14, 87, 93, 26, 41, 75];
  const objetivo = 87;

  const posicion = busquedaSecuencial(datos, objetivo);

  if (posicion !== -1) {
    console.log(`El elemento ${objetivo} se encontró en el índice ${posicion}.`);
  } else {
    console.log(`El elemento ${objetivo} no se encuentra en la lista.`);
  }
}

module.exports = { busquedaSecuencial };
