using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optymalizacja_funkcji
{
    using prop = Problem;

    class RandomSearch
    {
        public static double Run (int maxIter, Random rand)
        {
            double max = double.MinValue;
          

            for (int i = 0; i<maxIter; i++)
            {
                double x = rand.NextDouble() * 3 - 1;
                double y = prop.Function(x);
                if (y > max) max = y;
            }

            return max;
        }
    }
}
