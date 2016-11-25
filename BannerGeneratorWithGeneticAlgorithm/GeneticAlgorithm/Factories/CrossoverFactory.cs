using GeneticAlgorithm.Abstraction;
using GeneticAlgorithm.Crossover;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Factories
{
    public class CrossoverFactory : IFactory<ICrossover>
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

        public ICrossover GetImplementation()
        {
            switch (GASettings.CrossoverAlgorithm)
            {
                case CrossoverEnum.Simple:
                    return GetSimpleImplementation();
                    
                case CrossoverEnum.OBX:
                    return GetOBXImplementation();
                    
                case CrossoverEnum.PBX:
                    return GetPBXImplementation();
            }

            return null;
        }
    }
}
