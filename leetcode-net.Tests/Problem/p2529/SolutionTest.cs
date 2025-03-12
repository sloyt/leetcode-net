using JetBrains.Annotations;
using leetcode_net.Problem.p2529;
using Xunit;

namespace leetcode_net.Tests.Problem.p2529;

[TestSubject(typeof(Solution))]
public class SolutionTest
{

    [Fact]
    public void MaximumCount()
    {
        Solution solution = new Solution();

        Assert.Equal(3, solution.MaximumCount([-2, -1, -1, 1, 2, 3]));
        Assert.Equal(3, solution.MaximumCount([-3, -2, -1, 0, 0, 1, 2]));
        Assert.Equal(4, solution.MaximumCount([5, 20, 66, 1314]));
        Assert.Equal(1, solution.MaximumCount([-1]));
    }
}