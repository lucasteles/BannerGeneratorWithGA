using System.Collections;
using System.Collections.Generic;

namespace GeneticAlgorithm.Abstraction
{
    public interface IGenome
    {
        double Fitness { get; set; }
        IList<int> Gens { get; set; }
        long Score { get; set; }

        string ToString();
    }
}