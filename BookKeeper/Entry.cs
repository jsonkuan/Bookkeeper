using System;
using SQLite;

namespace BookKeeper
{
	public class Entry
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; private set; }
		public string Date { get; set; }
		public string Description { get; set; }
		public string TypeOfAccount { get; set; }
		public string ToFromAccount { get; set; }
		public string TotalAmmount { get; set; }
		public string Type { get; set; }
		public double TaxRate { get; set; }

		public Entry(string date, string description, string typeOfAccount, string toFromAccount, string totalAmmount, double taxRate)
		{
			Date = date;
			Description = description;
			TypeOfAccount = typeOfAccount;
			ToFromAccount = toFromAccount;
			TotalAmmount = totalAmmount;
			TaxRate = taxRate;
		}

		public Entry()
		{
		}

		public override string ToString()
		{
			return string.Format("{0} {1} {2}kr {3}", Date, Description, TotalAmmount, TaxRate);
		}
	}
}