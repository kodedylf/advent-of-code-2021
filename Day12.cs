using System;
using System.Collections.Generic;
using System.Linq;

namespace advent_of_code_2021
{
    internal class Day12
    {
        private Dictionary<string, List<string>> Nodes;
        private List<List<string>> Paths = new List<List<string>>();
        internal void Part1()
        {
            Nodes = BuildGraph();
            FindPaths("start", "end", new List<string>());
            System.Console.WriteLine(Paths.Count());
        }

        internal void Part2()
        {
            Nodes = BuildGraph();
            Paths = new List<List<string>>();
            FindPaths2("start", "end", new List<string>());
            System.Console.WriteLine(Paths.Count());
        }

        private void FindPaths(string tryNode, string end, List<string> path) {
            if (tryNode == tryNode.ToLower() && path.Contains(tryNode))
                return;
            if (tryNode == end) {
                Paths.Add(new List<string>(path).Append(tryNode).ToList());
            }
            else {
                var newPath = new List<string>(path).Append(tryNode).ToList();
                foreach (var connection in Nodes[tryNode]) {
                    FindPaths(connection, end, newPath);
                }
            }
        }

        private void FindPaths2(string tryNode, string end, List<string> path) {
            var smallCaveHasBeenVisitedTwice = path.Where(n => n == n.ToLower()).GroupBy(n => n).Any(g => g.Count() > 1);
            if (tryNode == "start" && path.Count() > 0) 
                return;
            if (smallCaveHasBeenVisitedTwice && tryNode == tryNode.ToLower() && path.Contains(tryNode))
                return;
            if (tryNode == end) {
                Paths.Add(new List<string>(path).Append(tryNode).ToList());
            }
            else {
                var newPath = new List<string>(path).Append(tryNode).ToList();
                foreach (var connection in Nodes[tryNode]) {
                    FindPaths2(connection, end, newPath);
                }
            }
        }

        private Dictionary<string, List<string>> BuildGraph() {
            var nodes = new Dictionary<string, List<string>>();
            foreach (var line in _data.Split("\r\n")) {
                var lineNodes = line.Split("-");
                foreach (var lineNode in lineNodes) {
                    if (!nodes.Keys.Contains(lineNode)) {
                        nodes[lineNode] = new List<string>();
                    }
                }
                nodes[lineNodes[0]].Add(lineNodes[1]);
                nodes[lineNodes[1]].Add(lineNodes[0]);
            }
            return nodes;
        }

        private class Node {
            public string Name {get;set;}
            public List<Node> Connections {get;set;} = new List<Node>();
        }

        private readonly string _data = @"vp-BY
ui-oo
kk-IY
ij-vp
oo-start
SP-ij
kg-uj
ij-UH
SP-end
oo-IY
SP-kk
SP-vp
ui-ij
UH-ui
ij-IY
start-ui
IY-ui
uj-ui
kk-oo
IY-start
end-vp
uj-UH
ij-kk
UH-end
UH-kk";
    }
}