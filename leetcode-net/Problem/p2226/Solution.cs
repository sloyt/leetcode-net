namespace leetcode_net.Problem.p2226;

public class Solution
{
    public int MaximumCandies(int[] candies, long k) {
        int min = 1;
        int max = candies.Max();

        int result = 0;
        
        while (min <= max) {
            int median = min + (max - min) / 2;

            if (CanAllocateCandies(candies, median, k)) {
                result = median;
                min = median + 1;
            }
            else
            {
                max = median - 1;
            }
        }
        
        return result;
    }

    private bool CanAllocateCandies(int[] candies, int median, long k)
    {
        long totalChildren = 0;

        foreach (int pile in candies)
        {
            totalChildren += pile / median;
        }

        return totalChildren >= k;
    }
}
