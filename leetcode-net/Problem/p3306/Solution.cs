namespace leetcode_net.Problem.p3306;

public class Solution
{
    public long CountOfSubstrings(string word, int k)
    {
        return F(word, k) - F(word, k + 1);
    }

    private long F(string word, int k)
    {
        long result = 0;
        int left = 0;
        int consonants = 0;
        Dictionary<char, int> vowels = new Dictionary<char, int>();

        for (int right = 0; right < word.Length; right++)
        {
            if (IsVowel(word[right]))
            {
                if (vowels.ContainsKey(word[right])) vowels[word[right]] += 1;
                else vowels.Add(word[right], 1);
            }
            else
            {
                consonants += 1;
            }

            while (consonants >= k && vowels.Count == 5)
            {
                char ch = word[left++];

                if (IsVowel(ch))
                {
                    if (vowels[ch] > 1) vowels[ch] -= 1;
                    else vowels.Remove(ch);
                }
                else
                {
                    consonants -= 1;
                }
            }

            result += left;
        }

        return result;
    }
    
    private bool IsVowel(char ch) => ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u';
}
