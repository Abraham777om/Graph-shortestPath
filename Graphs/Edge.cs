using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Graphs;

namespace Graphs
{
    internal class Edge
    {
        public int weight { get; set; }
        public Vertex vertexIni = new Vertex();
        public Vertex vertexEnd = new Vertex();


       
    }
}
