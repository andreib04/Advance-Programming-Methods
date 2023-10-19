using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafuri
{
    public class Edge
    {
        public Vertex begin;
        public Vertex end;

        public Edge(string data, List<Vertex> vertices)
        {
            string n1 = data.Split(' ')[0];
            string n2 = data.Split(' ')[1];

            foreach(Vertex vertex in vertices)
            {
                if(n1 == vertex.name)
                {
                    begin = vertex;
                }
                
                if(n2 == vertex.name)
                {
                    end = vertex;
                }
            }

           
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawLine(Pens.Red, begin.x, begin.y, end.x, end.y);
        }
    }
}
