using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Graphs;

namespace Graphs
{
    internal class Vertex
    {
        public string data { get; set; }
        public List<Vertex> vertexes = new List<Vertex>();
        public List<Edge> edges = new List<Edge>();
        public bool visited { get; set; }
        public int distance { get; set; }

        public void addVertex(Vertex vertex1, Vertex vertex2, int wei)
        {
            Edge edge = new Edge();
            edge.weight = wei;
            edge.vertexIni = vertex1;
            edge.vertexEnd = vertex2;
            edges.Add(edge);
            vertexes.Add(vertex2);
        }

        public void removeVertex(string data)
        {
            Vertex av = new Vertex();
            Edge ev = new Edge();
            int x = 0;
            int y = 0;
            foreach (Vertex i in vertexes)
            {
                if (i.data.Equals(data))
                {
                    av = i;
                    x += 1;
                }
            }
            if (x != 0)
            {
                vertexes.Remove(av);
            }
            foreach (Edge e in edges)
            {
                if (e.vertexIni.data.Equals(data) | e.vertexEnd.data.Equals(data))
                {
                    ev = e;
                    y += 1;
                }
            }
            if (y != 0)
            {
                edges.Remove(ev);
            }
        }

        public void select(string data)
        {
            foreach (Vertex i in vertexes)
            {
                if (i.data.Equals(data))
                {
                    Console.WriteLine("Vertex: " + i + " " + i.data);
                }
            }
            foreach (Edge e in edges)
            {
                if (e.vertexIni.data.Equals(data) | e.vertexEnd.data.Equals(data))
                {
                    Console.WriteLine("Edge: " + e.vertexIni.data + " " + e.vertexEnd.data);
                }
            }
        }
        
    }
}
