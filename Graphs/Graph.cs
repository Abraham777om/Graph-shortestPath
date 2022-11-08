using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class Graph
    {
        public Vertex root { get; set; }
        public List<Vertex> vertexes = new List<Vertex>();

        public void insert(Vertex vertex, Vertex onVertex, int wei)
        {
            if (root == null)
            {
                root = vertex;
                vertexes.Add(vertex);
            }
            else
            {
                Edge edge1 = new Edge();
                edge1.weight = wei;
                edge1.vertexIni = onVertex;
                edge1.vertexEnd = vertex;
                onVertex.edges.Add(edge1);

                //Edge edge2 = new Edge();
                //edge2.weight = wei;
                //edge2.vertexIni = vertex;
                //edge2.vertexEnd = onVertex;
                //vertex.edges.Add(edge1);

                onVertex.vertexes.Add(vertex);
                vertex.vertexes.Add(onVertex);

                int x = 0;
                foreach (Vertex v in vertexes)
                {
                    if (v.data.Equals(vertex.data))
                    {
                        x += 1;
                    }
                }
                if (x == 0)
                {
                    vertexes.Add(vertex);
                }
            }
        }
        public void delete(string data)
        {
            //foreach (Vertex v in vertexes)
            //{
            //    if (v.data.Equals(data))
            //    {
            //        v.vertexes.Clear();
            //        v.edges.Clear();
            //        vertexes.Remove(v);
            //    }
            //}

            for (int i = 0; i < vertexes.Count; i++)
            {
                if (vertexes[i].data.Equals(data))
                {
                    vertexes[i].vertexes.Clear();
                    vertexes[i].edges.Clear();
                    vertexes.Remove(vertexes[i]);
                }
            }
            foreach (Vertex v in vertexes)
            {
                foreach (Edge e in v.edges)
                {
                    if (e.vertexEnd.data.Equals(data))
                    {
                        v.edges.Remove(e);
                        break;
                    }
                }
            }
        }

        public void search(string data)
        {
            foreach (Vertex v in vertexes)
            {
                if (v.data.Equals(data))
                {
                    Console.WriteLine("Value found: " + v + " " + v.data);
                }
            }
            foreach (Vertex v in vertexes)
            {
                foreach (Edge e in v.edges)
                {
                    if (e.vertexIni.data.Equals(data) | e.vertexEnd.data.Equals(data))
                    {
                        Console.WriteLine("Edge: " + e.vertexIni.data + " " + e.vertexEnd.data);
                    }
                }
            }
        }
        public void printVertexes()
        {
            foreach (Vertex v in vertexes)
            {
                Console.WriteLine(v.data);
            }
        }


        public void matrix()
        {
            Console.Write(" ");
            for (int i = 0; i < vertexes.Count(); i++)
            {
                Console.Write(" " + vertexes[i].data);
            }
            for (int i = 0; i < vertexes.Count(); i++)
            {
                Console.WriteLine(" ");
                Console.Write(vertexes[i].data);
                for (int j = 0; j < vertexes.Count(); j++)
                {
                    //Console.WriteLine(vertexes[i].data + " " + vertexes[j].data);

                    if (vertexes[j].vertexes.Contains(vertexes[i]))
                    {
                        //Console.Write(vertexes[j].data);
                        //Console.WriteLine(" ");
                        Console.Write(" 1");
                    }
                    else
                    {
                        //Console.Write(vertexes[j].data);
                        //Console.WriteLine(" ");
                        Console.Write(" 0");
                    }
                }
            }
        }
        public void bfs(Vertex vertex)
        {

            List<Vertex> visited = new List<Vertex>();
            LinkedList<Vertex> queue = new LinkedList<Vertex>();
            visited.Add(vertex);
            queue.AddLast(vertex);

            while (queue.Count != 0)
            {
                vertex = queue.First();
                Console.WriteLine("next-> " + vertex.data);
                queue.RemoveFirst();

                foreach (Vertex v in vertex.vertexes)
                {
                    if (!visited.Contains(v))
                    {
                        visited.Add(v);
                        queue.AddLast(v);
                    }
                }
            }

        }
        public void dfs(Vertex vertex)
        {
            List<Vertex> visited = new List<Vertex>();
            Stack<Vertex> stack = new Stack<Vertex>();
            visited.Add(vertex);
            stack.Push(vertex);

            while (stack.Count != 0)
            {
                vertex = stack.Pop();
                Console.WriteLine("next-> " + vertex.data);
                foreach (Vertex v in vertex.vertexes)
                {
                    if (!visited.Contains(v))
                    {
                        visited.Add(v);
                        stack.Push(v);
                    }
                }
            }
        }


        public void shortestPath(Vertex vertex, Vertex vertexIni)
        {
            List<Vertex> path = new List<Vertex>();
            List<Vertex> path2 = new List<Vertex>();
            Stack<Vertex> stack = new Stack<Vertex>();
            Stack<Vertex> vers = new Stack<Vertex>();
            Vertex vertexs = vertex;

            //delete("I");

            foreach(Vertex v in vertex.vertexes)
            {
                vers.Push(v);
            }

            //Console.WriteLine(" ");
            path.Add(vertex);
            Vertex pred = vertex;
            stack.Push(vertex);
            

            while (stack.Count != 0)
            {
                vertex = stack.Pop();
                //Console.WriteLine("Vertex: " + vertex.data);
                //Console.WriteLine("Pred: " + pred.data);
                foreach (Vertex v in vertex.vertexes)
                {
                    //Console.WriteLine("V: " + v.data);
                    if (!path.Contains(v) && v.vertexes.Contains(pred))
                    {
                        pred = v;
                        stack.Push(v);
                        path.Add(v);
                        //Console.WriteLine(v.data);
                    }
                }
            }
            int sum = 0;
            List<Vertex> final = new List<Vertex>();

            foreach (Vertex v in path)
            {
                final.Add(v);
                //Console.WriteLine(v.data);
                if (v.data.Equals("A"))
                {
                    break;
                }
            }

            Console.WriteLine(" ");

            foreach (Vertex v in final)
            {
                foreach (Edge e in v.edges)
                {
                    if (final.Contains(e.vertexIni) && final.Contains(e.vertexEnd))
                    {
                        //Console.WriteLine(e.vertexIni.data + "-> " + e.weight + " <-" + e.vertexEnd.data);
                        sum += e.weight;
                    }

                }
            }
            //Console.WriteLine(" ");
            //Console.WriteLine(sum);
            //Console.WriteLine(" ");




            int sum2 = 0;
            List<Vertex> final2 = new List<Vertex>();

            if (vers.Count > 1)
            {
                //path.Clear();
                path2.Add(vertexs);
                vertex = vers.Pop();
                //Console.WriteLine("Vertex: " + vertex.data);

                path2.Add(vertex);
                pred = vertex;
                stack.Push(vertex);


                while (stack.Count != 0)
                {
                    vertex = stack.Pop();
                    //Console.WriteLine("Vertex: " + vertex.data);
                    //Console.WriteLine("Pred: " + pred.data);
                    foreach (Vertex v in vertex.vertexes)
                    {
                        //Console.WriteLine("V: " + v.data);
                        if (!path2.Contains(v) && v.vertexes.Contains(pred))
                        {
                            pred = v;
                            stack.Push(v);
                            path2.Add(v);
                            //Console.WriteLine(v.data);
                        }
                    }
                }
                foreach (Vertex v in path2)
                {
                    final2.Add(v);
                    //Console.WriteLine(v.data);
                    if (v.data.Equals("A"))
                    {
                        break;
                    }
                }

                Console.WriteLine(" ");
                foreach (Vertex v in final2)
                {
                    foreach (Edge e in v.edges)
                    {
                        if (final2.Contains(e.vertexIni) && final2.Contains(e.vertexEnd))
                        {
                            //Console.WriteLine(e.vertexIni.data + "-> " + e.weight + " <-" + e.vertexEnd.data);
                            sum2 += e.weight;
                        }

                    }
                }
            }



            Console.WriteLine(" ");
            if (sum < sum2)
            {
                foreach (Vertex v in path)
                {
                    //final.Add(v);
                    Console.WriteLine(v.data);
                    if (v.data.Equals("A"))
                    {
                        break;
                    }
                }

                Console.WriteLine(" ");

                foreach (Vertex v in final)
                {
                    foreach (Edge e in v.edges)
                    {
                        if (final.Contains(e.vertexIni) && final.Contains(e.vertexEnd))
                        {
                            Console.WriteLine(e.vertexIni.data + "-> " + e.weight + " <-" + e.vertexEnd.data);
                        }

                    }
                }
                Console.WriteLine(" ");
                Console.WriteLine(sum);
            }


            if (sum2 < sum)
            {
                foreach (Vertex v in path2)
                {
                    //final2.Add(v);
                    Console.WriteLine(v.data);
                    if (v.data.Equals("A"))
                    {
                        break;
                    }
                }
                
                Console.WriteLine(" ");
                foreach (Vertex v in final2)
                {
                    foreach (Edge e in v.edges)
                    {
                        if (final2.Contains(e.vertexIni) && final2.Contains(e.vertexEnd))
                        {
                            Console.WriteLine(e.vertexIni.data + "-> " + e.weight + " <-" + e.vertexEnd.data);
                        }

                    }
                }
                Console.WriteLine(" ");
                Console.WriteLine(sum2);
            }


            if (sum == sum2)
            {
                Console.WriteLine(sum + " " + sum2);
            }

        }
    }
}
