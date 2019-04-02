using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optymalizacja_funkcji
{
    using p = Problem;

    class HillClimbing
    {
        public static double Run(int maxIter, Random rand)
        {
            double dev = 3;

            double max = double.MinValue;
          

            for (int i = 0; i < maxIter; i++)
            {
                double x = rand.NextDouble() * 3 - 1;
                double y = p.Function(x);
                double xLeft = x - Math.Abs(p.Normal(0, dev));
                if (xLeft < -1) xLeft = -1;

                double xRight = x + Math.Abs(p.Normal(0, dev));
                if (xRight > 2) xRight = 2;

                double yLeft = p.Function(xLeft);
                double yRight = p.Function(xRight);

                bool progress = true;

                do
                {
                    if (yLeft > y)
                    {
                        x = xLeft;
                        y = yLeft;
                    }
                    else if (yRight > y)
                    {
                        x = xRight;
                        y = yRight;
                    }
                    else progress = false;

                } while (progress);

                if (y > max) max = y;
            }

            return max;
        }
    



    }
}
