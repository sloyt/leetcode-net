namespace leetcode_net.Problem.p3169;

public class Solution
{
    public int CountDays(int days, int[][] meetings) {
        // sort array
        Array.Sort(meetings, (a, b) => a[0] - b[0] == 0 ? a[1] - b[1] : a[0] - b[0]);

        int result = 0;
        int lastMeeting = 0;

        foreach (int[] meeting in meetings)
        {
            // check there are free days
            if (meeting[0] - lastMeeting - 1 > 0)
            {
                // add them
                result += meeting[0] - lastMeeting - 1;
            }
            
            lastMeeting = meeting[1] > lastMeeting ? meeting[1] : lastMeeting;
        }

        if (days - lastMeeting > 0)
        {
            result += days - lastMeeting;
        }

        return result;
    }
}
