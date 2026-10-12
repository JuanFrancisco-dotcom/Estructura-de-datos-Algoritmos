def ordenar_por_filas(matriz):
    for i in range(len(matriz)):
        matriz[i].sort()


if __name__ == "__main__":
    matriz_2d = [
        [78, 12, 45],
        [89, 23, 34],
        [67, 11, 90]
    ]

    print("Matriz original:")
    for fila in matriz_2d:
        print(fila)

    ordenar_por_filas(matriz_2d)

    print("\nMatriz con cada fila ordenada:")
    for fila in matriz_2d:
        print(fila)