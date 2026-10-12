def ordenar_por_columnas(matriz):
    filas = len(matriz)
    columnas = len(matriz[0])

    for j in range(columnas):
        # Extraemos la columna j
        col = [matriz[i][j] for i in range(filas)]
        col.sort()
        # Reasignamos los valores ordenados de vuelta a la matriz
        for i in range(filas):
            matriz[i][j] = col[i]


if __name__ == "__main__":
    matriz_2d = [
        [78, 12, 45],
        [89, 23, 34],
        [67, 11, 90]
    ]

    print("Matriz original:")
    for fila in matriz_2d:
        print(fila)

    ordenar_por_columnas(matriz_2d)

    print("\nMatriz con cada columna ordenada:")
    for fila in matriz_2d:
        print(fila)