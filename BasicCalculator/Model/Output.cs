using System;
namespace BasicCalculator.Model
{
	public class State
	{   // representt the last number entered by user
		public decimal CurrValue { get; set; }
        //represent previously calculated
        public decimal Result { get; set; }
    }
}

