using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optymalizacja_funkcji
{
    class Problem
    {
        public static double Function (double x)
        {
            return x * x * Math.Sin(15 * Math.PI * x) + 1;
        }

        public static double Normal(double mean, double dev)
        {
            Random rand = new Random(); //reuse this if you are generating many
            double u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
            double u2 = 1.0 - rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                         Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            double randNormal =
                         mean + dev * randStdNormal; //random normal(mean,stdDev^2)

            return randNormal;
        }
    }
}
