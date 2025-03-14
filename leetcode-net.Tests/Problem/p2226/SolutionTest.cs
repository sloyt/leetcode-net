using System;
using JetBrains.Annotations;
using leetcode_net.Problem.p2226;
using Xunit;

namespace leetcode_net.Tests.Problem.p2226;

[TestSubject(typeof(Solution))]
public class SolutionTest
{

    [Fact]
    public void MaximumCandies()
    {
        var solution = new Solution();
        
        Assert.Equal(5, solution.MaximumCandies([5,8,6], 3));
        Assert.Equal(0, solution.MaximumCandies([2,5], 11));
        Assert.Equal(3, solution.MaximumCandies([4,7,5], 4));
        Assert.Equal(0, solution.MaximumCandies([10000000], 1000000000000));

        Assert.Equal(0, solution.MaximumCandies([1], 11));
        Assert.Equal(1, solution.MaximumCandies([1], 1));
        Assert.Equal(909090, solution.MaximumCandies([(int)Math.Pow(10, 7), 1], 11));
        Assert.Equal(0, solution.MaximumCandies([(int)Math.Pow(10, 7), 1], (int)Math.Pow(10, 12)));

        int[] arr = new int[(int)Math.Pow(10, 5)];
        for (int i = 0; i < arr.Length; i++) arr[i] = i % 2 == 0 ? (int)Math.Pow(10, 7) : 1;
        Assert.Equal(10000000, solution.MaximumCandies(arr, 11));
    }
}
