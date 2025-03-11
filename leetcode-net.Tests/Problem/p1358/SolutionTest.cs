using JetBrains.Annotations;
using leetcode_net.Problem.p1358;
using Xunit;

namespace leetcode_net.Tests.Problem.p1358;

[TestSubject(typeof(Solution))]
public class SolutionTest
{

    [Fact]
    public void NumberOfSubstrings()
    {
        Solution solution = new Solution();
        
        Assert.Equal(10, solution.NumberOfSubstrings("abcabc"));
        Assert.Equal(3, solution.NumberOfSubstrings("aaacb"));
        Assert.Equal(1, solution.NumberOfSubstrings("abc"));
        Assert.Equal(9, solution.NumberOfSubstrings("cabcac"));
        Assert.Equal(0, solution.NumberOfSubstrings("aab"));
    }
}
