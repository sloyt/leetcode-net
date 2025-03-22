using JetBrains.Annotations;
using leetcode_net.Problem.p2685;
using Xunit;

namespace leetcode_net.Tests.Problem.p2685;

[TestSubject(typeof(Solution))]
public class SolutionTest
{

    [Fact]
    public void CountCompleteComponents()
    {
        Solution solution = new Solution();

        Assert.Equal(3, solution.CountCompleteComponents(6, [[0, 1], [0, 2], [1, 2], [3, 4]]));
        Assert.Equal(1, solution.CountCompleteComponents(6, [[0, 1], [0, 2], [1, 2], [3, 4], [3, 5]]));

        Assert.Equal(6,
            solution.CountCompleteComponents(12, [[1, 3], [1, 2], [2, 3], [6, 7], [6, 8], [7, 8], [8, 10]]));
    }
}
