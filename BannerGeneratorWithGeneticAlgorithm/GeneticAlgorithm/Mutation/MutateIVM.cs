using GeneticAlgorithm.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Mutation
{
    public class MutateIVM : AbstractMutate
    {
        public override IGenome Calc(IGenome baby)
        {
            var rand = Factories.RandomFactory.GetRadomImplementation();
            if (rand.NextDouble() > MutationRate)
                return baby;

            int listcount = baby.Gens.Count;
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
            lstTemp.Reverse();
            var count = 0;
            for (int i = beg; i < end; i++)
            {
                baby.Gens.Insert(i, lstTemp[count]);
                count++;
            }
            return baby;
        }
    }
}
