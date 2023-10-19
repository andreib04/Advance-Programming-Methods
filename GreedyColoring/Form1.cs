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
            Engine.GreedyColoring();
            Engine.DrawMap();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
