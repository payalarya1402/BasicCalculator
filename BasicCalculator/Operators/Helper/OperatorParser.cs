using BasicCalculator.Operators.Interface;
using BasicCalculator.Operators.Service;

namespace BasicCalculator.Operators.Helper
{
    public static class OperatorParser
    {
        public static IOperator ToOperator(this string input, int pos)
        {
            switch (input[pos])
            {
                case '+':
                    return OperatorFactory.Create<Addition>();
                case '-':
                    return OperatorFactory.Create<Subtraction>();
                case 'X':
                    return OperatorFactory.Create<Multiplication>();
                case '/':
                case ':':
                    return OperatorFactory.Create<Division>();
                case '%':
                    return OperatorFactory.Create<Modulo>();
                case '^':
                    return OperatorFactory.Create<Power>();
                case '[':
                case '{':
                case '(':
                    return OperatorFactory.Create<LeftBracket>();
                case ']':
                case '}':
                case ')':
                    return OperatorFactory.Create<RightBracket>();
                default:
                    return OperatorFactory.Create<Default>();
            }
        }

            public static bool ComparePriority(this IOperator operatorToCompare, IOperator comparingOperator)
        {
            if (operatorToCompare.GetType() != typeof(Power))
            {
                if (operatorToCompare.Weight <= comparingOperator.Weight)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (operatorToCompare.Weight < comparingOperator.Weight)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        
    }
}

