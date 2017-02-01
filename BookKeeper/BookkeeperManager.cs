using System;
using System.Collections.Generic;
using SQLite;

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

		public void addEntry(Entry e)
		{
			string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			SQLiteConnection database = new SQLiteConnection(path + @"\database.db");
			database.Insert(e);
		}
	}
}
