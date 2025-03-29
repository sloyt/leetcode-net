namespace leetcode_net.Problem.p2503;

public class Solution
{
    public int[] MaxPoints(int[][] grid, int[] queries)
    {
        var indexedQueries = new int[queries.Length][];
        
        for (int i = 0; i < queries.Length; i++)
        {
            indexedQueries[i] = [queries[i], i];
        }
        
        Array.Sort(indexedQueries, (a, b) => a[0] - b[0]);
        
        var queue = new Queue<int[]>();
        var nextQueue = new Queue<int[]>();
        var visited = new bool[grid.Length, grid[0].Length];
        
        int counter = 0;
        int[] result = new int[queries.Length];

        queue.Enqueue([0, 0]);

        for (int i = 0; i < indexedQueries.Length; i++)
        {
            if (i > 0 && indexedQueries[i][0] == indexedQueries[i - 1][0])
            {
                continue;
            }
            
            while (queue.TryDequeue(out var point))
            {
                if (visited[point[0], point[1]])
                {
                    continue;
                }
                
                if (indexedQueries[i][0] > grid[point[0]][point[1]])
                {
                    counter += 1;
                    visited[point[0], point[1]] = true;
                    
                    // left
                    if (point[0] - 1 >= 0)
                    {
                        // if (!visited.Contains((point.Item1 - 1, point.Item2)))
                        // {
                        queue.Enqueue([point[0] - 1, point[1]]);
                        // }
                    }

                    // right
                    if (point[0] + 1 < grid.Length)
                    {
                        // if (!visited.Contains((point.Item1 + 1, point.Item2)))
                        // {
                        queue.Enqueue([point[0] + 1, point[1]]);
                        // }
                    }

                    // top
                    if (point[1] - 1 >= 0)
                    {
                        // if (!visited.Contains((point.Item1, point.Item2 - 1)))
                        // {
                        queue.Enqueue([point[0], point[1] - 1]);
                        // }
                    }

                    // bottom
                    if (point[1] + 1 < grid[0].Length)
                    {
                        // if (!visited.Contains((point.Item1, point.Item2 + 1)))
                        // {
                        queue.Enqueue([point[0], point[1] + 1]);
                        // }
                    }
                }
                else
                {
                    nextQueue.Enqueue(point);
                }
            }

            queue = nextQueue;
            nextQueue = new Queue<int[]>();

            result[indexedQueries[i][1]] = counter;
        }

        return result;
    }
}
