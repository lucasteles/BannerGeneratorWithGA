
using GeneticAlgorithm.Abstraction;
using GeneticAlgorithm.Factories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
namespace GeneticAlgorithm
{
    public  class GASettings
    {
        public static int GenerationLimit { get; set; }
        public static double MutationRate { get; set; }
        public static double CrossoverRate { get; set; }
        public static int PopulationSize { get; set; }
        public static MutateEnum MutationAlgorithm { get; set; }
        public static CrossoverEnum CrossoverAlgorithm { get; set; }
        public static SelectionEnum SelectionAlgorithm { get; set; }
        public static FitnessEnum FitnessAlgorithm { get; set; }
        public static int BestSolutionToPick { get; set; }


        static GASettings()
        {
            var conf = ConfigurationManager.AppSettings;

            GenerationLimit = int.Parse(conf[nameof(GenerationLimit)]);
            MutationRate = double.Parse(conf[nameof(MutationRate)]);
            CrossoverRate = double.Parse(conf[nameof(CrossoverRate)]);
            PopulationSize = int.Parse(conf[nameof(PopulationSize)]);
            MutationAlgorithm = (MutateEnum)int.Parse(conf[nameof(MutationAlgorithm)]);
            CrossoverAlgorithm =(CrossoverEnum) int.Parse(conf[nameof(CrossoverAlgorithm)]);
            FitnessAlgorithm = (FitnessEnum)int.Parse(conf[nameof(FitnessAlgorithm)]);
            SelectionAlgorithm = (SelectionEnum)int.Parse(conf[nameof(SelectionAlgorithm)]);
            BestSolutionToPick = int.Parse(conf[nameof(BestSolutionToPick)]);
          
        }
   

    }
}
