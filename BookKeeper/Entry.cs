using System;
namespace BookKeeper
{
	public class Entry
	{

		public string Date { get; set; }
		public string Description { get; set; }
		public string Type { get; set; }
		public string AccountOverview { get; set; }
		public int TotalAmmount { get; set; }
		public int TaxRate { get; set; }
		public string TypeOfAccount { get; set; }

		public Entry(string date, string description, string type, string accountOverview, int totalAmmount, int taxRate, string typeOfAccount)
		{
			Date = date;
			Description = description;
			Type = type;
			AccountOverview = accountOverview;
			TotalAmmount = totalAmmount;
			TaxRate = taxRate;
			TypeOfAccount = typeOfAccount;
		}

		public Entry(string date)
		{
			Date = date;
		}

		public Entry(string date, string description) : this(date)
		{
			this.Description = description;
		}
	}
}