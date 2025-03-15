namespace leetcode_net.Problem.p2560;

public class Solution
{
    public int MinCapability(int[] nums, int k)
    {
        int result = 0;

        void Traverse(int i, int prevMax, int bufCount)
        {
            if (bufCount < k)
            {
                for (int j = i + 2; j <= nums.Length - ((k - bufCount) * 2 - 1); j++)
                {
                    Traverse(j, nums[i] > prevMax ? nums[i] : prevMax, bufCount + 1);
                }
            }
            else
            {
                int currMin = Math.Max(nums[i], prevMax);
                
                if (result == 0 || currMin < result) result = currMin;
            }
        }

        for (int i = 0; i <= nums.Length - (k * 2 - 1); i++)
        {
            Traverse(i, 0, 1);
        }

        return result;
    }
}
