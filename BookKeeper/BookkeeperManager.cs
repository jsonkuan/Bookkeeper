using System;
using System.Collections.Generic;
using SQLite;

namespace BookKeeper
{
	public class BookkeeperManager
	{

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

		public SQLiteConnection database;

		public void AddEntry(Entry e)
		{
			string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			database = new SQLiteConnection(path + @"\database.db");
			database.Insert(e);
		}

		public string GetTaxReport()
		{
			//Must create temp-reference to database
			Entry tempEntry = new Entry();
			AddEntry(tempEntry);
			database.Delete(tempEntry);

			double totalExpenseTax = 0;
			double totalIncomeTax = 0;
			string taxReport = "\n*** MOMS RAPPORT ***\n";
			TableQuery<Entry> query = database.Table<Entry>().Where(x => x.Id >= 1);
			foreach (Entry e in query)
			{
				//INCOME
				if (e.ToFromAccount.Equals("Lön") || e.ToFromAccount.Equals("Lån"))
				{
					taxReport += "\nSumman: " + e.TotalAmmount + "kr\n" +
				                  "Beskrivning: " + e.Description + "\n" +
								  "Moms: " + e.TaxRate + "%\n" +
			                      "Beräknade moms: " + ((e.TaxRate * 0.01) * Convert.ToDouble(e.TotalAmmount)) + "kr\n";
					totalIncomeTax += (e.TaxRate * 0.01) * Convert.ToDouble(e.TotalAmmount);
				}
				//EXPENSE
				else if (e.ToFromAccount.Equals("Kredit") ||  e.ToFromAccount.Equals("Faktura"))
				{
					taxReport += "\nSumman: " + e.TotalAmmount + "kr\n" +
								  "Beskrivning: " + e.Description + "\n" +
								  "Moms: " + e.TaxRate  + "%\n" +
					                             "Beräknade moms: " + ((e.TaxRate * 0.01)  * Convert.ToDouble(e.TotalAmmount) * -1) + "kr\n";
					totalExpenseTax += (e.TaxRate * 0.01) * Convert.ToDouble(e.TotalAmmount);
				}
			}

			return taxReport += "\nTOTAL INKOMSTSKATT: " + Convert.ToString(totalIncomeTax) + "kr\n" +
				                                                 "TOTAL UTGIFTERSKATT: " + Convert.ToString(totalExpenseTax * -1) + "kr";
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
			Account m1 = new Account("Sparkonto", "M-");
			Account m2 = new Account("Aktier", "M-");
			Account m3 = new Account("Fonder", "M-");

			//Income Accounts
			Account i1 = new Account("Lön", "I-");
			Account i2 = new Account("Lån", "I-");

			//Expense Accounts
			Account e1 = new Account("Kredit", "E-");
			Account e2 = new Account("Faktura", "E-");

			db.Insert(m1);
			db.Insert(m2);
			db.Insert(m3);

			db.Insert(i1);
			db.Insert(i2);

			db.Insert(e1);
			db.Insert(e2);
		}

		public static bool TableExists<T>(SQLiteConnection connection)
		{
			const string cmdText = "SELECT name FROM sqlite_master WHERE type='table' AND name=?";
			var cmd = connection.CreateCommand(cmdText, typeof(T).Name);
			return cmd.ExecuteScalar<string>() != null;
		}
	}

}
