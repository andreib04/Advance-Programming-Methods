using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Grafuri
{
    public class Vertex
    {
        static int size = 20;
        public int x, y;
        public string name;


        public Color fillColor;
        public Vertex(string data)
        {
            string[] local = data.Split(' ');
            name = local[0];
            x = int.Parse(local[1]);
            y = int.Parse(local[2]);

            int R = int.Parse(local[3]);
            int G = int.Parse(local[4]);
            int B = int.Parse(local[5]);

            fillColor = Color.FromArgb(R, G, B);
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(Pens.Black, x - size, y - size, 2 * size + 1, 2 * size + 1);
            graphics.DrawString(name, new Font("Arial", 15, FontStyle.Bold), new SolidBrush(Color.White), new Point(x - size / 2, y - size / 2));//desenam numele
        }
    }
}
