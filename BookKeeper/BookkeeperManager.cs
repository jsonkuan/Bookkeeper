using System;
using System.Collections.Generic;

namespace BookKeeper
{
	public class BookkeeperManager
	{
		private static BookkeeperManager instance;

		private BookkeeperManager() {}
		public static BookkeeperManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new BookkeeperManager();
				}
				return instance; 
			}
		}

		public List<Entry> entryList = new List<Entry>();
		public readonly List<Account> incomeAccounts = new List<Account>() { new Account("Inc", "128"), new Account("Inc", "532") };
		public readonly List<Account> expenseAccounts  = new List<Account>() { new Account("ex", "678"), new Account("ex", "5432"), new Account("ex", "2432") };
		public readonly List<Account> moneyAccounts = new List<Account>() { new Account("Checking", ""), new Account("Tax", "") };
		public readonly List<TaxRate> taxRates = new List<TaxRate>() { new TaxRate(0.06), new TaxRate(0.12), new TaxRate(0.25) };

		public void addEntry(Entry e)
		{
			Console.WriteLine("\n \n \n Showing First Entry...");
			entryList.Add(e);
			foreach (Entry entry in entryList)
			{
				Console.WriteLine("Date: " + entry.Date + "\n" + 
				                  "Description: " + entry.Description + "\n" +
								  "TypeOfAccount: " + entry.TypeOfAccount + "\n" +
				                  "To/From Account: " + entry.ToFromAccount + "\n" +
				                  "Total Ammount: " + entry.TotalAmmount + "\n" +
				                  "Tax Rate: " + entry.TaxRate + "\n" + "\n");
			}

		}
	}
}
