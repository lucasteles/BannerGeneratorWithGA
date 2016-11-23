using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Abstraction
{
    public interface IMutate
    {
        double MutationRate { get; set; }
        IGenome Calc(IGenome baby);
    }
}
