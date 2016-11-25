using GeneticAlgorithm.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Mutation
{ 
    public class MutateEM : AbstractMutate
    {
        public override IGenome Calc(IGenome baby)
        {
            var rand = GAResolver.Resolve<IRandom>();
            if (rand.NextDouble() > MutationRate)
                return baby;

            int listcount = baby.Gens.Count;
            // Ignora o inicial
            var pos1 = rand.Next(0, listcount);
            var pos2 = pos1;

            while (pos1 == pos2)
                pos2 = rand.Next(0, listcount); // Ignora o inicial

            var temp = baby.Gens[pos1];
            baby.Gens[pos1] = baby.Gens[pos2];
            baby.Gens[pos2] = temp;

            return baby;
        }
    }
}
