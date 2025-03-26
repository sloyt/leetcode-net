namespace leetcode_net.Problem.p2033;

public class Solution
{
    public int MinOperations(int[][] grid, int x) {
        int[] arr = new int[grid.Length * grid[0].Length];
        int arrIdx = 0;
        int prev = 0;
        int diff;
        
        foreach (int[] cell in grid)
        {
            foreach (int i in cell)
            {
                if (prev > 0)
                {
                    diff = i - prev;

                    if (diff % x != 0) return -1;
                }

                arr[arrIdx++] = i;
                prev = i;
            }
        }
        
        Array.Sort(arr);

        int mid = arr.Length / 2;
        int diffLeft = 0;
        int diffRight = 0;

        int result = 0;
        
        for (int i = 1; i <= mid; i++)
        {
            diff = (arr[mid - i + 1] - arr[mid - i]) / x;
            result += diff + diffLeft;
            diffLeft = diff + diffLeft;

            if (mid + i < arr.Length)
            {
                diff = (arr[mid + i] - arr[mid + i - 1]) / x;
                result += diff + diffRight;
                diffRight = diff + diffRight;
            }
        }

        return result;
    }
}
