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

            foreach(Vertex v in t)
            {
                listBox1.Items.Add(v.idx);
            }

            List<Vertex> t1 = graph.DFS(graph.vertices[0]);

            foreach(Vertex v in t1)
            {
                listBox2.Items.Add(v.idx);
            }

            graph.Draw(grp);
            pictureBox1.Image = bmp;
        }
    }
}
