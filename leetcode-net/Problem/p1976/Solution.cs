namespace leetcode_net.Problem.p1976;

public class Solution
{
    class Node
    {
        public readonly int Value;
        public readonly Dictionary<Node, int> Neighbors;

        public Node(int value)
        {
            Value = value;
            Neighbors = new Dictionary<Node, int>();
        }

        public void AddNeighbor(Node neighbor, int weight)
        {
            Neighbors.Add(neighbor, weight);
        }
    }
    
    public readonly int Divider = (int)Math.Pow(10, 9) + 7; 
    
    public int CountPaths(int n, int[][] roads) {
        //
        // build graph
        
        Dictionary<int, Node> nodes = Enumerable.Range(0, n)
            .Select(x => (x, new Node(x)))
            .ToDictionary();

        foreach (int[] road in roads)
        {
            var node1 = nodes[road[0]];
            var node2 = nodes[road[1]];

            node1.AddNeighbor(node2, road[2]);
            node2.AddNeighbor(node1, road[2]);
        }

        var root = nodes[0];

        // prepare variables

        int pathCount = 0;
        long maxTime = long.MaxValue;
        
        var visited = new HashSet<int>();

        // dfs algorithm
        
        void Dfs(Node node, long time)
        {
            visited.Add(node.Value);
            
            // go deeper

            foreach (KeyValuePair<Node, int> neighbor in node.Neighbors)
            {
                if (!visited.Contains(neighbor.Key.Value))
                {
                    // check whether it is direct connection to final point

                    if (neighbor.Key.Value == n - 1)
                    {
                        // check timing to final point

                        if (time + neighbor.Value == maxTime)
                        {
                            pathCount = (pathCount + 1) % Divider;
                        }
                        else if (time + neighbor.Value < maxTime)
                        {
                            maxTime = time + neighbor.Value;
                            pathCount = 1;
                        }
                    }
                    else
                    {
                        // it is not direct connection
                        // check time would be less than maxTime
                        if (time + neighbor.Value < maxTime)
                        {
                            Dfs(neighbor.Key, time + neighbor.Value);
                        }
                    }
                }
            }

            visited.Remove(node.Value);
        }

        // run dfs
        
        visited.Add(root.Value);
        Dfs(root, 0);
        
        // end

        return pathCount;
    }
}
