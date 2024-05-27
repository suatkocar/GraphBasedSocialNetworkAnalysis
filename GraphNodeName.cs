using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    public class GraphNodeName
    {
        private string name;
        private LinkedList<GraphNodeName> adjList;

        public GraphNodeName(string name)
        {
            this.name = name;
            this.adjList = new LinkedList<GraphNodeName>();
        }

        public string Name
        {
            get { return name; }
        }

        public void AddEdge(GraphNodeName to)
        {
            if (!adjList.Contains(to))
            {
                adjList.AddLast(to);
            }
        }

        public LinkedList<GraphNodeName> GetAdjList()
        {
            return adjList;
        }
    }
}