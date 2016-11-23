using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Abstraction
{
    public interface ISelection
    {
        IGenome Select(IList<IGenome> lstgenes);
    }
}
