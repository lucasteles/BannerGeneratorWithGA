using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneticAlgorithm.Abstraction;
using System.Reflection;

namespace GeneticAlgorithm
{
    public class Genome : IGenome
    {
        public IList<int> Gens { get; set; }
        public double Fitness { get; set; }

        public long Score { get; set; }

        public Genome()
        {
            var rand = Factories.RandomFactory.GetRadomImplementation();
            var bgen = new byte[12];
            rand.NextBytes(bgen);
            Gens = bgen.Select(e => (int)e).ToArray();

        }
             
                
        public override string ToString()
        {
            return $"F={Fitness}";
        }
    }
}
