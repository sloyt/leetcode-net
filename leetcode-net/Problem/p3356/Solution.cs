namespace leetcode_net.Problem.p3356;

public class Solution
{
    public int MinZeroArray(int[] nums, int[][] queries)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0) map[i] = nums[i];
        }

        int currIndex = 0;
        int maxSteps = map.Count > 0 ? -1 : 0;

        for (; currIndex < queries.Length && maxSteps < 0; currIndex++)
        {
            for (int j = queries[currIndex][0]; j <= queries[currIndex][1]; j++)
            {
                if (map.ContainsKey(j))
                {
                    if (map[j] - queries[currIndex][2] > 0)
                    {
                        map[j] -= queries[currIndex][2];
                    }
                    else
                    {
                        map.Remove(j);
                        maxSteps = currIndex + 1;
                    }
                }
            }

            if (maxSteps > 0 && map.Count > 0)
            {
                maxSteps = -1;
            }
        }

        return maxSteps;
    }
}
