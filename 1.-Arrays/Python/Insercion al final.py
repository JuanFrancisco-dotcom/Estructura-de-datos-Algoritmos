def insertar_al_final(lista, nuevo_elemento):
    lista.append(nuevo_elemento)


if __name__ == "__main__":
    datos = [36, 34, 43, 11, 15, 20, 28, 45]
    nuevo = 99

    print("Lista original:", datos)
    insertar_al_final(datos, nuevo)
    print("Lista con inserción al final:", datos)