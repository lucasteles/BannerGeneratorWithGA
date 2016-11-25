using GeneticAlgorithm.Abstraction;
using GeneticAlgorithm.Fitness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Factories
{
    public class FitnessFactory : IFactory<IFitness>
    {
        public static IFitness GetScoreImplementation()
        {
            return new ScoreFitness();
        }

        public IFitness GetImplementation()
        {
                        
            switch (GASettings.FitnessAlgorithm)
            {
                case FitnessEnum.Score:
                    return GetScoreImplementation();
            }

            return null;
        }
    }
}
