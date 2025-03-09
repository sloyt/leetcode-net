using JetBrains.Annotations;
using leetcode_net.Problem.p3208;
using Xunit;

namespace leetcode_net.Tests.Problem.p3208;

[TestSubject(typeof(Solution))]
public class SolutionTest
{

    [Fact]
    public void NumberOfAlternatingGroups()
    {
        Solution solution = new Solution();

        Assert.Equal(3, solution.NumberOfAlternatingGroups(new[] { 0, 1, 0, 1, 0 }, 3));
        Assert.Equal(2, solution.NumberOfAlternatingGroups(new[] { 0, 1, 0, 0, 1, 0, 1 }, 6));
        Assert.Equal(0, solution.NumberOfAlternatingGroups(new[] { 1, 1, 0, 1 }, 4));
    }
}