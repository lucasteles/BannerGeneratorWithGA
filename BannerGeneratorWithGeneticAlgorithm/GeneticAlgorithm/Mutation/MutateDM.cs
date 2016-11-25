using GeneticAlgorithm.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Mutation
{
    public class MutateDM : AbstractMutate
    {
        public override  IGenome Calc(IGenome baby)
        {
            var rand = GAResolver.Resolve<IRandom>();
            if (rand.NextDouble() > MutationRate)
                return baby;

            int listcount = baby.Gens.Count();
            const int minSpanSize = 3;

            if (listcount <= minSpanSize)
                return baby;

            int beg, end;
            beg = end = 0;
            var spanSize = rand.Next(minSpanSize, listcount);
            beg = rand.Next(1, listcount - spanSize);
            end = beg + spanSize;

            var lstTemp = new List<int>();
            for (int i = beg; i < end; i++)
            {
                lstTemp.Add(baby.Gens[beg]);
                baby.Gens.RemoveAt(beg);
            }

            var insertLocation = rand.Next(1, baby.Gens.Count);
            var count = 0;
            for (int i = insertLocation; count < lstTemp.Count; i++)
            {
                baby.Gens.Insert(i, lstTemp[count]);
                count++;
            }
            return baby;
        }
    }
}
