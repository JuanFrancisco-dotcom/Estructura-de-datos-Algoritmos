import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

public class BucketSort {
    static void insertionSort(List<Double> bukt) {
        for (int j = 1; j < bukt.size(); j++) {
            double val = bukt.get(j);
            int k = j - 1;
            while (k >= 0 && bukt.get(k) > val) {
                bukt.set(k + 1, bukt.get(k));
                k -= 1;
            }
            bukt.set(k + 1, val);
        }
    }

    static void bucketSort(double[] inputArr) {
        int s = inputArr.length;
        List<List<Double>> bucketArr = new ArrayList<>();
        for (int i = 0; i < s; i++) bucketArr.add(new ArrayList<>());
        for (double j : inputArr) {
            int bi = (int) (s * j);
            bucketArr.get(bi).add(j);
        }
        for (List<Double> bukt : bucketArr) {
            insertionSort(bukt);
        }
        int idx = 0;
        for (List<Double> bukt : bucketArr) {
            for (double j : bukt) {
                inputArr[idx] = j;
                idx += 1;
            }
        }
    }

    static String unir(double[] a) {
        return Arrays.stream(a).mapToObj(Double::toString).collect(Collectors.joining(" "));
    }

    public static void main(String[] args) {
        double[] inputArr = {0.77, 0.16, 0.38, 0.25, 0.71, 0.93, 0.22, 0.11, 0.24, 0.67};
        System.out.println("Arreglo antes de ordenar:");
        System.out.println(unir(inputArr));
        bucketSort(inputArr);
        System.out.println("Arreglo después de ordenar:");
        System.out.println(unir(inputArr));
    }
}
