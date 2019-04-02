using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optymalizacja_funkcji
{
    class Solution
    {
        int[] solution;
        int min;
        int max;
        uint precision;
        uint length;
        double fitness;
        Random rand;
        public double Fitness
        {
            get
            {
                return fitness;
            }

            set
            {
                fitness = value;
            }
        }

        public Solution(int min, int max, uint precision, Random rand)
        {

            this.min = min;
            this.max = max;
            this.precision = precision;
            uint m = 1;
            while ((max - min) * Math.Pow(10, precision) > Math.Pow(2, m) - 1)
                m++;
            length = m;
            solution = new int[length];
            this.rand = rand;
        }

        public void Initialize()
        {
            for (int i = 0; i < length; i++)
                solution[i] = rand.NextDouble() < 0.5 ? 0 : 1;
        }

        public double ToReal()
        {
            long xb = 0;
            for (int i = 0; i < length; i++)
                xb += solution[i] * (int)Math.Pow(2, length - i-1);
            return min + xb * (max - min) / (Math.Pow(2, length) - 1);
        }

        public void Evaluate()
        {
            Fitness= Problem.Function(this.ToReal());
        }

        public void Mutate(double mutProb)
        {
            for (int i = 0; i < length; i++)
                if (rand.NextDouble() < mutProb)
                    solution[i] = Math.Abs(solution[i] - 1);
        }

        public void Cross(Solution r2,double crosProb)
        {
            if(rand.NextDouble()<crosProb)
            {
                int cp = rand.Next((int)length);
                for(int i=cp;i<length;i++)
                {
                    int temp = this.solution[i];
                    this.solution[i] = r2.solution[i];
                    r2.solution[i] = temp;
                }
            }
        }

        public Solution Clone()
        {
            Solution clone = (Solution)this.MemberwiseClone();
            clone.solution = (int[])this.solution.Clone();
            return clone;
        }

    }
}
