using JetBrains.Annotations;
using leetcode_net.Problem.p2033;
using Xunit;

namespace leetcode_net.Tests.Problem.p2033;

[TestSubject(typeof(Solution))]
public class SolutionTest
{

    [Fact]
    public void MinOperations()
    {
        Solution solution = new Solution();
        
        Assert.Equal(4, solution.MinOperations(new[] { new[] { 2, 4 }, new[] { 6, 8 } }, 2));
        Assert.Equal(5, solution.MinOperations(new[] { new[] { 1, 5 }, new[] { 2, 3 } }, 1));
        Assert.Equal(-1, solution.MinOperations(new[] { new[] { 1, 2 }, new[] { 3, 4 } }, 2));
    }
}
