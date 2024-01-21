using System;
using BasicCalculator.Operators.Interface;
using System.Reflection;

namespace BasicCalculator.Operators.Helper
{
    public static class OperatorFactory
    {
        public static T Create<T>() where T : IOperator, new()
        {
            return new T();
        }
        public static void GetInstance()
        {
            var opTypes = Assembly.GetExecutingAssembly().DefinedTypes.Where(x => typeof(IOperator).IsAssignableFrom(x));
            var dic = opTypes.Select(x => (IOperator)Activator.CreateInstance(x)).ToDictionary(x => x.Weight, x => x);
        }
    }
}

