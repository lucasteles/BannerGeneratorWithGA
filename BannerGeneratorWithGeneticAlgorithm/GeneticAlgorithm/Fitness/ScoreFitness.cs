using GeneticAlgorithm.Abstraction;
using GeneticAlgorithm.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Math;

namespace GeneticAlgorithm.Fitness
{
    public class ScoreFitness : IFitness
    {
        
        public ScoreFitness() {
            
        }
        public double Calc(IGenome genome)
        {
            return (1/((double)genome.Score-1));
        }
    }
}
