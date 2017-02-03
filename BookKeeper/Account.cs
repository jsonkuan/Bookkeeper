using System;
using SQLite;

namespace BookKeeper
{
	public class Account
	{
		[PrimaryKey, AutoIncrement]
		public int AccountNumber { get; private set; }
		public string Name { get; set; }
		public string Type { get; set;}

		public Account ()
		{
		}

		public Account(string name, string type)
		{
			Name = name;
			Type = type; 
		}

		public override string ToString()
		{
			return string.Format("{0}", Name);
		}
	}
}
