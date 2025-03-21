using JetBrains.Annotations;
using leetcode_net.Problem.p2115;
using Xunit;

namespace leetcode_net.Tests.Problem.p2115;

[TestSubject(typeof(Solution))]
public class SolutionTest
{

    [Fact]
    public void FindAllRecipes()
    {
        Solution solution = new Solution();

        Assert.Equal(
            ["bread"],
            solution.FindAllRecipes(
                ["bread"],
                [["yeast", "flour"]],
                ["yeast", "flour", "corn"]
            )
        );

        Assert.Equal(
            ["bread", "sandwich"],
            solution.FindAllRecipes(
                ["bread", "sandwich"],
                [["yeast", "flour"], ["bread", "meat"]],
                ["yeast", "flour", "meat"]
            )
        );

        Assert.Equal(
            ["bread", "sandwich", "burger"],
            solution.FindAllRecipes(
                ["bread", "sandwich", "burger"],
                [["yeast", "flour"], ["bread", "meat"], ["sandwich", "meat", "bread"]],
                ["yeast", "flour", "meat"]
            )
        );

        Assert.Equal(
            [],
            solution.FindAllRecipes(
                ["bread"],
                [["yeast", "flour"]],
                ["yeast"]
            )
        );

        Assert.Equal(
            ["ju", "fzjnm", "q"],
            solution.FindAllRecipes(
                ["ju", "fzjnm", "x", "e", "zpmcz", "h", "q"],
                [
                    ["d"], ["hveml", "f", "cpivl"], ["cpivl", "zpmcz", "h", "e", "fzjnm", "ju"],
                    ["cpivl", "hveml", "zpmcz", "ju", "h"], ["h", "fzjnm", "e", "q", "x"],
                    ["d", "hveml", "cpivl", "q", "zpmcz", "ju", "e", "x"], ["f", "hveml", "cpivl"]
                ],
                ["f", "hveml", "cpivl", "d"]
            )
        );
    }
}
