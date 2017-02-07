using System;
using System.Collections.Generic;
using SQLite;

namespace BookKeeper
{
	public class BookkeeperManager
	{
		public  SQLiteConnection database;

		private static BookkeeperManager instance;
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

		public void AddEntry(Entry e)
		{
			string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			database = new SQLiteConnection(path + @"\database.db");
			database.Insert(e);
		}

		public string GetTaxReport()
		{
			// THIS WORKS  ---   BUG: MUST ADD ENTRY FIRST OR CRASHES
			double totalExpenseTax = 0;
			double totalIncomeTax = 0;
			string taxReport = "\n*** TAX SUMMARY ***\n";
			TableQuery<Entry> query = database.Table<Entry>().Where(x => x.Id >= 1);
			foreach (Entry e in query)
			{
				//INCOME
				if (e.ToFromAccount.Equals("Salary") || e.ToFromAccount.Equals("Loans"))
				{
					taxReport += "\nAmmount: " + e.TotalAmmount + "kr\n" +
					                              "Description: " + e.Description + "\n" +
								  "Tax Rate: " + e.TaxRate * 100 + "%\n" +
													 "Calculated Tax: " + (e.TaxRate * Convert.ToDouble(e.TotalAmmount)) + "kr\n";
					totalIncomeTax += e.TaxRate * Convert.ToDouble(e.TotalAmmount);
				}
				//EXPENSE
				else if (e.ToFromAccount.Equals("Drugs") || e.ToFromAccount.Equals("Hookers") || e.ToFromAccount.Equals("Bills"))
				{
					taxReport += "\nAmmount: " + e.TotalAmmount + "kr\n" +
								  "Description: " + e.Description + "\n" +
								  "Tax Rate: " + e.TaxRate * 100 + "%\n" +
													 "Calculated Tax: " + (e.TaxRate * Convert.ToDouble(e.TotalAmmount) * -1) + "kr\n";
					totalExpenseTax += e.TaxRate * Convert.ToDouble(e.TotalAmmount);
				}
					
			}

			return taxReport += "\nTOTAL INCOME TAX: " + Convert.ToString(totalIncomeTax) + "kr\n" +
				                                                 "TOTAL EXPENSE TAX: " + Convert.ToString(totalExpenseTax * -1) + "kr";
		}

		public void ConfigureTaxRates(SQLiteConnection db)
		{
			TaxRate t1 = new TaxRate(0.07);
			TaxRate t2 = new TaxRate(0.15);
			TaxRate t3 = new TaxRate(0.25);

			db.Insert(t1);
			db.Insert(t2);
			db.Insert(t3);
		}

		public void ConfigureAccountTypes(SQLiteConnection db)
		{
			//Money Accounts
			Account m1 = new Account("Savings", "M-");
			Account m2 = new Account("Stocks", "M-");
			Account m3 = new Account("Funds", "M-");

			//Income Accounts
			Account i1 = new Account("Salary", "I-");
			Account i2 = new Account("Loans", "I-");

			//Expense Accounts
			Account e1 = new Account("Drugs", "E-");
			Account e2 = new Account("Hookers", "E-");
			Account e3 = new Account("Bills", "E-");

			db.Insert(m1);
			db.Insert(m2);
			db.Insert(m3);

			db.Insert(i1);
			db.Insert(i2);

			db.Insert(e1);
			db.Insert(e2);
			db.Insert(e3);
		}

		public static bool TableExists<T>(SQLiteConnection connection)
		{
			const string cmdText = "SELECT name FROM sqlite_master WHERE type='table' AND name=?";
			var cmd = connection.CreateCommand(cmdText, typeof(T).Name);
			return cmd.ExecuteScalar<string>() != null;
		}
	}
}
