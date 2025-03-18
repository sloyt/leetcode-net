using System;
using JetBrains.Annotations;
using leetcode_net.Problem.p2401;
using Xunit;

namespace leetcode_net.Tests.Problem.p2401;

[TestSubject(typeof(Solution))]
public class SolutionTest
{

    [Fact]
    public void LongestNiceSubarray()
    {
        Solution solution = new Solution();
        
        Assert.Equal(3, solution.LongestNiceSubarray([1,3,8,48,10]));
        Assert.Equal(1, solution.LongestNiceSubarray([3,1,5,11,13]));

        Assert.Equal(1, solution.LongestNiceSubarray([1]));
        Assert.Equal(2, solution.LongestNiceSubarray([1,2,3,4,5,6]));

        int[] arr = new int[(int)Math.Pow(10, 5)];
        for (int i = 0; i < arr.Length; i++) arr[i] = (int)Math.Pow(10, 9) - i * i;
        Assert.Equal(2, solution.LongestNiceSubarray(arr));

    }
}
