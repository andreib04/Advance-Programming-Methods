using System;

namespace Grafuri
{
    public class MyPoint
    {
        float X, Y;

        public static Random rnd = new Random();

        public MyPoint()
        {
            X = rnd.Next(800);
            Y = rnd.Next(600);
        }

        public Vertex ConvertToVertex(string name)
        {
            string data = name + " " + X.ToString() + " " + Y.ToString() + " 128 128 128"; 

            return new Vertex(data);
        } 
    }
}
