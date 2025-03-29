namespace leetcode_net.Problem.p2503;

public class Solution
{
    public int[] MaxPoints(int[][] grid, int[] queries)
    {
        var set = new SortedSet<int>(queries);
        var dict = new Dictionary<int, int>();
        
        var queue = new Queue<(int, int)>();
        var nextQueue = new Queue<(int, int)>();
        var visited = new bool[grid.Length, grid[0].Length];
        
        int counter = 0;

        queue.Enqueue((0, 0));
        
        foreach (int key in set)
        {
            while (queue.TryDequeue(out var point))
            {
                if (visited[point.Item1, point.Item2])
                {
                    continue;
                }
                
                if (key > grid[point.Item1][point.Item2])
                {
                    counter += 1;
                    visited[point.Item1, point.Item2] = true;
                    
                    // left
                    if (point.Item1 - 1 >= 0)
                    {
                        // if (!visited.Contains((point.Item1 - 1, point.Item2)))
                        // {
                            queue.Enqueue((point.Item1 - 1, point.Item2));
                        // }
                    }

                    // right
                    if (point.Item1 + 1 < grid.Length)
                    {
                        // if (!visited.Contains((point.Item1 + 1, point.Item2)))
                        // {
                            queue.Enqueue((point.Item1 + 1, point.Item2));
                        // }
                    }

                    // top
                    if (point.Item2 - 1 >= 0)
                    {
                        // if (!visited.Contains((point.Item1, point.Item2 - 1)))
                        // {
                            queue.Enqueue((point.Item1, point.Item2 - 1));
                        // }
                    }

                    // bottom
                    if (point.Item2 + 1 < grid[0].Length)
                    {
                        // if (!visited.Contains((point.Item1, point.Item2 + 1)))
                        // {
                            queue.Enqueue((point.Item1, point.Item2 + 1));
                        // }
                    }
                }
                else
                {
                    nextQueue.Enqueue(point);
                }
            }

            queue = nextQueue;
            nextQueue = new Queue<(int, int)>();

            dict.Add(key, counter);
        }

        int[] result = new int[queries.Length];

        for (int i = 0; i < queries.Length; i++)
        {
            result[i] = dict[queries[i]];
        }

        return result;
    }
}
