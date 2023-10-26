using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreedyColoring
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Engine.Init(this);
            Engine.ReadFromFile(@"..\..\TextFile.txt");
            // Engine.GreedyColoring();
            // Engine.DrawMap();
            Engine.Hamiltonian();
            label1.Text = "Total hamiltonian roads: " + Engine.solutions.Count.ToString();
            Engine.DisplayRoads();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Engine.index = (Engine.index + 1) % Engine.solutions.Count;
            textBox1.Text = Engine.index.ToString();
            Engine.DisplayRoads();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Engine.index--;

            if(Engine.index < 0)
            {
                Engine.index = Engine.solutions.Count - 1;
            }
            textBox1.Text = Engine.index.ToString();
            Engine.DisplayRoads();
        }

        private void textBox1_TextChanged(Object sender, EventArgs e)
        {
            if(int.TryParse(textBox1.Text, out Engine.index))
            {
                if (Engine.index < 0)
                    Engine.index = Engine.solutions.Count - 1;
                Engine.index = Engine.index % Engine.solutions.Count;
                textBox1.Text = Engine.index.ToString();
                Engine.DisplayRoads();
            }
        }
    }
}
