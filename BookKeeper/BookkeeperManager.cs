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
			Console.WriteLine("In the fuckin method...");
			entryArray.Add(e);
			foreach (Entry entry in entryArray)
			{
				Console.WriteLine("Date: " + entryArray[0].Date + "\n" + 
				                  "Description: " + entryArray[0].Description + "\n");
			}

		}
	}
}
