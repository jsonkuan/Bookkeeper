using System;
namespace BookKeeper
{
	public class Account
	{
		string Name { get; set; }
		string AccountNumber { get; set; }

		public Account(string name, string accountNumber)
		{
			Name = name;
			AccountNumber = accountNumber;
		}
	}
}
