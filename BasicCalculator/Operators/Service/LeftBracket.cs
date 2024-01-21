using System;
using BasicCalculator.Operators.Interface;

namespace BasicCalculator.Operators.Service
{
	public class LeftBracket : IOperator
    {
        public uint Weight => 1;

    }
}

