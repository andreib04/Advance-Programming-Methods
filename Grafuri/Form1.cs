using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafuri
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics grf;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grf = Graphics.FromImage(bmp);
            Graph graph = new Graph();
            graph.Load(@"..\..\graf.txt");
            graph.GreedyColoring();
            graph.Draw(grf);

            pictureBox1.Image = bmp;

            List<string> test = graph.debug();

            foreach(string s in test)
            {
                listBox1.Items.Add(s);
            }
        }
    }
}
