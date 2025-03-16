namespace leetcode_net.Problem.p2594;

public class Solution
{
    public long RepairCars(int[] ranks, int cars)
    {
        long left = 1;
        long right = ranks.Max() * (long)cars * (long)cars;
        long result = right;

        while (left <= right)
        {
            long median = left + (right - left) / 2;
            
            if (CanRepairCarsInNMinutes(ranks, cars, median))
            {
                result = median;
                right = median - 1L;
            }
            else
            {
                left = median + 1L;
            }
        }

        return result;
    }

    private bool CanRepairCarsInNMinutes(int[] ranks, int cars, long n)
    {
        bool canRepair = false;
        int carsLeft = cars;

        foreach (int rank in ranks)
        {
            carsLeft -= (int)Math.Sqrt(n / rank);

            if (carsLeft < 1)
            {
                canRepair = true;
                break;
            }
        }

        return canRepair;
    }
}
