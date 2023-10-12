using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafuri
{
    public class Vertex
    {
        static int size = 20;
        public int x, y;
        public string name;

        public Vertex(string data)
        {
            string[] local = data.Split(' ');
            name = local[0];
            x = int.Parse(local[1]);
            y = int.Parse(local[2]);
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(Pens.Black, x - size, y - size, 2 * size + 1, 2 * size + 1);
        }
    }
}
