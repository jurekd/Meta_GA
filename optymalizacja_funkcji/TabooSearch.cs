using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optymalizacja_funkcji
{
    using p = Problem;
    class TabooSearch
    {

        public static double Run(int maxIter, Random rand, int precision)
        {

            List<double> taboo = new List<double>();
            double max = double.MinValue;


            for(int i = 0; i< maxIter; i++)
            {
                double x = rand.NextDouble() * 3 - 1;
                double rx = Math.Round(x, precision);

                if (!taboo.Contains(rx))
                {
                    double y = p.Function(x);

                    if (y > max)
                    {
                        max = y;
                        taboo.Add(rx);

                    }
                }
                else
                {
                    Console.Write("Taboo! ");
                }
            }

            return max;
        }

    }
}
