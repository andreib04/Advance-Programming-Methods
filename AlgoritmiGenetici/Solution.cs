using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmiGenetici
{
    public class Solution
    {
        public List<PointF> points = new List<PointF>();

        public Solution() 
        {
            for (int i = 0; i < Engine.vertices; i++)
            {
                float x = Engine.random.Next(Engine.form.pictureBox1.Width);
                float y = Engine.random.Next(Engine.form.pictureBox1.Height);
                points.Add(new PointF(x,y));
            }
        }

        public Solution(Solution a, Solution b)
        {
            for(int i = 0; i < Engine.vertices; i++)
            {
                if(Engine.random.Next(2) == 0)
                {
                    points.Add(a.points[i]);
                }
                else
                {
                    points.Add(b.points[i]);
                }
            }
        }

        public float Fitness()
        {
            float error = 0;
            for(int i = 0; i < Engine.vertices; i++)
            {
                for(int j = 0; j < Engine.vertices; j++)
                {
                    if (Engine.mAdiacenta[i, j] != 0)
                    {
                        float distance = Engine.Distance(points[i], points[j]);
                        error += Math.Abs(distance - Engine.mAdiacenta[i, j]);
                    }
                }
            }
            return error;
        }

        public override string ToString()
        {
            string toR = Fitness() + "\n";
            for(int i = 0; i < Engine.vertices; i++)
            {
                toR += $"({points[i].X}, {points[i].Y}) \n";
            }
            return toR;
        }
    }
}
