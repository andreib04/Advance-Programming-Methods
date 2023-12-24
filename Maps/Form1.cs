﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maps
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics graphics;
        Bitmap bitmap;

        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);

            Graph.LoadFromFile(@"../../input.txt");
            DrawGraph();
        }

        private void DrawGraph()
        {
            foreach(Edge edge in Graph.edges)
            {
                Point start = edge.start.position;
                Point end = edge.end.position;
                graphics.DrawLine(new Pen(Color.Gray, 10), start, end);
            }

            pictureBox1.Image = bitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // "out int <variable>" este un parametru de iesire
            // acesta se comporta similar cu un parametru de tip referinta,
            // deoarece pastreaza toate modificarile asupra sa in interiorul metodei apelate.
            // Diferenta este ca nu trebuie sa declaram variabila respectiva,
            // deci se declara in linie cu apelul functiei.
            bool isSourceOk = int.TryParse(textBox1.Text, out int source);
            bool isDestinationOk = int.TryParse(textBox2.Text, out int destination);

            if (!isSourceOk || Graph.FindVertice(source) == null
                || !isDestinationOk || Graph.FindVertice(destination) == null)
            {
                MessageBox.Show("Please insert valid values!", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var bestRoute = Graph.FindBestRoute(source, destination);
            MessageBox.Show(bestRoute.cost + " " + bestRoute.Path.Count);
        }
    }
}
