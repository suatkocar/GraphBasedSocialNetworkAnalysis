using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    public class GraphName
    {
        private LinkedList<GraphNodeName> nodes;

        public GraphName()
        {
            this.nodes = new LinkedList<GraphNodeName>();
        }

        public void AddNode(string name)
        {
            if (!nodes.Any(n => n.Name == name))
            {
                nodes.AddLast(new GraphNodeName(name));
            }
        }

        public GraphNodeName GetNodeByName(string name)
        {
            return nodes.FirstOrDefault(n => n.Name == name);
        }

        public void AddEdge(string fromName, string toName)
        {
            GraphNodeName fromNode = GetNodeByName(fromName);
            GraphNodeName toNode = GetNodeByName(toName);
            if (fromNode != null && toNode != null)
            {
                fromNode.AddEdge(toNode);
            }
        }

        public int NodeCount()
        {
            return nodes.Count;
        }

        public int EdgeCount()
        {
            return nodes.Sum(node => node.GetAdjList().Count);
        }

        public List<string> BreadthFirstSearch(string startName)
        {
            var startNode = GetNodeByName(startName);
            if (startNode == null) return new List<string>();

            var visited = new HashSet<GraphNodeName>();
            var queue = new Queue<GraphNodeName>();
            var visitedOrder = new List<string>();

            queue.Enqueue(startNode);
            visited.Add(startNode);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                visitedOrder.Add(node.Name);
                foreach (var neighbor in node.GetAdjList())
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
            return visitedOrder;
        }

        public bool CanTraverse(string fromName, string toName)
        {
            var fromNode = GetNodeByName(fromName);
            var toNode = GetNodeByName(toName);
            if (fromNode == null || toNode == null) return false;

            var visited = new HashSet<GraphNodeName>();
            var queue = new Queue<GraphNodeName>();
            queue.Enqueue(fromNode);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node == toNode) return true;

                foreach (var neighbor in node.GetAdjList())
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
            return false;
        }

        public void DisplayConnections()
        {
            foreach (var node in nodes)
            {
                string connections = String.Join(", ", node.GetAdjList().Select(x => x.Name));
                Console.WriteLine($"{node.Name} -> {connections}");
            }
        }

    }
}