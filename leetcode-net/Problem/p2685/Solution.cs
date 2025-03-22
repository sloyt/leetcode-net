namespace leetcode_net.Problem.p2685;

public class Solution
{
    public int CountCompleteComponents(int n, int[][] edges) {
        Dictionary<int, HashSet<int>> graph = new Dictionary<int, HashSet<int>>();
        
        // build graph

        foreach (int[] edge in edges)
        {
            var node1 = graph.ContainsKey(edge[0])
                ? graph[edge[0]]
                : graph[edge[0]] = new HashSet<int>();
            
            var node2 = graph.ContainsKey(edge[1])
                ? graph[edge[1]]
                : graph[edge[1]] = new HashSet<int>();
            
            node1.Add(edge[1]);
            node2.Add(edge[0]);
        }

        int result = 0;
        
        // for nodes in graph, check if all neighbors are connected
        
        HashSet<int> visited = new HashSet<int>();
        
        HashSet<int> locals = new HashSet<int>();
        Queue<int> queue = new Queue<int>();
        bool isConnected;
        bool isAddToLocals;

        for (int i = 0; i < n; i ++)
        {
            if (!graph.ContainsKey(i))
            {
                // no edges here, count & continue
                result += 1;
                continue;
            }

            if (visited.Contains(i))
            {
                // already visited, ignore
                continue;
            }
            
            // prepare local variables
            
            isConnected = true;
            locals.Clear();
            
            // put first vertex in queue
            
            queue.Enqueue(i);
            visited.Add(i);
            locals.Add(i);

            isAddToLocals = true;
            
            // check all vertices in queue
            
            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                
                foreach (int neighbor in graph[current])
                {
                    if (isAddToLocals)
                    {
                        // first vertex, add neighbor to locals
                        locals.Add(neighbor);
                    }
                    else
                    {
                        // check if neighbor is in locals
                        if (!locals.Contains(neighbor))
                        {
                            // oops, not connected
                            isConnected = false;
                        }
                    }

                    if (visited.Contains(neighbor))
                    {
                        continue;
                    }
                    
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }

                if (isAddToLocals)
                {
                    // clear flag
                    isAddToLocals = false;
                }
                else if (isConnected)
                {
                    // extra check - vertex count should be the same as in locals - 1
                    // go it after traversing neighbors to add all in visited and ignore next time
                    if (graph[current].Count + 1 != locals.Count)
                    {
                        isConnected = false;
                    }
                }
            }

            if (isConnected)
            {
                // all neighbors are connected
                result += 1;
            }
        }
        
        return result;
    }
}
