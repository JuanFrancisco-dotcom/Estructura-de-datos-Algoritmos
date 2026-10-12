def recorrido_matriz_2d(matriz):
    for i in range(len(matriz)):
        for j in range(len(matriz[i])):
            print(matriz[i][j], end=" ")
        print()


if __name__ == "__main__":
    matriz_2d = [
        [12, 45, 78],
        [34, 89, 23],
        [67, 90, 11]
    ]

    print("Recorrido de la matriz 2D:")
    recorrido_matriz_2d(matriz_2d)