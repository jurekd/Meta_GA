using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optymalizacja_funkcji
{
    class ProblemTSP
    {
        public static int N;
        static int bestResult;
        static int[,] points;
        public static void ReadProblem(string plik)
        {
            string[] lines = File.ReadAllLines(plik);
            N = int.Parse(lines[0]);
            points = new int[N,2];
            bestResult = int.Parse(lines[1]);
            for(int i=0;i<N;i++)
            {
                string[] s = lines[2 + i].Split(' ');
                points[i, 0] = int.Parse(s[0]);
                points[i, 1] = int.Parse(s[1]);
            }     
        }

        public static int Function(int[] path)
        {
            int result = 0;
            for (int i = 0; i < N - 1; i++)
                result +=(int) (Math.Sqrt(Math.Pow(points[path[i], 0] - points[path[i + 1], 0], 2) +
                    Math.Pow(points[path[i], 1] - points[path[i + 1], 1], 2))+0.51);
            result+= (int)(Math.Sqrt(Math.Pow(points[path[N-1], 0] - points[path[0], 0], 2) +
                    Math.Pow(points[path[N - 1], 1] - points[path[0], 1], 2)) + 0.51);
            return result;
        }
    }
}
