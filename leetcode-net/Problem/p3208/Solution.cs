namespace leetcode_net.Problem.p3208;

public class Solution
{
    public int NumberOfAlternatingGroups(int[] colors, int k)
    {
        int result = 0;
        int buf = 0;

        for (int i = 0; i < colors.Length + k - 1; i++)
        {
            if (i == 0)
            {
                buf += 1;
            }
            else
            {
                int idx1 = i >= colors.Length ? i - colors.Length : i;
                int idx2 = idx1 - 1 < 0 ? colors.Length - 1 : idx1 - 1;
                
                buf = colors[idx1] != colors[idx2]
                    ? buf + 1
                    : 1;
            }

            if (buf >= k)
            {
                result += 1;
            }
        }

        return result;
    }
}
