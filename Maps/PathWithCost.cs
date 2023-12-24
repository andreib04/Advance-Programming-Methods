using System.Collections.Generic;

namespace Maps
{
    public class PathWithCost
    {
        public List<Vertex> Path;
        public double cost;

        public PathWithCost()
        {
            Path = new List<Vertex>();
            cost = 0;
        }
    }
}
