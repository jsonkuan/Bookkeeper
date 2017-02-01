using System;
using System.Collections.Generic;

namespace BookKeeper
{
	public class TaxRate
	{
		public double Rate { get; set; }

		public TaxRate(double taxRate)
		{
			Rate = taxRate;
		}
	public override string ToString()
		{
			return string.Format("{0}%", Rate);
		}
	}
}
