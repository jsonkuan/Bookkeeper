using System;
using System.Collections.Generic;

namespace BookKeeper
{
	public class BookkeeperManager
	{
		List<Entry> entryArray = new List<Entry>();

		public BookkeeperManager()
		{
		}

		public void addEntry(Entry e)
		{
			Console.WriteLine("\n \n \n In the fuckin method...");
			entryArray.Add(e);
			foreach (Entry entry in entryArray)
			{
				Console.WriteLine("Date: " + entryArray[0].Date + "\n" + 
				                  "Description: " + entryArray[0].Description + "\n" +
								  "TypeOfAccount: " + entryArray[0].TypeOfAccount + "\n" +
				                  "To/From Account: " + entryArray[0].ToFromAccount + "\n" +
				                  "Total Ammount: " + entryArray[0].TotalAmmount.ToString() + "\n" +
				                  "Tax Rate: " + entryArray[0].TaxRate.ToString() + "\n" + "\n");
			}

		}
	}
}
