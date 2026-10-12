class ShellSort:
    # Función de utilidad para imprimir una lista
    @staticmethod
    def display_arr(arr):
        for k in arr:
            print(k, end=" ")
        print()

    # Función para ordenar arr usando Shell Sort
    def sort(self, arr):
        size = len(arr)
        # Comienza con un intervalo (gap) grande y luego lo reduce
        gap_size = size // 2

        while gap_size > 0:
            for j in range(gap_size, size):
                val = arr[j]
                k = j
                while k >= gap_size and arr[k - gap_size] > val:
                    arr[k] = arr[k - gap_size]
                    k -= gap_size
                arr[k] = val
            gap_size //= 2


if __name__ == "__main__":
    input_arr = [36, 34, 43, 11, 15, 20, 28, 45]

    print("Arreglo antes de ser ordenado:")
    ShellSort.display_arr(input_arr)

    obj = ShellSort()
    obj.sort(input_arr)

    print("\nArreglo después de ser ordenado:")
    ShellSort.display_arr(input_arr)