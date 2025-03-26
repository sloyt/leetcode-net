namespace leetcode_net.Problem.p3394;

public class Solution
{
    public bool CheckValidCuts(int n, int[][] rectangles)
    {
        int[][] intervalsX = new int [rectangles.Length][];
        int[][] intervalsY = new int [rectangles.Length][];

        for (int i = 0; i < rectangles.Length; i++)
        {
            intervalsX[i] = new []{ rectangles[i][0], rectangles[i][2] };
            intervalsY[i] = new []{ rectangles[i][1], rectangles[i][3] };
        }

        return HasTwoCuts(intervalsX, n) || HasTwoCuts(intervalsY, n);
    }

    private bool HasTwoCuts(int[][] intervals, int limit)
    {
        Array.Sort(intervals, (a, b) => a[0] - b[0] == 0 ? a[1] - b[1] : a[0] - b[0]);

        int cuts = 0;
        int prev = 0;

        foreach (int[] interval in intervals)
        {
            if (prev > 0 && interval[0] >= prev)
            {
                cuts += 1;
            }

            prev = interval[1];

            if (prev > limit) return false;
        }

        return cuts == 2;
    }
}
