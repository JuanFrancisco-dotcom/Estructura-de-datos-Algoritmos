function busquedaSecuencialInversa(lista, elementoBuscado) {
  for (let i = lista.length - 1; i >= 0; i--) {
    if (lista[i] === elementoBuscado) {
      return i;
    }
  }
  return -1;
}

if (require.main === module) {
  const datos = [36, 34, 43, 11, 15, 20, 28, 45];
  const objetivo = 20;

  const posicion = busquedaSecuencialInversa(datos, objetivo);

  if (posicion !== -1) {
    console.log(`El elemento ${objetivo} se encontró en el índice ${posicion}.`);
  } else {
    console.log(`El elemento ${objetivo} no se encuentra en la lista.`);
  }
}

module.exports = { busquedaSecuencialInversa };
