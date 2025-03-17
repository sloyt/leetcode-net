namespace leetcode_net.Problem.p2206;

public class Solution
{
    public bool DivideArray(int[] nums) {
        Dictionary<int, bool> dict = new Dictionary<int, bool>();

        foreach (int num in nums)
        {
            bool value = false;

            dict.TryGetValue(num, out value);
            
            dict[num] = !value;
        }

        return !dict.Values.Any(x => x);
    }
}
