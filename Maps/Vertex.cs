using System.Drawing;

namespace Maps
{
    public class Vertex
    {
        public int value;
        public Point position;

        public Vertex(string data) 
        {
            string[] split = data.Split(' ');
            value = int.Parse(split[0]);
            position = new Point(int.Parse(split[1]), int.Parse(split[2]));
        }
    }
}
