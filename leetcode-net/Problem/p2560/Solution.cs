namespace leetcode_net.Problem.p2560;

public class Solution
{
    public int MinCapability(int[] nums, int k)
    {
        int left = 1;
        int right = nums.Max();
        
        int result = right;
        
        while (left <= right)
        {
            int median = left + (right - left) / 2;
            
            if (CanRobAtLeastKHouses(nums, median, k))
            {
                result = median;
                right = median - 1;
            }
            else
            {
                left = median + 1;
            }
        }
        
        return result;
    }
    
    private bool CanRobAtLeastKHouses(int[] nums, int cap, int k)
    {
        int count = 0;
        int prev = -1;
        
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] <= cap && (prev < 0 || i - prev > 1))
            {
                count++;
                prev = i;
            }
            
            if (count >= k)
            {
                return true;
            }
        }
        
        return false;
    }
}
