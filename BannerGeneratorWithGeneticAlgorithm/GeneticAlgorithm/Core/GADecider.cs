using GeneticAlgorithm.Abstraction;
using GeneticAlgorithm.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static GeneticAlgorithm.GASettings;

namespace GeneticAlgorithm
{
    public class GADecider
    {
        public ICrossover GetCrossover(CrossoverEnum? option = null)
        {
            ICrossover ret = null;
            var opt = option.HasValue ? option.Value : CrossoverAlgorithm;
            switch (opt)
            {
                case CrossoverEnum.Simple:
                    ret = CrossoverFactory.GetSimpleImplementation();
                    break;
                case CrossoverEnum.OBX:
                    ret = CrossoverFactory.GetOBXImplementation();
                    break;
                case CrossoverEnum.PBX:
                    ret = CrossoverFactory.GetPBXImplementation();
                    break;
            }

            return ret;

        }
        public IMutate GetMutate(MutateEnum? option = null)
        {
            IMutate ret = null;
            var opt = option.HasValue ? option.Value : MutationAlgorithm;

            switch (opt)
            {
                case MutateEnum.EM:
                    ret = MutateFactory.GetEMImplementation();
                    break;
                case MutateEnum.DIVM:
                    ret = MutateFactory.GetDIVMImplementation();
                    break;
                case MutateEnum.DM:
                    ret = MutateFactory.GetDMImplementation();
                    break;
                case MutateEnum.IM:
                    ret = MutateFactory.GetIMImplementation();
                    break;
                case MutateEnum.IVM:
                    ret = MutateFactory.GetIVMImplementation();
                    break;
                case MutateEnum.SM:
                    ret = MutateFactory.GetSMImplementation();
                    break;
                case MutateEnum.Bitwise:
                    ret = MutateFactory.GetBitwiseImplementation();
                    break;
            }

            return ret;
        }
        public IFitness GetFitness(FitnessEnum? option = null)
        {
            IFitness ret = null;
            var opt = option.HasValue ? option.Value : FitnessAlgorithm;
            switch (opt)
            {
                case FitnessEnum.Score:
                    ret = FitnessFactory.GetScoreImplementation();
                    break;

            }

            return ret;
        }
        public ISelection GetSelection(SelectionEnum? option = null)
        {
            ISelection ret = null;
            var opt = option.HasValue ? option.Value : SelectionAlgorithm;
            switch (opt)
            {
                case SelectionEnum.Random:
                    ret = SelectionFactory.GetRandomImplementation();
                    break;
                case SelectionEnum.RouletteWheel:
                    ret = SelectionFactory.GetRouletteWheelSelectionImplementation();
                    break;
            }

            return ret;
        }
    }
}