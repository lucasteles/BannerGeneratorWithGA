﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Abstraction
{
    public class CrossoverOperation
    {
        public IGenome Mom { get; set; }
        public IGenome Dad { get; set; }

        public CrossoverOperation()
        {

        }

        public CrossoverOperation(IGenome mon, IGenome dad)
        {
            Dad = mon;
            Mom = dad;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsEqual()
        {
            return Mom.Equals(Dad);
        }
        public IGenome Copy(IGenome genome)
        {
            var ret = new Genome();
                        
            ret.Gens = genome.Gens.Select(e=>e).ToList();
            return ret;
        }
    }
    public abstract class AbstractCrossover : ICrossover
    {
        public AbstractCrossover()
        {
            CrossoverRate = GASettings.CrossoverRate;
        }
        protected double CrossoverRate { get; set; }
        CrossoverOperation Operation { get; set; }
        public abstract CrossoverOperation Calc(CrossoverOperation Operation);
    }
}
