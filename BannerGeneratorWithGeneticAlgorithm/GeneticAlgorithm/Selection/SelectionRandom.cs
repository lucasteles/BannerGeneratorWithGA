using GeneticAlgorithm.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Selection
{
    public class SelectionRandom : ISelection
    {
        public IGenome Select(IList<IGenome> lstgenes)
        {
            var rand = Factories.RandomFactory.GetRadomImplementation();
            var ind = rand.Next(0, lstgenes.Count);

            return lstgenes[ind];
        }
    }
}
