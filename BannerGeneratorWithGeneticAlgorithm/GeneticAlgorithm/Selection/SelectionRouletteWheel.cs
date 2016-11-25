using GeneticAlgorithm.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Selection
{
    public class SelectionRouletteWheel : ISelection
    {
        public IGenome Select(IList<IGenome> lstgens)
        {
            var rand = GAResolver.Resolve<IRandom>();
            double slice = rand.NextDouble() * lstgens.Sum(e=>e.Fitness+1) ;
            double total = 0;
            int selectedGenome = 0;

            for (int i = 0; i < lstgens.Count(); i++)
            {
                total += (lstgens[i].Fitness+1);

                if (total > slice)
                {
                    selectedGenome = i;
                    break;
                }
            }

            return lstgens[selectedGenome];

        }
    }
}
