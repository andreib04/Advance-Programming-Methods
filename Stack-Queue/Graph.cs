using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Queue
{
    public class Graph
    {
        public List<Vertex> vertices;
        public List<Edge> edges;
        
        public Graph()
        {
            vertices = new List<Vertex>();
            edges = new List<Edge>();
        }
        public void Load(string data)
        {
            TextReader reader = new StreamReader(data);
            int n = int.Parse(reader.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Vertex local = new Vertex();
                local.idx = i;
                vertices.Add(local);
            }
            string buffer = "";
            while ((buffer = reader.ReadLine()) != null)
                edges.Add(new Edge(buffer, vertices));

        }
       
        public void Draw(Graphics handler)
        {
            foreach (Edge edge in edges)
                edge.Draw(handler);
            foreach (Vertex vertex in vertices)
                vertex.Draw(handler);
        }
       

        public void Dispersion(PointF center, float radius)
        {
            float alpha = (float)(Math.PI * 2) / vertices.Count;

            for(int i = 0; i < vertices.Count; i++)
            {
                float x = center.X + (float)Math.Cos(alpha * i) * radius;
                float y = center.Y + (float)Math.Sin(alpha * i) *radius;
                vertices[i].location = new PointF(x, y);
            }
        }

        public List<Vertex> BFS(Vertex start)
        {
            List<Vertex> toR = new List<Vertex>();

            myQueue<Vertex> myQueue = new myQueue<Vertex>();
            bool[] visited = new bool[vertices.Count];
            visited[start.idx] = true;
            myQueue.Push(start);
            while (!(myQueue.IsEmpty()))
            {
                Vertex t = myQueue.Pop();
                toR.Add(t);
                foreach(Edge edge in edges)
                {
                    if(edge.start == t || edge.end == t)
                    {
                        Vertex x;
                        if(edge.start == t)
                        {
                            x = edge.end;
                        }
                        else
                        {
                            x = edge.start;
                        }

                        if (!(visited[x.idx]))
                        {
                            myQueue.Push(x);
                            visited[x.idx] = true;
                        }
                    }
                }
            }

            return toR;
        }

        public List<Vertex> DFS(Vertex start)
        {
            List<Vertex> toR = new List<Vertex>();

            myStack<Vertex> myStack = new myStack<Vertex>();
            bool[] visited = new bool[vertices.Count];
            visited[start.idx] = true;
            myStack.Push(start);
            while (!(myStack.IsEmpty()))
            {
                Vertex t = myStack.Pop();
                toR.Add(t);
                foreach (Edge edge in edges)
                {
                    if (edge.start == t || edge.end == t)
                    {
                        Vertex x;
                        if (edge.start == t)
                        {
                            x = edge.end;
                        }
                        else
                        {
                            x = edge.start;
                        }

                        if (!(visited[x.idx]))
                        {
                            myStack.Push(x);
                            visited[x.idx] = true;
                        }
                    }
                }
            }

            return toR;
        }
    }
}
