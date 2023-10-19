using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyColoring
{
    public class Neighbours //edges
    {
        public Country start;
        public Country end;

        public Neighbours(Country start, Country end) 
        {
            this.start = start;
            this.end = end;
        }
    }
}
