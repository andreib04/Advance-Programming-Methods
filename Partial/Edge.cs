using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partial
{
    public class Edge
    {
        public Vertex start;
        public Vertex end; 
        
        public Edge(Vertex start, Vertex end) 
        {
            this.start = start;
            this.end = end;
        }
    }
}
