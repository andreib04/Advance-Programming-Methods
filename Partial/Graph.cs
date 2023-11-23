using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partial
{
    public class Graph
    {
        public List<Vertex> vertices;
        public List<Edge> edges;
        public int n;
    
        public Graph() 
        {
            vertices = new List<Vertex>();
            edges = new List<Edge>();
        }

        public List<Vertex> BFS()
        {
            n = vertices.Count;
            bool[] visited = new bool[n];

            Queue<Vertex> queue = new Queue<Vertex>();
            List<Vertex> solution = new List<Vertex>();
            visited[vertices.First().id] = true;

            queue.AddEnd(vertices.First());

            while(queue.n > 0)
            {
                Vertex current = queue.RemoveBeginning();
                solution.Add(current);

                foreach(Edge edge in edges)
                {
                    if(edge.start == current && !visited[edge.end.id])
                    {
                        queue.AddEnd(edge.end);
                        visited[edge.end.id] = true;
                    }
                    if (edge.end == current && !visited[edge.start.id])
                    {
                        queue.AddEnd(edge.start);
                        visited[edge.start.id] = true;
                    }
                }
            }

            return solution;
        }

        public void SaveToFile(string fileName)
        {
            n = vertices.Count();

            using (StreamWriter writer = new StreamWriter($"../../{fileName}"))
            {
                writer.WriteLine(n);

                for (int i = 0; i < n; i++)
                    writer.WriteLine(vertices[i].id + " " + vertices[i].value);

                for (int i = 0; i < edges.Count; i++)
                    writer.WriteLine(edges[i].start.id + " " + edges[i].end.id);
            }
        }
    }
}
