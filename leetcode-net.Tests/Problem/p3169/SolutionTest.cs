using System;
using JetBrains.Annotations;
using leetcode_net.Problem.p3169;
using Xunit;

namespace leetcode_net.Tests.Problem.p3169;

[TestSubject(typeof(Solution))]
public class SolutionTest
{

    [Fact]
    public void CountDays()
    {
        Solution solution = new Solution();

        Assert.Equal(2, solution.CountDays(10, [[5, 7], [1, 3], [9, 10]]));
        Assert.Equal(1, solution.CountDays(5, [[2, 4], [1, 3]]));
        Assert.Equal(0, solution.CountDays(6, [[1, 6]]));
        Assert.Equal(1,
            solution.CountDays(57, [[3, 49], [23, 44], [21, 56], [26, 55], [23, 52], [2, 9], [1, 48], [3, 31]]));

        Assert.Equal(3, solution.CountDays(10, [[2, 4], [3, 5], [7, 9], [7, 8]]));
        Assert.Equal(2, solution.CountDays(10, [[2, 4], [3, 5], [7, 10], [7, 9], [7, 8], [7, 8]]));

        int[][] arr = new int[(int)Math.Pow(10, 5)][];
        int p = 0;

        for (int i = 0; i < (int)Math.Pow(10, 9); i++)
        {
            if (i % 3 == 0 && p < arr.Length)
            {
                arr[p++] = new int[] { i, i + 1 };
            }
        }

        Assert.Equal(999800001, solution.CountDays((int)Math.Pow(10, 9), arr));
    }
}
