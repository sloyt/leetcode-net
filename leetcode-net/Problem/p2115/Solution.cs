namespace leetcode_net.Problem.p2115;

public class Solution
{
    public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies) {
        var result = new List<string>();
        var suppliesSet = new HashSet<string>(supplies);
        var recipeMap = new Dictionary<string, List<string>>();
        var inDegree = new Dictionary<string, int>();
        
        for (int i = 0; i < recipes.Length; i++) {
            var recipe = recipes[i];
            inDegree[recipe] = 0;
            
            foreach (var ingredient in ingredients[i]) {
                if (!suppliesSet.Contains(ingredient)) {
                    if (!recipeMap.ContainsKey(ingredient)) {
                        recipeMap[ingredient] = new List<string>();
                    }
                    recipeMap[ingredient].Add(recipe);
                    inDegree[recipe]++;
                }
            }
        }
        
        var queue = new Queue<string>();

        foreach (var recipe in recipes) {
            if (inDegree[recipe] == 0) {
                queue.Enqueue(recipe);
            }
        }
        
        while (queue.Count > 0) {
            var recipe = queue.Dequeue();
            result.Add(recipe);
            
            if (recipeMap.ContainsKey(recipe)) {
                foreach (var dependentRecipe in recipeMap[recipe]) {
                    inDegree[dependentRecipe]--;
                    if (inDegree[dependentRecipe] == 0) {
                        queue.Enqueue(dependentRecipe);
                    }
                }
            }
        }
        
        return result;
    }
}
