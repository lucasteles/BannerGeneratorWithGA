using GeneticAlgorithm.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Crossover
{
    public class CrossoverPBX : AbstractCrossover
    {
        public override CrossoverOperation Calc(CrossoverOperation Operation)
        {
            var rand = Factories.RandomFactory.GetRadomImplementation();
            if (rand.NextDouble() > CrossoverRate || Operation.IsEqual())
                return Operation;

            var babymom = Operation.Copy(Operation.Mom);
            var babydad = Operation.Copy(Operation.Dad);

            var lstPositions = new List<int>();

            var listmom = Operation.Mom.Gens;
            var listdad = Operation.Dad.Gens;

            var minindex = Math.Min(listmom.Count, listdad.Count);

            for (int i = 0; i < minindex; i++)
                babymom.Gens[i] = babydad.Gens[i] = -1;

            var Pos = rand.Next(0, minindex - 1);

            while (Pos < minindex)
            {
                lstPositions.Add(Pos);
                Pos += rand.Next(1, minindex - Pos);
            }

            for (int pos = 0; pos < lstPositions.Count; ++pos)
            {
                babymom.Gens[lstPositions[pos]] = listmom[lstPositions[pos]];
                babydad.Gens[lstPositions[pos]] = listdad[lstPositions[pos]];
            }

            int c1, c2;
            c1 = c2 = 0;

            for (int pos = 0; pos < minindex; pos++)
            {
                while (c2 < minindex && babydad.Gens[c2] > -1)
                    ++c2;

                if (c2 < babydad.Gens.Count)
                    if (!babydad.Gens.ToList().Exists(i => i == (listmom[pos])))
                        babydad.Gens[c2] = listmom[pos];

                while (c1 < minindex && babymom.Gens[c1] > -1)
                    ++c1;

                if (c1 < babymom.Gens.Count)
                    if (!babymom.Gens.ToList().Exists(i => i == (listdad[pos])))
                        babymom.Gens[c1] = listdad[pos];
            }

            return new CrossoverOperation(babymom, babydad);
        }
    }
}
