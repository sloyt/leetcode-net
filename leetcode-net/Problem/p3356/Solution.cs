namespace leetcode_net.Problem.p3356;

public class Solution
{
    public int MinZeroArray(int[] nums, int[][] queries)
    {
        int left = 0;
        int right = queries.Length;
        
        int result = -1;
        
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            
            if (IsMakingZero(nums, queries, mid))
            {
                result = mid;
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return result;
    }
    
    bool IsMakingZero(int[] nums, int[][] queries, int k)
    {
        int n = nums.Length;
        int[] diff = new int[n + 1];
            
        for (int i = 0; i < k; i++)
        {
            int li = queries[i][0];
            int ri = queries[i][1];
            int vali = queries[i][2];

            diff[li] += vali;
            
            if (ri + 1 < n) diff[ri + 1] -= vali;
        }

        int currentDecrement = 0;
        int[] current = (int[])nums.Clone();
        
        for (int i = 0; i < n; i++)
        {
            currentDecrement += diff[i];
            current[i] -= currentDecrement;

            if (current[i] > 0) return false;
        }

        return true;
    }
}
