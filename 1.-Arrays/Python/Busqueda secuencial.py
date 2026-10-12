def busqueda_secuencial(lista, elemento_buscado):
    for i in range(len(lista)):
        if lista[i] == elemento_buscado:
            return i
    return -1


if __name__ == "__main__":
    datos = [102, 58, 14, 87, 93, 26, 41, 75]
    objetivo = 87

    posicion = busqueda_secuencial(datos, objetivo)

    if posicion != -1:
        print(f"El elemento {objetivo} se encontró en el índice {posicion}.")
    else:
        print(f"El elemento {objetivo} no se encuentra en la lista.")