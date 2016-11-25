using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeneticAlgorithm.Abstraction
{

    public interface IFactory<T>
    {
         T GetImplementation();
    }

    public interface IFactory : IFactory<object>
    {
    }
}