def recorrido_matriz_3d(matriz):
    for i in range(len(matriz)):
        print(f"Capa {i}:")
        for j in range(len(matriz[i])):
            for k in range(len(matriz[i][j])):
                print(matriz[i][j][k], end=" ")
            print()
        print()


if __name__ == "__main__":
    matriz_3d = [
        [
            [12, 45, 78],
            [34, 89, 23]
        ],
        [
            [67, 90, 11],
            [55, 82, 44]
        ]
    ]

    print("Recorrido de la matriz 3D:\n")
    recorrido_matriz_3d(matriz_3d)