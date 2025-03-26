using JetBrains.Annotations;
using leetcode_net.Problem.p3394;
using Xunit;

namespace leetcode_net.Tests.Problem.p3394;

[TestSubject(typeof(Solution))]
public class SolutionTest
{

    [Fact]
    public void CheckValidCuts()
    {
        Solution solution = new Solution();

        Assert.True(solution.CheckValidCuts(5, [[1, 0, 5, 2], [0, 2, 2, 4], [3, 2, 5, 3], [0, 4, 4, 5]]));
        Assert.True(solution.CheckValidCuts(4, [[0, 0, 1, 1], [2, 0, 3, 4], [0, 2, 2, 3], [3, 0, 4, 3]]));
        Assert.False(solution.CheckValidCuts(4,
            [[0, 2, 2, 4], [1, 0, 3, 2], [2, 2, 3, 4], [3, 0, 4, 2], [3, 2, 4, 4]]));
    }
}
