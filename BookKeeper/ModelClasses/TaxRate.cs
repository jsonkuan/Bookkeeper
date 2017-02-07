using System;
using System.Collections.Generic;
using SQLite;

namespace BookKeeper
{
	public class TaxRate
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; private set; }
		public double Rate { get; set; }

		public TaxRate(double taxRate)
		{
			Rate = taxRate;
		}

		public TaxRate()
		{ 
		}

		public override string ToString()
		{
			return string.Format("{0}", Rate * 100);
		}
	}
}
