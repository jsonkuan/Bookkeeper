using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using Java.Lang;

using SQLite;

namespace BookKeeper
{
	public class CustomListAdapter : BaseAdapter
	{
		BookkeeperManager bookkeeper = BookkeeperManager.Instance;
		private Activity context;

		private List<Entry> entryList = new List<Entry>();
		public CustomListAdapter(Activity context, SQLiteConnection db)
		{
			this.context = context;
			bookkeeper.database = db;

			//Must create temp-reference to database
			Entry tempEntry = new Entry();
			bookkeeper.AddEntry(tempEntry);
			bookkeeper.database.Delete(tempEntry);

			//Create a list of entries to satisfy the Count method
			TableQuery<Entry> query = bookkeeper.database.Table<Entry>().Where(x => x.Id >= 1);
			foreach (Entry e in query)
			{
				entryList.Add(e);
			}

		}

		public override int Count
		{
			get
			{
				return entryList.Count;
			}
		}

		public override Java.Lang.Object GetItem(int position)
		{
			return null;
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			//Must create temp-reference to database
			Entry tempEntry = new Entry();
			bookkeeper.AddEntry(tempEntry);
			bookkeeper.database.Delete(tempEntry);

			View view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.list_item_layout, parent, false);

			TableQuery<Entry> query = bookkeeper.database.Table<Entry>().Where(x => x.Id >= 1);
			foreach (Entry e in query)
			{
				view.FindViewById<TextView>(Resource.Id.cell_date).Text = entryList[position].Date;
				view.FindViewById<TextView>(Resource.Id.cell_description).Text = entryList[position].Description;
				view.FindViewById<TextView>(Resource.Id.cell_totalAmmount).Text = entryList[position].TotalAmmount + " kr";
			}
				
			return view; 
		}
	}
}
