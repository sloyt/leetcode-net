namespace leetcode_net.Problem.p2523;

public class Solution
{
    public int[] ClosestPrimes(int left, int right)
    {
        // find all prime numbers up to right inclusive
        // - optimized for sqrt(right)
        var basicPrimes = FindPrimesUpToSqrtOf(right);
        
        // left only primes between left and right
        var leftPrimes = FindPrimesBetween(left > 1 ? left : 2, right, basicPrimes);

        var iter = leftPrimes.GetEnumerator();

        // find first number
        while (iter.MoveNext() && iter.Current < left) ;

        // if there're no two numbers under condition of: left <= num1 < num2 <= right
        // don't wast time, return
        if (iter.Current < left || iter.Current + 1 > right)
        {
            return new int[] { -1, -1 };
        }

        var num1 = iter.Current;
        var diff = int.MaxValue;
        var prev = num1;

        // find second number satisfying conditions
        while (iter.MoveNext() && iter.Current <= right)
        {
            if (iter.Current - prev < diff)
            {
                num1 = prev;
                diff = iter.Current - prev;
            }

            prev = iter.Current;
        }

        return diff != int.MaxValue
            ? new int[] { num1, num1 + diff }
            : new int[] { -1, -1 };
    }

    private List<int> FindPrimesUpToSqrtOf(int last)
    {
        var primeNumbers = new List<int> { 2 };
        
        for (int i = 3; i <= Math.Sqrt(last); i += 2)
        {
            bool isPrime = true;

            foreach (var num in primeNumbers)
            {
                if (i % num == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime) primeNumbers.Add(i);
        }

        return primeNumbers;
    }

    private List<int> FindPrimesBetween(int left, int right, List<int> primeNumbers)
    {
        List<int> leftPrimeNumbers = new List<int>();
        
        for (int i = left; i <= right; i++)
        {
            bool isPrime = true;

            foreach (var num in primeNumbers)
            {
                if (i == num)
                {
                    // it is prime by itself
                    break;
                }
                
                if (i % num == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime) leftPrimeNumbers.Add(i);
        }

        return leftPrimeNumbers;
    }
}
