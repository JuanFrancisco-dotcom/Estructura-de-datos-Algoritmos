def selection(a): # funcion para implementar el algoritmo de selección
    for i in range(len(a)):# recorre todo el arreglo
        small = i # indice del elemento más pequeño
        for j in range(i+1, len(a)): # encuentra el elemento más pequeño en el arreglo
            if a[small] > a[j]: # compara el elemento más pequeño con el siguiente elemento
                small = j # actualiza el indice del elemento más pequeño
        # intercambia el elemento más pequeño con el primer elemento
        a[i], a[small] = a[small], a[i]    # intercambia los elementos

def printArr(a): # funcion para imprimir el array
    for i in range(len(a)):    # recorre todo el arreglo
        print (a[i], end = " ") # imprime el elemento

a = [65, 26, 13, 23, 12]    # arreglo desordenado
print("Arrelo antes de ser ordenado: ")
printArr(a)
selection(a)
print("\nnArreglo después de ser ordenado: ")
selection(a)
printArr(a)