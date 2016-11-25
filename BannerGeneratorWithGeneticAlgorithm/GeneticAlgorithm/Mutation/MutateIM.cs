using GeneticAlgorithm.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Mutation
{
    public class MutateIM : AbstractMutate
    {
        public override IGenome Calc(IGenome baby)
        {
            var rand = GAResolver.Resolve<IRandom>();
            if (rand.NextDouble() > MutationRate)
                return baby;

            int listcount = baby.Gens.Count;
            var randomPoint = rand.Next(1, listcount);
            var tempNumber = baby.Gens[randomPoint];

            baby.Gens.RemoveAt(randomPoint);
            var insertAt =rand.Next(1, listcount);
            baby.Gens.Insert(insertAt, tempNumber);

            return baby;
        }
    }
}
