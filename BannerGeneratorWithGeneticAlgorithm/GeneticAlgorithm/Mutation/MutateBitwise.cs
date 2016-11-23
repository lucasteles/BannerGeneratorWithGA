using GeneticAlgorithm.Abstraction;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Mutation
{
    public class MutateBitwise : AbstractMutate
    {
        public override IGenome Calc(IGenome baby)
        {
            var rand = Factories.RandomFactory.GetRadomImplementation();
            if (rand.NextDouble() > MutationRate)
                return baby;

            var i = (int)Math.Floor(rand.NextDouble() * baby.Gens.Count());
                                                            
            // choose the bit to swap                
            var qtdBits = (int)Math.Floor(8 * rand.NextDouble());
            baby.Gens[i] ^= 1 << qtdBits;
                                            
            return baby;
        }
    }
}
