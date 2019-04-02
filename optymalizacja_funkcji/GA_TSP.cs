using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optymalizacja_funkcji
{
    class GA_TSP
    {
        SolutionTSP[] pop;
        Random rand;
        int popSize;
        public GA_TSP(int popSize, Random rand)
        {
            pop = new SolutionTSP[popSize];
            this.popSize = popSize;
            this.rand = rand;
        }

        public void Run(int maxGen, double crosProb, double mutProb)
        {
            // Initialization
            for (int i = 0; i < popSize; i++)
            {
                pop[i] = new SolutionTSP(rand);
                pop[i].Initialize();
            }
            // Evalutaion
            double bestFitness = double.MinValue;

            foreach (SolutionTSP s in pop)
            {
                s.Evaluate();
                if (s.Fitness > bestFitness)
                {
                    bestFitness = s.Fitness;
                    Console.WriteLine("best {0} in generation {1}", bestFitness, 0);
                }
            }

            for (int gen = 1; gen < maxGen; gen++)
            {

                SolutionTSP[] npop = new SolutionTSP[popSize];
                //selection
                for (int i = 0; i < popSize; i++)
                {
                    int r1 = rand.Next(popSize);
                    int r2;
                    do
                    {
                        r2 = rand.Next(popSize);
                    } while (r1 == r2);
                    npop[i] = pop[r1].Fitness < pop[r2].Fitness ? pop[r1].Clone() : pop[r2].Clone();
                }
                //cross
                //for (int i = 0; i < popSize - 1; i += 2)
                //{
                //    npop[i].Cross(npop[i + 1], crosProb);
                //}

                //mutation
                for (int i = 0; i < popSize; i++)
                {
                    npop[i].Mutate(mutProb);
                }

                foreach (SolutionTSP s in npop)
                {
                    s.Evaluate();
                    if (s.Fitness < bestFitness)
                    {
                        bestFitness = s.Fitness;
                        Console.WriteLine("best {0} in generation {1}", bestFitness, gen);
                    }
                }

                for (int i = 0; i < popSize; i++)
                {
                    pop[i] = npop[i];
                }
            }

        }
    }
}
