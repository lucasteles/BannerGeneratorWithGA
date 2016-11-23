using GeneticAlgorithm.Abstraction;
using GeneticAlgorithm.Fitness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Factories
{
    public class FitnessFactory
    {
        public static IFitness GetScoreImplementation()
        {
            return new ScoreFitness();
        }
       
    }
}
