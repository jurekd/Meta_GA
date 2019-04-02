using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optymalizacja_funkcji
{
    class SolutionTSP
    {
        int[] solution;
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

        public SolutionTSP(Random rand)
        {
            solution = new int[ProblemTSP.N];
            this.rand = rand;
        }

        public void Initialize()
        {
            for (int i = 0; i < ProblemTSP.N; i++)
                solution[i] = i;
            for (int i = 0; i < ProblemTSP.N * ProblemTSP.N; i++)
                this.Swap();
        }

        private void Swap()
        {
            int p1 = rand.Next(ProblemTSP.N);
            int p2;
            do
            {
                p2=rand.Next(ProblemTSP.N);
            } while (p1 == p2);
            int tmp = solution[p1];
            solution[p1] = solution[p2];
            solution[p2] = tmp;
        }

        public void Mutate(double mutProb)
        {
            if (rand.NextDouble() < mutProb)
                Swap();
        }

        public void Evaluate()
        {
            Fitness = ProblemTSP.Function(solution);
        }

        public SolutionTSP Clone()
        {
            SolutionTSP copy = (SolutionTSP)this.MemberwiseClone();
            copy.solution = (int[])this.solution.Clone();
            return copy;
        }

    }
}
