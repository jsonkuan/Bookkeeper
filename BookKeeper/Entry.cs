using System;
namespace BookKeeper
{
	public class Entry
	{
		public string Date { get; set; }
		public string Description { get; set; }
		public string TypeOfAccount { get; set; }
		public string ToFromAccount { get; set; }
		public string TotalAmmount { get; set; }
		public string Type { get; set; }
		public string TaxRate { get; set; }

		public Entry(string date, string description, string typeOfAccount, string toFromAccount, string totalAmmount, string taxRate)
		{
			Date = date;
			Description = description;
			TypeOfAccount = typeOfAccount;
			ToFromAccount = toFromAccount;
			TotalAmmount = totalAmmount;
			TaxRate = taxRate;
		}

		//public override string ToString()
		//{
		//	return string.Format("Date: " + entryArray[0].Date + "\n" +
		//						  "Description: " + entryArray[0].Description + "\n" +
		//						  "TypeOfAccount: " + entryArray[0].TypeOfAccount + "\n" +
		//						  "To/From Account: " + entryArray[0].ToFromAccount + "\n" +
		//						  "Total Ammount: " + entryArray[0].TotalAmmount.ToString() + "\n" +
		//						  "Tax Rate: " + entryArray[0].TaxRate.ToString() + "\n" + "\n");
		//}
		
	}
}