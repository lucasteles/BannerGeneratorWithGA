using GeneticAlgorithm.Abstraction;
using System;
using System.Linq;

namespace GeneticAlgorithm.Crossover
{
    public class CrossoverSimple : AbstractCrossover
    {
        public override CrossoverOperation Calc(CrossoverOperation Operation)
        {
            var rand = Factories.RandomFactory.GetRadomImplementation();
            if (rand.NextDouble() > CrossoverRate || Operation.IsEqual())
                return Operation;

            var babymom = Operation.Copy(Operation.Mom);
            var babydad = Operation.Copy(Operation.Dad);

            var listmom = Operation.Mom.Gens;
            var listdad = Operation.Dad.Gens;

            var listbabymom = babymom.Gens;
            var listbabydad = babydad.Gens;
            

            var minindex = Math.Min(listmom.Count, listdad.Count);

            var beg = rand.Next(0, minindex - 1);

            var end = beg;

            while (end < beg)
                end = rand.Next(0, minindex);

            for (int pos = beg; pos <= end; ++pos)
            {
                var genemom = listmom[pos];
                var genedad = listdad[pos];

                if (!genemom.Equals(genedad))
                {
                    var temp = listbabymom[pos];
                    listbabymom[pos] = listdad[pos];
                    listdad[pos] = temp;
                }
            }

            return new CrossoverOperation(babymom, babydad);
        }
    }
}
