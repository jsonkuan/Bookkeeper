
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using SQLite;

namespace BookKeeper
{
	[Activity(Label = "Mina Händelser")]
	public class ShowAllActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.show_all_layout);
			BookkeeperManager bookkeeper = BookkeeperManager.Instance;

			ListView listview = FindViewById<ListView>(Resource.Id.showAllListView);
			var adapter = new CustomListAdapter(this, bookkeeper.database);
			listview.Adapter = adapter;
		}
	}
}
