using GeneticAlgorithm.Abstraction;
using GeneticAlgorithm.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Factories
{
    public class SelectionFactory
    {
        public static ISelection GetRandomImplementation()
        {
            return new SelectionRandom();
        }

        public static ISelection GetRouletteWheelSelectionImplementation()
        {
            return new SelectionRouletteWheel();
        }
    }
}
