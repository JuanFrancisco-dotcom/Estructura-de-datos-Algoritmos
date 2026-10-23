function busquedaBinaria(lista, elementoBuscado) {
  let inicio = 0;
  let fin = lista.length - 1;

  while (inicio <= fin) {
    const medio = Math.floor((inicio + fin) / 2);

    if (lista[medio] === elementoBuscado) {
      return medio;
    } else if (lista[medio] < elementoBuscado) {
      inicio = medio + 1;
    } else {
      fin = medio - 1;
    }
  }

  return -1;
}

if (require.main === module) {
  const datos = [14, 26, 41, 58, 75, 87, 93, 102];
  const objetivo = 87;

  const posicion = busquedaBinaria(datos, objetivo);

  if (posicion !== -1) {
    console.log(`El elemento ${objetivo} se encontró en el índice ${posicion}.`);
  } else {
    console.log(`El elemento ${objetivo} no se encuentra en la lista.`);
  }
}

module.exports = { busquedaBinaria };
