using JetBrains.Annotations;
using leetcode_net.Problem.p2379;
using Xunit;

namespace leetcode_net.Tests.Problem.p2379;

[TestSubject(typeof(Solution))]
public class SolutionTest
{

    [Fact]
    public void MinimumRecolors()
    {
        Solution solution = new Solution();
        
        Assert.Equal(3, solution.MinimumRecolors("WBBWWBBWBW", 7));
        Assert.Equal(0, solution.MinimumRecolors("WBWBBBW", 2));

        Assert.Equal(3, solution.MinimumRecolors("WWWWW", 3));
        Assert.Equal(0, solution.MinimumRecolors("BBBBB", 2));
        Assert.Equal(1, solution.MinimumRecolors("WBBWBWBBW", 3));
    }
}
