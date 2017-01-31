using System;
using System.Collections.Generic;

namespace BookKeeper
{
	public class TaxRate
	{

		readonly List<int> taxRates = new List<int> { 6, 12, 20 };

		public TaxRate(List<int> taxRates)
		{
			this.taxRates = taxRates;
		}
	}
}
