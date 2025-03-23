namespace leetcode_net.Problem.p1976;

public class Solution
{
    public readonly int Divider = (int)Math.Pow(10, 9) + 7; 
    
    public int CountPaths(int n, int[][] roads) {
        //
        // build graph
        
        int[][][] graph = new int[n][][];

        foreach (int[] road in roads)
        {
            if (graph[road[0]] == default)
            {
                graph[road[0]] = [[road[1], road[2]]];
            }
            else
            {
                Array.Resize(ref graph[road[0]], graph[road[0]].Length + 1);
                graph[road[0]][graph[road[0]].Length - 1] = [road[1], road[2]];
            }
            
            if (graph[road[1]] == default)
            {
                graph[road[1]] = [[road[0], road[2]]];
            }
            else
            {
                Array.Resize(ref graph[road[1]], graph[road[1]].Length + 1);
                graph[road[1]][graph[road[1]].Length - 1] = [road[0], road[2]];
            }
        }

        // prepare variables

        int pathCount = 0;
        long maxTime = long.MaxValue;

        var visited = new int[n];

        // dfs algorithm
        
        void Dfs(int nodeIndex, long time)
        {
            visited[nodeIndex] = 1;
            
            // go deeper

            foreach (int[] neighbor in graph[nodeIndex])
            {
                if (visited[neighbor[0]] == 0)
                {
                    // check whether it is direct connection to final point

                    if (neighbor[0] == n - 1)
                    {
                        // check timing to final point

                        if (time + neighbor[1] == maxTime)
                        {
                            pathCount = (pathCount + 1) % Divider;
                        }
                        else if (time + neighbor[1] < maxTime)
                        {
                            maxTime = time + neighbor[1];
                            pathCount = 1;
                        }
                    }
                    else
                    {
                        // it is not direct connection
                        // check time would be less than maxTime
                        if (time + neighbor[1] < maxTime)
                        {
                            Dfs(neighbor[0], time + neighbor[1]);
                        }
                    }
                }
            }

            visited[nodeIndex] = 0;
        }

        // run dfs
        
        visited[0] = 1;
        Dfs(0, 0);
        
        // end

        return pathCount;
    }
}
