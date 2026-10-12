def insertar_al_inicio(lista, nuevo_elemento):
    lista.insert(0, nuevo_elemento)


if __name__ == "__main__":
    datos = [36, 34, 43, 11, 15, 20, 28, 45]
    nuevo = 99

    print("Lista original:", datos)
    insertar_al_inicio(datos, nuevo)
    print("Lista con inserción al inicio:", datos)