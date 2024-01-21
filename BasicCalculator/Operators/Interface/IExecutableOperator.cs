using System;
using System.Reflection;

namespace BasicCalculator.Operators.Interface
{
	public interface IExecutableOperator : IOperator
    {
        decimal CalculateOperator(decimal a, decimal b);
    }
}
