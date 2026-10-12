def eliminar_al_final(lista):
    if len(lista) > 0:
        return lista.pop()
    return None


if __name__ == "__main__":
    datos = [36, 34, 43, 11, 15, 20, 28, 45]

    print("Lista original:", datos)
    eliminado = eliminar_al_final(datos)
    print("Elemento eliminado:", eliminado)
    print("Lista después de eliminar al final:", datos)