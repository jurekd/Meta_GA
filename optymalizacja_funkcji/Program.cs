using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optymalizacja_funkcji
{
    public class Program
    {

        static void Main(string[] args)
        {
            Random rand = new Random();

            //double result = RandomSearch.Run(300, rand);
            //Console.WriteLine("Random search: " + result);


            //double result2 = HillClimbing.Run(300, rand);
            //Console.WriteLine("Hill climbing: " + result2);

            //double result3 = TabooSearch.Run(300, rand, 2);
            //Console.WriteLine("Taboo search: " + result3);

            //int min = -1;
            //int max = 2;
            //uint precision = 4;
            //for(int i=0;i<100;i++)
            //{
            //    Solution s = new Solution(min, max, precision, rand);
            //    s.Initialize();
            //    Console.WriteLine(s.ToReal());
            //}

            //GA ga = new GA(30, rand);
            //ga.Run(1000,0.9,0.05);
            ProblemTSP.ReadProblem("TSP30.TXT");
            GA_TSP ga = new GA_TSP(30, rand);
            ga.Run(1000, 0.9, 0.05);

            Console.ReadKey();
        }
    }
}
