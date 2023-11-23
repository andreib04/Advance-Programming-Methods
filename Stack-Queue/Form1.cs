using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stack_Queue
{
    public partial class Form1 : Form
    {
        Graphics grp;
        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myStack<int> myStack = new myStack<int>();
            //myStack.Push(1);
            //myStack.Push(2);
            //myStack.Push(3);
            //label1.Text = myStack.Pop().ToString();

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            Graph graph = new Graph();
            graph.Load(@"../../txt.txt");
            graph.Dispersion(new PointF(pictureBox1.Width/2, pictureBox1.Height/2), 150);
            List<Vertex> t = graph.BFS(graph.vertices[0]);

            StringBuilder sb = new StringBuilder();
            foreach (Vertex v in t)
            {
                sb.Append(v.idx);
                sb.Append(" ");
            }
            listBox1.Items.Add(sb.ToString());

            t = graph.DFS(graph.vertices[0]);
            sb.Clear();
            foreach(Vertex v in t)
            {
                sb.Append(v.idx);
                sb.Append(" ");
            }
            listBox1.Items.Add(sb.ToString());


            t = graph.DFS_Rec(graph.vertices[0]);
            sb.Clear();
            foreach (Vertex v in t)
            {
                sb.Append(v.idx);
                sb.Append(" ");
            }
            listBox1.Items.Add(sb.ToString());

            int[] dist = graph.Dijkstra(graph.vertices[0]);
            sb.Clear();
            foreach(int distance in dist)
            {
                if (distance != int.MaxValue)
                    sb.Append(distance);
                else
                    return sb.;
            }
            


            graph.Draw(grp);
            pictureBox1.Image = bmp;
        }
    }
}
