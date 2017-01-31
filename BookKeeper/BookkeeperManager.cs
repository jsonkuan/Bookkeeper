using System;
using System.Collections.Generic;

namespace BookKeeper
{
	public class BookkeeperManager
	{
		Account IncomeAccount { get; set; }
		Account ExpenseAccount;
		Account MoneyAccount;
		TaxRate TaxRates;
		Entry Entries;

		//public BookkeeperManager(Account incomeAccount, Account expenseAccount, Account moneyAccount)
		//{
		//	IncomeAccount = incomeAccount;
		//	ExpenseAccount = expenseAccount;
		//	MoneyAccount = moneyAccount;
		//}

		//public BookkeeperManager(TaxRate taxRates)
		//{
		//	TaxRates = taxRates;
		//}

		//public BookkeeperManager(Entry entries)
		//{
		//	Entries = entries;
		//}

		public BookkeeperManager()
		{
		}

		public void addEntry(Entry e)
		{
			//Save this entry to the DB	
			// TEST: Try to save to a list first
		}

	}
}
