using System;
using BasicCalculator.Operators.Interface;

namespace BasicCalculator.Operators.Service
{
	public class RightBracket : IOperator
    {
        public uint Weight => 6;

    }
}

