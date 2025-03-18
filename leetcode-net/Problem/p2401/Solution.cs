namespace leetcode_net.Problem.p2401;

public class Solution
{
    public int LongestNiceSubarray(int[] nums)
    {
        int result = 0;
        int left = 0;

        for (int right = 1; right < nums.Length; right++)
        {
            while (!IsNice(nums, left, right))
            {
                if (result < right - left)
                {
                    result = right - left;
                }

                left += 1;
            }
        }

        if (IsNice(nums, left, nums.Length - 1))
        {
            if (result < nums.Length - left)
            {
                result = nums.Length - left;
            }
        }

        return result;
    }
    
    private bool IsNice(int[] nums, int left, int right)
    {
        bool result = false;
        int prev = 0;
        

        for (int i = left; i <= right; i++)
        {
            result = (prev & nums[i]) == 0;
            
            if (result)
            {
                prev += nums[i];
            }
            else
            {
                break;
            }
            
            if (!result) break;
        }

        return result;
    }
}
