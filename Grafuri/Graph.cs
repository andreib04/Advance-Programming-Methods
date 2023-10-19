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

        public bool[,] mA; //matrice de adiacenta

        public static Color[] defaultColors = new Color[] {Color.Violet, Color.Orange, Color.Red, Color.Blue, Color.Cyan, Color.Tan, Color.Pink, Color.Black};

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

            mA = new bool[n, n];
            for(int i = 0; i <edges.Count; i++)
            {
                int x = Idx(edges[i].begin.name);
                int y = Idx(edges[i].end.name);

                mA[x, y] = mA[y, x] = true;
            }
        }

        public int Idx(string name)
        {
            for(int i = 0; i < vertices.Count; i++)
            {
                if(name == vertices[i].name) 
                    return i;
            }

            return -1;
        }

        public List<string> debug()
        {
            List<string> toR = new List<string>();
            for(int i = 0; i < vertices.Count; i++)
            {
                string buffer = "";

                for(int j = 0; j<vertices.Count; j++)
                {
                    buffer += mA[i, j] + " ";
                }
                toR.Add(buffer);
            }
            return toR;
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

        public void GreedyColoring()
        {
            int n = vertices.Count();
            int[] colors = new int[n];

            for (int i = 0; i < n; i++)
                colors[i] = -1;

            colors[0] = 0;

            for(int i = 1; i < n; i++)
            {
                bool[] local = new bool[n];

                for(int j = 0; j < n; j++)
                {
                    if (mA[i, j])
                    {
                        if (colors[j] != -1)
                        {
                            local[colors[j]] = true;
                        }
                    }

                    int idx = 0;
                    while (local[idx]) 
                        idx++;

                    colors[i] = idx;
                }
            }

            for(int i = 0; i < n; i++)
            {
                vertices[i].fillColor = defaultColors[colors[i]];
            }
        }
    }
}
