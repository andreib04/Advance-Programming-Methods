using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partial
{
    public class Vertex
    {
        public int id;
        public string value;

        public Vertex(int id) 
        {
            this.id = id;
        }

        public Vertex(int id, string value)
        {
            this.id = id;
            this.value = value;
        }

    }
}
