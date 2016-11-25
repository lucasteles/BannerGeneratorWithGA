using GeneticAlgorithm.Abstraction;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeneticAlgorithm
{

    public class GA
    {

        public IFitness Fitness { get; set; }
        public IMutate Mutate { get; set; }
        public ICrossover Crossover { get; set; }
        public ISelection Selection { get; set; }
        
        public IList<IGenome> Population { get; set; }

        private Adaptation Adaptation;
        private IRandom Rand;

        public int Generation { get; set; }

        public GA()
        {


            Mutate    = GAResolver.Resolve<IMutate>();
            Crossover = GAResolver.Resolve<ICrossover>();
            Fitness   = GAResolver.Resolve<IFitness>();
            Selection = GAResolver.Resolve<ISelection>();

            Rand = GAResolver.Resolve<IRandom>();

            Population = new List<IGenome>();
            Adaptation = new Adaptation();

            for (int i = 0; i < GASettings.PopulationSize; i++)
                Population.Add(new Genome());

          
        }

        

        public void Epoch()
        {
            CalcFitness();

            var newpopulations = new List<IGenome>();

            Population = Population.OrderBy(o => o.Fitness).ToList();

            for (int j = 0; j < GASettings.BestSolutionToPick; j++)
            {
                Population[j].Fitness = Fitness.Calc(Population[j]);
                Population[j].Score = 0;
                newpopulations.Add(Population[j]);
            }

            int ran = Rand.Next(1, Population.Count);
                                            
            while (newpopulations.Count < Population.Count)
            {
                // Selection
                var nodemom = Selection.Select(Population);
                var nodedad = Selection.Select(Population);
                // CrossOver
                var cross = Crossover.Calc(new CrossoverOperation(nodemom, nodedad));
                //// Mutation
                nodemom = Mutate.Calc(cross.Mom);
                nodedad = Mutate.Calc(cross.Dad);
                // Adaptation
                nodemom = Adaptation.Calc(nodemom);
                nodedad = Adaptation.Calc(nodedad);

                nodemom.Fitness = Fitness.Calc(nodemom);
                nodedad.Fitness = Fitness.Calc(nodedad);

                // Add in new population
                newpopulations.Add(nodemom);
                newpopulations.Add(nodedad);
            }
            Population = null;
            Population = newpopulations.ToList();

            Generation++;
        }
                
        private void CalcFitness()
        {
            foreach (var item in Population)
                item.Fitness = Fitness.Calc(item);
        }
    }
}