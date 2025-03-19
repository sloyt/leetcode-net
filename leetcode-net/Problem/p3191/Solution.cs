namespace leetcode_net.Problem.p3191;

public class Solution
{
    public int MinOperations(int[] nums)
    {
        int result = 0;
        
        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (nums[i] == 0)
            {
                result += 1;
                nums[i + 1] = nums[i + 1] > 0 ? 0 : 1;
                nums[i + 2] = nums[i + 2] > 0 ? 0 : 1;
            }
        }

        if ((nums[^2] & nums[^1]) != 1)
        {
            result = -1;
        }

        return result;
    }
}
