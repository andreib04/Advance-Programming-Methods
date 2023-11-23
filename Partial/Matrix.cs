using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partial
{
    public class Matrix
    {
        public string[,] matrix;
        public int n, m;

        public Matrix()
        {
            n = 3; m = 4;
            matrix = new string[,]
            {
                {"1", "2", "3", "4"},
                {"5", "☺", "-1", "6"},
                {"7", "-1", "2", "9"}
            };
        }

        public Graph ToGraph()
        {
            Graph graph = new Graph();

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    graph.vertices.Add(new Vertex(i * m + j, matrix[i,j]));
                }
            }

            for(int i = 0; i < n * m; i++)
            {
                int row = (i + 1) / m;

                if(row == i / m)
                {
                    graph.edges.Add(new Edge(graph.vertices[i], graph.vertices[i + 1]));
                }

                if(i + m < n * m)
                {
                    graph.edges.Add(new Edge(graph.vertices[i], graph.vertices[i + m]));
                }
            }

            return graph;
        }
    }
}
