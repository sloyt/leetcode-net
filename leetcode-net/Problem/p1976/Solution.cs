namespace leetcode_net.Problem.p1976;

public class Solution
{
    public readonly int Divider = (int)Math.Pow(10, 9) + 7;
    
    public int CountPaths(int n, int[][] roads) {
        //
        // build graph
        
        List<List<(int node, long time)>> graph = new List<List<(int, long)>>();
        
        for (int i = 0; i < n; i++) {
            graph.Add(new List<(int, long)>());
        }
        
        foreach (var road in roads) {
            graph[road[0]].Add((road[1], road[2]));
            graph[road[1]].Add((road[0], road[2]));
        }
        
        // prepare values
        
        var bestTimes = new long[n];
        var repeats = new int[n];
        var queue = new PriorityQueue<(int node, long time), long>();
        
        // Dijkstra's algorithm

        repeats[0] = 1;
        queue.Enqueue((0, 0), 0);
        
        while (queue.Count > 0) {
            var (node, time) = queue.Dequeue();
            
            // if there is shorter path, skip
            if (time > bestTimes[node]) continue;
            
            // process all neighbors
            foreach (var (nextNode, nextTime) in graph[node])
            {
                long newTime = time + nextTime;

                // check whether we found a new shortest path
                if (bestTimes[nextNode] == 0 || newTime < bestTimes[nextNode])
                {
                    bestTimes[nextNode] = newTime;
                    repeats[nextNode] = repeats[node];
                    queue.Enqueue((nextNode, newTime), newTime);
                }
                else if (newTime == bestTimes[nextNode])
                {
                    repeats[nextNode] = (repeats[nextNode] + repeats[node]) % Divider;
                }
            }
        }
        
        // end
        
        return repeats[n - 1];
    }
}
