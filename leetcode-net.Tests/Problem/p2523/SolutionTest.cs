using JetBrains.Annotations;
using leetcode_net.Problem.p2523;
using Xunit;

namespace leetcode_net.Tests.Problem.p2523;

[TestSubject(typeof(Solution))]
public class SolutionTest
{
    [Fact]
    public void ClosestPrimes()
    {
        var solution = new Solution();

        Assert.Equal(
            new int[] { 11, 13 },
            solution.ClosestPrimes(10, 19)
        );
        Assert.Equal(
            new int[] { -1, -1 },
            solution.ClosestPrimes(4, 6)
        );
        Assert.Equal(
            new int[] { 29, 31 },
            solution.ClosestPrimes(19, 31)
        );
        Assert.Equal(
            new int[] { 12917, 12919 },
            solution.ClosestPrimes(12854, 130337)
        );
        Assert.Equal(
            new int[] { 628937, 628939 },
            solution.ClosestPrimes(628853, 801856)
        );
        Assert.Equal(
            new int[] { 2, 3 },
            solution.ClosestPrimes(1, 1000000)
        );
    }
}
