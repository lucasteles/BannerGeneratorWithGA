using GeneticAlgorithm.Abstraction;
using GeneticAlgorithm.Crossover;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Factories
{
    public class RandomFactory
    {
        public static GARandom Rand;

        static RandomFactory()
        {
            Rand = new GARandom();
        }

        public static IRandom GetRadomImplementation()
        {
            return Rand;
        }
      




    }
}
