
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

namespace BookKeeper
{
	[Activity(Label = "Your Entries")]
	public class ShowAllActivity : Activity
	{
		BookkeeperManager bookkeeper = BookkeeperManager.Instance;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.show_all_layout);

			ListView listview = FindViewById<ListView>(Resource.Id.showAllListView);
			var adapter = new ArrayAdapter<Entry>(this, 
			                                      Android.Resource.Layout.SimpleListItem1,
			                                      bookkeeper.entryList);
			listview.Adapter = adapter;
		}
	}
}
