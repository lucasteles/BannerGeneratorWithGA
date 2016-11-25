using GeneticAlgorithm.Abstraction;
using GeneticAlgorithm.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Factories
{
    public class SelectionFactory : IFactory<ISelection>
    {
        public ISelection GetRandomImplementation()
        {
            return new SelectionRandom();
        }

        public ISelection GetRouletteWheelSelectionImplementation()
        {
            return new SelectionRouletteWheel();
        }

        public ISelection GetImplementation()
        {
            switch (GASettings.SelectionAlgorithm)
            {
                case SelectionEnum.Random:
                    return GetRandomImplementation();
                case SelectionEnum.RouletteWheel:
                    return GetRouletteWheelSelectionImplementation();
            }

            return null;
        }
    }
}
