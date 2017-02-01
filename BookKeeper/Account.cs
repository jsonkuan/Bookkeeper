using System;
using SQLite;

namespace BookKeeper
{
	public class Account
	{
		[PrimaryKey, AutoIncrement]
		int AccountNumber { get; set; }
		public string Name { get; set; }
		public string Type { get; set;}

		public Account ()
		{
		}

		public Account(string name, string type, int accountNumber)
		{
			Name = name;
			Type = type; 
			AccountNumber = accountNumber;
		}

		public override string ToString()
		{
			return string.Format("{0}, {1}{2} ", Name, Type, AccountNumber);
		}

		public void configureAccountTypes(SQLiteConnection db)
		{
			//Money Accounts
			Account m1 = new Account("Savings", "M-", 0123);
			Account m2 = new Account("Stocks", "M-", 4567);
			Account m3 = new Account("Funds", "M-", 8910);

			//Income Accounts
			Account i1 = new Account("Salary", "I-", 4321);
			Account i2 = new Account("Loans", "I-", 8765);

			//Expense Accounts
			Account e1 = new Account("Drugs", "E-", 0123);
			Account e2 = new Account("Hookers", "E-", 4567);
			Account e3 = new Account("Bills", "E-", 8910);

			db.Insert(m1);
			db.Insert(m2);
			db.Insert(m3);

			db.Insert(i1);
			db.Insert(i2);

			db.Insert(e1);
			db.Insert(e2);
			db.Insert(e3);
		}
	}
}
