using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarysearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        bool binarySearch(int[] v, int x, int st, int dr)
        {
            if (st <= dr)
            {
                int m = (st + dr) / 2;

                if (v[m] == x)
                    return true;
                else if (x < v[m])
                    return binarySearch(v, x, st, m - 1);
                else
                    return binarySearch(v, x, m + 1, dr);
            }
            return false;

        }
    }
}
