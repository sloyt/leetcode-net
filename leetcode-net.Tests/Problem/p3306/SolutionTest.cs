using JetBrains.Annotations;
using leetcode_net.Problem.p3306;
using Xunit;

namespace leetcode_net.Tests.Problem.p3306;

[TestSubject(typeof(Solution))]
public class SolutionTest
{

    [Fact]
    public void CountOfSubstrings()
    {
        Solution solution = new Solution();
        
        Assert.Equal(0, solution.CountOfSubstrings("aeioqq", 1));
        Assert.Equal(1, solution.CountOfSubstrings("aeiou", 0));
        Assert.Equal(3, solution.CountOfSubstrings("ieaouqqieaouqq", 1));
        Assert.Equal(2, solution.CountOfSubstrings("aadieuoh", 1));
        Assert.Equal(4, solution.CountOfSubstrings("aoaiuefi", 1));
        Assert.Equal(2, solution.CountOfSubstrings("aouiei", 0));
    }
}