using System;
using JetBrains.Annotations;
using leetcode_net.Problem.p2560;
using Xunit;

namespace leetcode_net.Tests.Problem.p2560;

[TestSubject(typeof(Solution))]
public class SolutionTest
{

    [Fact]
    public void MinCapability()
    {
        Solution solution = new Solution();
        
        Assert.Equal(5, solution.MinCapability([2,3,5,9], 2));
        Assert.Equal(2, solution.MinCapability([2,7,9,3,1], 2));

        Assert.Equal(1, solution.MinCapability([2,7,9,3,1], 1));

        int[] arr = new int[(int)Math.Pow(10, 5)];
        for (int i = 0; i < arr.Length; i++) arr[i] = i % 2 == 0 ? (int)Math.Pow(10, 9) : 1;
        Assert.Equal(1, solution.MinCapability(arr, 5));

    }
}
