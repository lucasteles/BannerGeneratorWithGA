using GeneticAlgorithm.Abstraction;
using GeneticAlgorithm.Crossover;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Factories
{
    public class CrossoverFactory
    {
        public static ICrossover GetSimpleImplementation()
        {
            return new CrossoverSimple();
        }
        public static ICrossover GetOBXImplementation()
        {
            return new CrossoverOBX();
        }
        public static ICrossover GetPBXImplementation()
        {
            return new CrossoverPBX();
        }
    }
}
