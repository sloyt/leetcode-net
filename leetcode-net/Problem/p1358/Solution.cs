namespace leetcode_net.Problem.p1358;

public class Solution
{
    public int NumberOfSubstrings(string s)
    {
        int result = 0;
        int[] count = [0, 0, 0];
        int left = 0;

        for (int right = 0; right < s.Length; right++)
        {
            switch (s[right])
            {
                case 'a': count[0] += 1; break;
                case 'b': count[1] += 1; break;
                case 'c': count[2] += 1; break;
            }

            while (count[0] > 0 && count[1] > 0 && count[2] > 0)
            {
                result += s.Length - right;
                
                switch (s[left])
                {
                    case 'a': count[0] -= 1; break;
                    case 'b': count[1] -= 1; break;
                    case 'c': count[2] -= 1; break;
                }

                left += 1;
            }
        }

        return result;
    }
}
