def busqueda_binaria(lista, elemento_buscado):
    inicio = 0
    fin = len(lista) - 1

    while inicio <= fin:
        medio = (inicio + fin) // 2

        if lista[medio] == elemento_buscado:
            return medio
        elif lista[medio] < elemento_buscado:
            inicio = medio + 1
        else:
            fin = medio - 1

    return -1


if __name__ == "__main__":
    datos = [14, 26, 41, 58, 75, 87, 93, 102]
    objetivo = 87

    posicion = busqueda_binaria(datos, objetivo)

    if posicion != -1:
        print(f"El elemento {objetivo} se encontró en el índice {posicion}.")
    else:
        print(f"El elemento {objetivo} no se encuentra en la lista.")