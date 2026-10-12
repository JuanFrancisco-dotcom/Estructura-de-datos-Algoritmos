def eliminar_por_indice(lista, indice):
    if 0 <= indice < len(lista):
        return lista.pop(indice)
    return None


if __name__ == "__main__":
    datos = [102, 58, 14, 87, 93, 26, 41, 75]
    posicion = 3

    print("Lista original:", datos)
    eliminado = eliminar_por_indice(datos, posicion)
    print(f"Elemento eliminado en el índice {posicion}:", eliminado)
    print("Lista después de la eliminación:", datos)