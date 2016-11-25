using GeneticAlgorithm.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Crossover
{
    public class CrossoverOBX : AbstractCrossover
    {
        public override CrossoverOperation Calc(CrossoverOperation Operation)
        {
            var rand = GAResolver.Resolve<IRandom>();

            if (rand.NextDouble() > CrossoverRate || Operation.IsEqual())
                return Operation;

            var babymom = Operation.Copy(Operation.Mom);
            var babydad = Operation.Copy(Operation.Dad);

            var listmom = Operation.Mom.Gens;
            var listdad = Operation.Dad.Gens;

            var lstTemp = new List<int>();
            var lstPositions = new List<int>();


            int pos = rand.Next(0, listmom.Count - 1);

            while (pos < listmom.Count)
            {
                lstPositions.Add(pos);
                lstTemp.Add(listmom[pos]);
                pos += rand.Next(1, listmom.Count - pos);
            }

            int cPos = 0;
            for (int cit = 0; cit < babydad.Gens.Count; ++cit)
            {
                for (int i = 0; i < lstTemp.Count; ++i)
                {
                    if (babydad.Gens[cit] == lstTemp[i])
                    {
                        babydad.Gens[cit] = lstTemp[cPos];
                        ++cPos;
                        break;
                    }
                }
            }

            lstTemp.Clear();
            cPos = 0;

            for (int i = 0; i < lstPositions.Count - 1; ++i)
            {
                lstTemp.Add(listdad[lstPositions[i]]);
            }

            for (int cit = 0; cit < babymom.Gens.Count; ++cit)
            {
                cPos = 0;
                for (int i = 0; i < lstTemp.Count; ++i)
                {
                    if (babymom.Gens[cit] == lstTemp[i])
                    {
                        babymom.Gens[cit] = lstTemp[cPos];
                        ++cPos;
                        break;
                    }
                }
            }


            return new CrossoverOperation(babymom, babydad);
        }
    }
}
