using GeneticAlgorithm.Abstraction;
using GeneticAlgorithm.Mutation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Factories
{
    public class MutateFactory  : IFactory<IMutate>
    {
        public IMutate GetEMImplementation()
        {
            return new MutateEM();
        }
        public IMutate GetDIVMImplementation()
        {
            return new MutateDIVM();
        }
        public IMutate GetDMImplementation()
        {
            return new MutateDM();
        }

        public IMutate GetIMImplementation()
        {
            return new MutateIM();
        }

        public IMutate GetIVMImplementation()
        {
            return new MutateIVM();
        }

        public IMutate GetSMImplementation()
        {
            return new MutateSM();
        }
        public IMutate GetBitwiseImplementation()
        {
            return new MutateBitwise();
        }

        public IMutate GetImplementation()
        {
            
            switch (GASettings.MutationAlgorithm)
            {
                case MutateEnum.EM:
                    return GetEMImplementation();

                case MutateEnum.DIVM:
                    return GetDIVMImplementation();
                    
                case MutateEnum.DM:
                    return GetDMImplementation();
                    
                case MutateEnum.IM:
                    return GetIMImplementation();
                    
                case MutateEnum.IVM:
                    return GetIVMImplementation();
                    
                case MutateEnum.SM:
                    return GetSMImplementation();
                    
                case MutateEnum.Bitwise:
                    return GetBitwiseImplementation();
 
            }

            return null;
        }
    }
}
