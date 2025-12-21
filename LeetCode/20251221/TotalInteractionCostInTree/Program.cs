using System;
using System.Collections.Generic;
using System.Linq;

// Examples
var s = new Solution();
// Console.WriteLine(s.InteractionCosts(3, new[] { new[] { 0, 1 }, new[] { 1, 2 } }, new[] { 1, 2, 1 })); // expected 2
// Console.WriteLine(s.InteractionCosts(4, new[] { new[] { 0, 1 }, new[] { 1, 2 }, new[] { 1, 3 } }, new[] { 1, 1, 1, 1 })); // expected 0 (all same group)
// Console.WriteLine(s.InteractionCosts(4, new[] { new[] { 0, 1 }, new[] { 1, 2 }, new[] { 1, 3 } }, new[] { 1, 2, 1, 2 })); // mixed groups

Console.WriteLine(s.InteractionCosts(3, new[] { new[] { 0, 1 }, new[] { 1, 2 } }, new[] { 1, 1, 1 }));


public class Solution
{
    // Sum of distances for all unordered pairs of nodes that are in different groups (uses group-pair map)
    public long InteractionCosts(int n, int[][] edges, int[] group)
    {
        var map = SumDistancesPerGroup(n, edges, group);
        long sum = 0;
        foreach (var v in map.Values) sum += v;
        return sum;
    }

    // Sum of distances between all unordered pairs of nodes within the same group.
    // For each edge, for each group g the number of pairs using that edge is cnt_in_child[g] * (nodesPerGroup[g] - cnt_in_child[g]).
    public Dictionary<int, long> SumDistancesPerGroup(int n, int[][] edges, int[] group)
    {
        if (n == 1)
        {
            var single = new Dictionary<int, long>
            {
                [group[0]] = 0
            };
            return single;
        }

        var adj = new List<int>[n];
        for (int i = 0; i < n; i++) adj[i] = [];
        foreach (var e in edges)
        {
            int u = e[0], v = e[1];
            adj[u].Add(v);
            adj[v].Add(u);
        }

        var nodesPerGroup = new Dictionary<int, int>();
        for (int i = 0; i < n; i++)
            nodesPerGroup[group[i]] = (nodesPerGroup.TryGetValue(group[i], out var t) ? t : 0) + 1;

        var result = new Dictionary<int, long>();
        foreach (var kv in nodesPerGroup) result[kv.Key] = 0L;

        Dictionary<int, int> Dfs(int u, int p)
        {
            var counts = new Dictionary<int, int>
            {
                [group[u]] = 1
            };
            foreach (var v in adj[u])
            {
                if (v == p) continue;
                var child = Dfs(v, u);

                // For every group present in child, add contribution across this edge
                foreach (var kv in child)
                {
                    int g = kv.Key;
                    int c = kv.Value;
                    result[g] = (result.TryGetValue(g, out var prev) ? prev : 0L) + (long)c * (nodesPerGroup[g] - c);
                }

                // small-to-large merge child -> counts
                if (child.Count > counts.Count)
                {
                    var tmp = counts;
                    counts = child;
                    child = tmp;
                }
                foreach (var kv in child)
                    counts[kv.Key] = (counts.TryGetValue(kv.Key, out var cv) ? cv : 0) + kv.Value;
            }
            return counts;
        }

        Dfs(0, -1);
        return result;
    }
}