using System;
using System.Collections.Generic;
using SQLite;

namespace BookKeeper
{
	public class BookkeeperManager
	{
		private static BookkeeperManager instance;
		public static SQLiteConnection database;

		public static BookkeeperManager Instance
		{
			get
			{
				if (instance == null)
				{
					string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
					database = new SQLiteConnection(path + @"\database.db");
					instance = new BookkeeperManager();
				}
				return instance; 
			}
		}

		public void addEntry(Entry e)
		{
			database.Insert(e);
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

		public void configureAccountTypes(SQLiteConnection db)
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
