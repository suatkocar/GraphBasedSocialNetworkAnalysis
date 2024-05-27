using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose graph type:");
                Console.WriteLine("1 - ID based graph");
                Console.WriteLine("2 - Name based graph");
                Console.WriteLine("3 - Exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        UseGraphID();
                        break;
                    case "2":
                        UseGraphName();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select an option from the menu.");
                        break;
                }
                Console.ReadKey(true);
            }
        }

        static void UseGraphID()
        {
            GraphID graphID = new GraphID();
            InitializeGraphID(graphID);

            
            Console.Write("Enter start node ID: ");
            int startId = int.Parse(Console.ReadLine());
            Console.Write("Enter target node ID: ");
            int targetId = int.Parse(Console.ReadLine());

            var bfsResult = graphID.BreadthFirstSearch(startId);
            Console.WriteLine($"BreadthFirstSearch result starting from node {startId}: " + String.Join(", ", bfsResult));

            bool canTraverse = graphID.CanTraverse(startId, targetId);
            Console.WriteLine($"Can traverse from {startId} to {targetId}: " + canTraverse);
        }

        static void UseGraphName()
        {
            GraphName graphName = new GraphName();
            InitializeGraphName(graphName);

            
            Console.Write("Enter start node name: ");
            string startName = Console.ReadLine();
            Console.Write("Enter target node name: ");
            string targetName = Console.ReadLine();

            var bfsResult = graphName.BreadthFirstSearch(startName);
            Console.WriteLine($"BreadthFirstSearch result starting from {startName}: " + String.Join(", ", bfsResult));

            bool canTraverse = graphName.CanTraverse(startName, targetName);
            Console.WriteLine($"Can traverse from {startName} to {targetName}: " + canTraverse);
        }

        static void InitializeGraphID(GraphID graphID)
        {
            Console.WriteLine("Graph is initially empty: " + (graphID.NodeCount() == 0));

            graphID.AddNode(1); // Dave
            graphID.AddNode(2); // Anwar
            graphID.AddNode(3); // Haniya
            graphID.AddNode(4); // Rob
            graphID.AddNode(5); // Peggy
            graphID.AddNode(6); // Rabia

            graphID.AddEdge(2, 1); // Anwar -> Dave
            graphID.AddEdge(2, 4); // Anwar -> Rob
            graphID.AddEdge(6, 2); // Rabia -> Anwar
            graphID.AddEdge(1, 5); // Dave -> Peggy
            graphID.AddEdge(5, 4); // Peggy -> Rob
            graphID.AddEdge(5, 6); // Peggy -> Rabia
            graphID.AddEdge(4, 3); // Rob -> Haniya

            Console.WriteLine("Graph Connections (ID Based):");
            graphID.DisplayConnections();

            Console.WriteLine("Total nodes: " + graphID.NodeCount());
            Console.WriteLine("Total edges: " + graphID.EdgeCount());
        }

        static void InitializeGraphName(GraphName graphName)
        {
            Console.WriteLine("Graph is initially empty: " + (graphName.NodeCount() == 0));

            graphName.AddNode("Dave");
            graphName.AddNode("Anwar");
            graphName.AddNode("Haniya");
            graphName.AddNode("Rob");
            graphName.AddNode("Peggy");
            graphName.AddNode("Rabia");

            graphName.AddEdge("Anwar", "Dave");
            graphName.AddEdge("Anwar", "Rob");
            graphName.AddEdge("Rabia", "Anwar");
            graphName.AddEdge("Dave", "Peggy");
            graphName.AddEdge("Peggy", "Rob");
            graphName.AddEdge("Peggy", "Rabia");
            graphName.AddEdge("Rob", "Haniya");

            Console.WriteLine("Graph Connections (Name Based):");
            graphName.DisplayConnections();

            Console.WriteLine("Total nodes: " + graphName.NodeCount());
            Console.WriteLine("Total edges: " + graphName.EdgeCount());
        }
    }
}