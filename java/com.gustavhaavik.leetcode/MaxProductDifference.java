import java.util.Arrays;

public class MaxProductDifference {
    public MaxProductDifference() {
        int[] nums = { 5, 6, 2, 7, 4 };
        System.out.println("Max product difference of " + Arrays.toString(nums));
        System.out.println(maxProductDifference(nums));
    }

    public int maxProductDifference(int[] nums) {
        int max = Integer.MIN_VALUE, secondMax = Integer.MIN_VALUE;
        int min = Integer.MAX_VALUE, secondMin = Integer.MAX_VALUE;

        for (int num : nums) {
            if (num > max) {
                secondMax = max;
                max = num;
            } else if (num > secondMax) {
                secondMax = num;
            }

            if (num < min) {
                secondMin = min;
                min = num;
            } else if (num < secondMin) {
                secondMin = num;
            }
        }

        return (max * secondMax) - (min * secondMin);
    }
}