using GeneticAlgorithm.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeneticAlgorithm
{
    public class GARandom : IRandom
    {
        private Random me;
        public  GARandom()
        {
            me = new Random(); 
        }

        public int Next() => me.Next();
        public int Next(int maxValue) => me.Next(maxValue);
        public int Next(int minValue, int maxValue) => me.Next(minValue,maxValue);
        public void NextBytes(byte[] buffer) => me.NextBytes(buffer);
        public double NextDouble() => me.NextDouble();
        
    }
}