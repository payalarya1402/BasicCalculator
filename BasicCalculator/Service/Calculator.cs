using BasicCalculator.Constant;
using BasicCalculator.Helper;
using BasicCalculator.Model;
using BasicCalculator.Operators.Helper;
using BasicCalculator.Operators.Interface;
using BasicCalculator.Operators.Service;
namespace BasicCalculator.Service
{
    public  class Calculator
    {
        public List<object> rpn { get; set; }
        public State currOutput { get; set; }

        public Calculator()
        {
            rpn = new List<object>();
            currOutput = new State();
            Clear();
        }

        ///<summary>
        /// Determines whether the entered expression is in correct format and process the entered expression.
        ///</summary>
        ///<param name="expression">The expression to string</param>
        ///<returns><decimal></decimal></returns>
        public decimal Invoke(string experssion)
        {
            //1. Validate the input string.
            if (!isValidInput(experssion))
            {
                throw new Exception("Invalid Input.Please check the input");
            }

            return Process(experssion);
        }

        private decimal Process(string input)
        {
            try
            {
                //1. check if input string is "AC", clear the existing data.
                if (input.Equals(BasicCalculatorConstant.CLEAR))
                {
                    return Clear();

                }
                //2. check if input string is "=", perfrom the calculation
                else if (input.Equals(BasicCalculatorConstant.EQUAL_OPERATOR))
                {
                    decimal result = HandleEqual();
                    return result;
                }
                else
                {
                    //3. Entered experssion contains '=' then split the equation and
                    if (input.Contains('='))
                    {
                        int i = input.IndexOf('=');
                        string[] experssions = input.Split('=');
                        ConvertToRPN(experssions[0]);
                        return HandleEqual();

                    }
                    else
                    {
                        ConvertToRPN(input);
                        return currOutput.CurrValue;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("@PROCESSING_EXCEPTION", new { Message = ex.Message, StackTrace = ex.StackTrace });
                Clear();
                throw;

            }

        }

        ///<summary>
        /// Determines whether the entered expression is in correct format.
        /// If entered input is null, empty or only white spaces , returned false
        /// If entered input is not matching,returned false
        ///</summary>input
        ///<param name="expression">The expression to string</param>
        ///<returns><bool></bool></returns>
        private bool isValidInput(string experssion)
        {
            //Regex regex = new Regex(BasicCalculatorConstant.PATTERN);

            return experssion switch
            {
                _ when string.IsNullOrWhiteSpace(experssion) => false,
                //_ when !regex.IsMatch(experssion) => false,
                _ => true
            }; ;

        }

        private void ConvertToRPN(string experssion)
        {
            Stack<IOperator> operatorStack = GetOperationStack(experssion);
            for (int i = 0; i < experssion.Length; i++)
            {
                if (char.IsDigit(experssion[i]) ||
                   i == 0 && experssion[i] == '-' && char.IsDigit(experssion[i + 1]) ||
                   i >= 1 && experssion[i] == '-' && experssion[i - 1] == '(' && char.IsDigit(experssion[i + 1]))
                {
                    currOutput.CurrValue = experssion.ReadNumber(ref i);
                    rpn.Add(currOutput.CurrValue);
                }
                else if (experssion[i] == '(')
                {
                    operatorStack.Push(OperatorFactory.Create<LeftBracket>());
                }
                else if (experssion[i] == ')')
                {
                    while (operatorStack.Peek().GetType() != typeof(LeftBracket))
                    {
                        rpn.Add(operatorStack.Pop());
                    }
                    operatorStack.Pop();
                }
                else if (!char.IsWhiteSpace(experssion[i]) && experssion[i] != '.' &&
                !(i == 0 && experssion[i] == '-') &&
                !(i >= 1 && experssion[i] == '-' && experssion[i - 1] == '('))
                {
                    var token = experssion.ToOperator(i);
                    while (operatorStack.Count != 0 &&
                          operatorStack.Peek().GetType() != typeof(LeftBracket) &&
                          token.ComparePriority(operatorStack.Peek()))
                    {
                        rpn.Add(operatorStack.Pop());
                    }
                    operatorStack.Push(token);
                }
            }
            while (operatorStack.Count != 0)
            {
                rpn.Add(operatorStack.Pop());
            }
        }

        private Stack<IOperator> GetOperationStack(string experssion)
        {
            Stack<IOperator> operatorStack = new Stack<IOperator>();

            // check for first opertaor 
            if (currOutput.CurrValue == 0 && currOutput.Result == 0)
            {
                if (experssion.StartsWith('-') || char.IsDigit(experssion[0]))
                {
                    operatorStack.Push(OperatorFactory.Create<Addition>());
                }
            }
            else if (currOutput.Result > 0)
            {
                if (experssion.StartsWith('-') || experssion.StartsWith('*') || experssion.StartsWith('/') || experssion.StartsWith('+'))
                {
                    currOutput.Result = 0;
                    if (experssion.StartsWith('-'))
                    {
                        operatorStack.Push(OperatorFactory.Create<Addition>());

                    }
                }
                else
                {
                    Clear();
                    operatorStack.Push(OperatorFactory.Create<Addition>());
                }
            }
            return operatorStack;
        }

        private decimal HandleEqual()
        {
            //1. if user didn't entered any expression, return default value;
            if (this.rpn == null || this.rpn.Count == 0) return BasicCalculatorConstant.DEFAULT_VALUE;
            return GenerateResposne(Calculate(this.rpn));
        }


        private decimal GenerateResposne(decimal result)
        {
            //before returing response to the user, clear the rpn list and add the calculated value in rpn list.
            this.rpn.Clear();
            this.rpn.Add(result);
            currOutput.Result = result;
            currOutput.CurrValue = result;
            return currOutput.Result;
        }

        // perform the mathematical operation and return the value
        private decimal Calculate(List<object> rpn)
        {
            Stack<decimal> numberStack = new Stack<decimal>();
            foreach (var token in rpn)
            {

                if (token is decimal)
                {
                    numberStack.Push((decimal)token);
                }
                if (token is IExecutableOperator)
                {
                    var oper = (IExecutableOperator)token;
                    var a = numberStack.Pop();
                    var b = numberStack.Pop();
                    numberStack.Push(oper.CalculateOperator(b, a));
                }
            }
            return numberStack.Pop();

        }

        private decimal Clear()
        {
            rpn = new List<object>();
            currOutput.CurrValue = BasicCalculatorConstant.DEFAULT_VALUE;
            currOutput.Result = BasicCalculatorConstant.DEFAULT_VALUE;
            rpn.Add(BasicCalculatorConstant.DEFAULT_VALUE);
            return currOutput.CurrValue;
        }
    }
}