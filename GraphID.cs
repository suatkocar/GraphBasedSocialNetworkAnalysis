using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    public class GraphID
    {
        private LinkedList<GraphNodeID> nodes;

        public GraphID()
        {
            this.nodes = new LinkedList<GraphNodeID>();
        }

        public void AddNode(int id)
        {
            if (!nodes.Any(n => n.ID == id))
            {
                nodes.AddLast(new GraphNodeID(id));
            }
        }

        public GraphNodeID GetNodeByID(int id)
        {
            return nodes.FirstOrDefault(n => n.ID == id);
        }

        public void AddEdge(int fromId, int toId)
        {
            GraphNodeID fromNode = GetNodeByID(fromId);
            GraphNodeID toNode = GetNodeByID(toId);
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

        public List<int> BreadthFirstSearch(int startId)
        {
            var startNode = GetNodeByID(startId);
            if (startNode == null) return new List<int>();

            var visited = new HashSet<GraphNodeID>();
            var queue = new Queue<GraphNodeID>();
            var visitedOrder = new List<int>();

            queue.Enqueue(startNode);
            visited.Add(startNode);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                visitedOrder.Add(node.ID);
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

        public bool CanTraverse(int fromId, int toId)
        {
            var fromNode = GetNodeByID(fromId);
            var toNode = GetNodeByID(toId);
            if (fromNode == null || toNode == null) return false;

            var visited = new HashSet<GraphNodeID>();
            var queue = new Queue<GraphNodeID>();
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
                string connections = String.Join(", ", node.GetAdjList().Select(x => x.ID));
                Console.WriteLine($"{node.ID} -> {connections}");
            }
        }
    }
}