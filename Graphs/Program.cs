

using Graphs;
using System.Runtime.InteropServices;

namespace Program
{
    class Program
    {
        private static void Main(string[] args)
        {
            Vertex vertex1 = new Vertex();
            vertex1.data = "A";
            Vertex vertex2 = new Vertex();
            vertex2.data = "B";
            Vertex vertex3 = new Vertex();
            vertex3.data = "C";
            Vertex vertex4 = new Vertex();
            vertex4.data = "D";
            Vertex vertex5 = new Vertex();
            vertex5.data = "E";
            Vertex vertex6 = new Vertex();
            vertex6.data = "F";
            Vertex vertex7 = new Vertex();
            vertex7.data = "G";
            Vertex vertex8 = new Vertex();
            vertex8.data = "H";
            Vertex vertex9 = new Vertex();
            vertex9.data = "I";
            Vertex vertex10 = new Vertex();
            vertex10.data = "J";


            Graph graph1 = new Graph();
            graph1.insert(vertex1, vertex1, 0);
            graph1.insert(vertex2, vertex1, 3);
            graph1.insert(vertex3, vertex1, 4);
            graph1.insert(vertex4, vertex1, 1);
            graph1.insert(vertex5, vertex3, 2);
            graph1.insert(vertex6, vertex3, 10);
            graph1.insert(vertex7, vertex2, 5);
            graph1.insert(vertex8, vertex4, 7);
            graph1.insert(vertex9, vertex8, 11);
            graph1.insert(vertex10, vertex9, 1);
            graph1.insert(vertex10, vertex6, 1);
            //graph1.insert(vertex10, vertex7, 6);
            
            //graph1.insert(vertex10, vertex9, 2);
            
            Console.WriteLine(" ");
            graph1.printVertexes();

            Console.WriteLine(" ");
            //graph1.delete("D");

            foreach (Edge i in vertex9.edges)
            {
                Console.WriteLine(i.weight + " " + i.vertexIni.data + " " + i.vertexEnd.data);
            }

            Console.WriteLine(" ");
            //foreach (Vertex i in vertex1.vertexes)
            //{
            //    Console.WriteLine(i.data);
            //}
            foreach (Edge i in vertex1.edges)
            {
                Console.WriteLine(i.weight + " " + i.vertexIni.data + " " + i.vertexEnd.data);
            }

            Console.WriteLine(" ");
            //foreach (Vertex i in vertex2.vertexes)
            //{
            //    Console.WriteLine(i.data);
            //}
            foreach (Edge i in vertex2.edges)
            {
                Console.WriteLine(i.weight + " " + i.vertexIni.data + " " + i.vertexEnd.data);
            }


            Console.WriteLine(" ");
            //foreach (Vertex i in vertex3.vertexes)
            //{
            //    Console.WriteLine(i.data);
            //}
            foreach (Edge i in vertex3.edges)
            {
                Console.WriteLine(i.weight + " " + i.vertexIni.data + " " + i.vertexEnd.data);
            }


            Console.WriteLine(" ");
            //foreach (Vertex i in vertex4.vertexes)
            //{
            //    Console.WriteLine(i.data);
            //}
            foreach (Edge i in vertex4.edges)
            {
                Console.WriteLine(i.weight + " " + i.vertexIni.data + " " + i.vertexEnd.data);
            }

            Console.WriteLine(" ");
            graph1.search("J");

            Console.WriteLine(" ");
            graph1.matrix();
            Console.WriteLine(" ");

            Console.WriteLine(" ");
            Console.WriteLine("BFS");
            graph1.bfs(vertex1);

            Console.WriteLine(" ");
            Console.WriteLine("DFS");
            graph1.dfs(vertex1);

            Console.WriteLine(" ");
            graph1.shortestPath(vertex10, vertex1);

            Console.WriteLine(" ");
            //graph1.shortestDistance(vertex9);

            //vertex1.addVertex(vertex1, vertex2, 1);
            //vertex1.addVertex(vertex1, vertex3, 2);

            //Console.WriteLine(vertex1.data);
            //Console.WriteLine(vertex2.data);
            //Console.WriteLine(vertex3.data);
            //Console.WriteLine("");

            //vertex1.select("C");

            //Console.WriteLine("");
            //foreach (Vertex i in vertex1.vertexes)
            //{
            //    Console.WriteLine(i.data);
            //}
            //Console.WriteLine("");
            //foreach (Edge i in vertex1.edges)
            //{
            //    Console.WriteLine(i.weight + " " + i.vertexIni.data + " " + i.vertexEnd.data);
            //}

            //Console.WriteLine("");
            //vertex1.removeVertex("C");

            //foreach (Vertex i in vertex1.vertexes)
            //{
            //    Console.WriteLine(i.data);
            //}
            //Console.WriteLine("");
            //foreach (Edge i in vertex1.edges)
            //{
            //    Console.WriteLine(i.weight + " " + i.vertexIni.data + " " + i.vertexEnd.data);
            //}
            //Console.WriteLine("");


        }


    }
}
