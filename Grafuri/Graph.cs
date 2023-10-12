using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Grafuri
{
    public class Graph
    {
        List<Vertex> vertices;
        List<Edge> edges;

        public Graph()
        {
            vertices = new List<Vertex>();
            edges = new List<Edge>();
        }

        public void Load(string fileName)
        {
            TextReader load = new StreamReader(fileName);
            int n = int.Parse(load.ReadLine());

            for (int i = 0; i < n; i++)
            {
                vertices.Add(new Vertex(load.ReadLine()));
            }
            string buffer;

            while ((buffer = load.ReadLine()) != null)
            {
                edges.Add(new Edge(buffer, vertices));
            }
        }

        public void Draw(Graphics graphics)
        {
            foreach(Edge edge in edges)
            {
                edge.Draw(graphics);
            }
            foreach(Vertex vertex in vertices)
            {
                vertex.Draw(graphics);
            }
        }
    }
}
