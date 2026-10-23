function eliminarAlInicio(lista) {
  if (lista.length > 0) {
    return lista.shift();
  }
  return null;
}

if (require.main === module) {
  const datos = [36, 34, 43, 11, 15, 20, 28, 45];

  console.log(`Lista original: [${datos.join(", ")}]`);
  const eliminado = eliminarAlInicio(datos);
  console.log(`Elemento eliminado: ${eliminado}`);
  console.log(`Lista después de eliminar al inicio: [${datos.join(", ")}]`);
}

module.exports = { eliminarAlInicio };
