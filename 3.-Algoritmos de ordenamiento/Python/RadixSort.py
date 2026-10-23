# Programa de Python para implementar Radix Sort
# Una función que ordena arr[] según el dígito representado por exp.
def countingsort(arr, exp):  # exp es 10^i donde i es el dígito actual
    s = len(arr)  # Tamaño del arreglo de entrada
    # El arreglo de salida que tendrá el arreglo ordenado
    # inicializando todos los elementos a 0
    outputArray = [0] * (s)  # array de tamaño s
    countArray = [0] * (10)  # array de conteo para dígitos (0-9)
    # almacenando el conteo de ocurrencias en countArray[]
    for j in range(0, s):  # j es el índice del arreglo de entrada
        idx = arr[j] // exp  # Obtener el dígito actual
        countArray[idx % 10] += 1  # Incrementar el conteo del dígito
    # Cambiar countArray[i] para que ahora contenga la posición real de este dígito en el arreglo de salida
    for j in range(1, 10):  # j es el índice del arreglo de conteo
        countArray[j] += countArray[j - 1]  # Acumular los conteos
    # Construir el arreglo de salida
    j = s - 1  # Índice del último elemento del arreglo de entrada
    while j >= 0:  # j es el índice del arreglo de entrada
        idx = arr[j] // exp  # Obtener el dígito actual
        outputArray[countArray[idx % 10] - 1] = arr[j]  # Colocar el elemento en la posición correcta
        countArray[idx % 10] -= 1  # Decrementar el conteo
        j -= 1  # Mover al siguiente elemento
    # Copiar el arreglo de salida a arr[],
    # Por lo tanto, arr ahora contiene números en ordenados
    j = 0  # Índice para el arreglo de entrada
    for j in range(0, len(arr)):  # j es el índice del arreglo de entrada
        arr[j] = outputArray[j]  # Copiar el elemento al arreglo de entrada
        arr[j] = outputArray[j]  # Copiar el elemento al arreglo de entrada
# Método principal para implementar Radix Sort
def radixSort(arr):  # La función principal que ordena arr[] usando Radix Sort
    # Obtener el número máximo para saber el número de dígitos
    max1 = max(arr)  # Encontrar el valor máximo en el arreglo
    # Hacer un conteo de ordenamiento para cada dígito.
    # Aplicando counting sort para cada dígito.
    # en lugar de enviar un número de dígito, se envía exp.
    # Obtener el número máximo para saber el número de dígitos
    exp = 1  # Exponente inicial (10^0)
    while max1 / exp >= 1:  # Mientras queden dígitos por procesar
        countingsort(arr, exp)  # Ordenar según el dígito actual
        exp *= 10  # Mover al siguiente dígito
# Ejemplo de uso
arr = [171, 46, 76, 91, 803, 25, 3, 67]  # Arreglo de entrada
print("Arreglo antes de ordenar: ")  # Imprimir arreglo antes de ordenar
for j in range(len(arr)):  # j es el índice del arreglo
    print("%d" % arr[j], end=" ")  # Imprimir elementos del arreglo
# Llamar a la función de ordenamiento Radix
radixSort(arr)  # Llamar a la función de ordenamiento Radix
print("\nDespués de ordenar el arreglo: ")
for j in range(len(arr)):  # j es el índice del arreglo
    print("%d" % arr[j], end="")  # Imprimir elementos del arreglo ordenado# Imprimir el arreglo ordenado