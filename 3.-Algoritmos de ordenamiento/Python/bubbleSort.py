def bubble_sort(arr):
    # Función para ordenar una lista usando el algoritmo Bubble Sort
    n = len(arr)
    
    while True:
        swapped = False
        # Recorremos la lista desde el índice 1 hasta n-1
        for i in range(1, n):
            # Si el elemento anterior es mayor que el actual, intercambiamos
            if arr[i - 1] > arr[i]:
                arr[i - 1], arr[i] = arr[i], arr[i - 1] # Intercambio en Python
                swapped = True
        
        # Reducimos n porque el elemento más grande ya quedó al final de la iteración
        n -= 1
        
        # Si no hubo intercambios en esta pasada, la lista ya está ordenada
        if not swapped:
            break

# Ejemplo de uso
if __name__ == "__main__":
    lista = [12, 11, 13, 5, 6, 7]
    print("Antes de ordenar los elementos del array son: ", lista)
    bubble_sort(lista)
    print("\nDespués de ordenar el arreglo: ", lista)