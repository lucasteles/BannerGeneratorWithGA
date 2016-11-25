using GeneticAlgorithm.Abstraction;
using GeneticAlgorithm.Crossover;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Factories
{
    public class RandomFactory : IFactory<IRandom>
    {
        public static GARandom Rand;

        static RandomFactory()
        {
            Rand = new GARandom();
        }

        public IRandom GetImplementation()
        {
            return Rand;
        }
    }
}
