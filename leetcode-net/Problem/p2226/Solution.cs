namespace leetcode_net.Problem.p2226;

public class Solution
{
    public int MaximumCandies(int[] candies, long k)
    {
        int min = 0;
        int max = candies.Max();

        int result = 0;

        // check if we can get k piles with median

        while (true)
        {
            int median = (min + max) / 2;

            if (CanGetPiles(candies, k, median))
            {
                result = median;

                if (min != median)
                {
                    min = median;
                }
                else if (min != max)
                {
                    min += 1;
                }
                else
                {
                    break;
                }
            }
            else
            {
                if (max != median)
                {
                    max = median;
                }
                else
                {
                    break;
                }
            }
        }

        return result;
    }

    private bool CanGetPiles(int[] candies, long k, int median)
    {
        if (median == 0) return true;
        
        long piles = 0;

        foreach (int num in candies)
        {
            if (num >= median)
            {
                int mod = num;

                do
                {
                    mod -= median;
                    piles += 1;
                } while (mod >= median && piles < k);
            }

            if (piles == k) break;
        }

        return piles == k;
    }
}
