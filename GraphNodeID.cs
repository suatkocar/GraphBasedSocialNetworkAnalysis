using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    public class GraphNodeID
    {
        private int id;
        private LinkedList<GraphNodeID> adjList;

        public GraphNodeID(int id)
        {
            this.id = id;
            this.adjList = new LinkedList<GraphNodeID>();
        }

        public int ID
        {
            get { return id; }
        }

        public void AddEdge(GraphNodeID to)
        {
            if (!adjList.Contains(to))
            {
                adjList.AddLast(to);
            }
        }

        public LinkedList<GraphNodeID> GetAdjList()
        {
            return adjList;
        }
    }
}