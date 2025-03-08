namespace leetcode_net.Problem.p2379;

public class Solution
{
    private const char Black = 'B';
    private const char White = 'W';
    
    public int MinimumRecolors(string blocks, int k)
    {
        int[,] dp = new int[blocks.Length + 1, k + 1];
        int max = 0;

        for (int i = 0; i < blocks.Length + 1; i++)
        {
            for (int j = 0; j < k + 1; j++)
            {
                if (i == 0 || j == 0)
                {
                    dp[i, j] = 0;
                }
                else
                {
                    if (blocks[i - 1] == Black)
                    {
                        dp[i, j] += dp[i - 1, j - 1] + 1;
                        max = Math.Max(max, dp[i, j]);
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                }
            }
        }
        
        return max > k ? 0 : k - max;
    }
}
