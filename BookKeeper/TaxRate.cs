using System;
using System.Collections.Generic;
using SQLite;

namespace BookKeeper
{
	public class TaxRate
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; private set; }
		public double Rate { get; }

		private TaxRate(double taxRate)
		{
			Rate = taxRate;
		}

		public TaxRate()
		{
		}

		public override string ToString()
		{
			return string.Format("{0}%", Rate);
		}

		public void configureTaxRates(SQLiteConnection db)
		{
			TaxRate t1 = new TaxRate(0.07);
			TaxRate t2 = new TaxRate(0.15);
			TaxRate t3 = new TaxRate(0.25);

			db.Insert(t1);
			db.Insert(t2);
			db.Insert(t3);
		}
	}
}
