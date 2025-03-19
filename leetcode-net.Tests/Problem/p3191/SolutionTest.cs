using System;
using JetBrains.Annotations;
using leetcode_net.Problem.p3191;
using Xunit;

namespace leetcode_net.Tests.Problem.p3191;

[TestSubject(typeof(Solution))]
public class SolutionTest
{

    [Fact]
    public void MinOperations()
    {
        var solution = new Solution();

        Assert.Equal(3, solution.MinOperations([0, 1, 1, 1, 0, 0]));
        Assert.Equal(-1, solution.MinOperations([0, 1, 1, 1]));

        Assert.Equal(0, solution.MinOperations([1, 1, 1]));
        Assert.Equal(-1, solution.MinOperations([0, 1, 1]));
        Assert.Equal(-1, solution.MinOperations([1, 1, 0]));
        Assert.Equal(-1, solution.MinOperations([1, 1, 1, 0]));
        Assert.Equal(-1, solution.MinOperations([0, 1, 1, 1]));
        Assert.Equal(1, solution.MinOperations([1, 1, 1, 1, 0, 0, 0, 1]));

        int[] arr = new int[(int)Math.Pow(10, 5)];
        for (int i = 0; i < arr.Length; i++) arr[i] = i % 2;
        Assert.Equal(-1, solution.MinOperations(arr));
    }
}
