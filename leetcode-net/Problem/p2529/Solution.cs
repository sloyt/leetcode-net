namespace leetcode_net.Problem.p2529;

public class Solution
{
    public int MaximumCount(int[] nums)
    {
        ushort? countNegative = null;
        ushort? countPositive = null;
        
        for (ushort i = 0; i < nums.Length; i++)
        {
            if (countNegative == null && nums[i] >= 0)
            {
                countNegative = i;
            }

            if (countPositive == null && nums[i] > 0)
            {
                countPositive = (ushort)(nums.Length - i);
            }

            if (countNegative != null && countPositive != null)
            {
                break;
            }
        }

        if (countNegative == null && nums.Length > 0) return nums.Length;
        
        return Math.Max(countNegative ?? 0, countPositive ?? 0);
    }
}
